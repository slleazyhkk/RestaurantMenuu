using Model.Core.Dishes;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantMenu2.Restaurant.Gastronomy
{
    public partial class FormGastronomy2 : Form
    {
        private readonly BindingSource bindingSource = new BindingSource();
        private readonly Dictionary<string, ListSortDirection> sortDirections = new Dictionary<string, ListSortDirection>();
        private static List<Dish> allDishes = new List<Dish>();

        public FormGastronomy2()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadMenuData();
            InitializeFilterControls();
        }

        private void ConfigureDataGridView()
        {
            // Основные настройки таблицы
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;

            // Стили таблицы
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Sans Serif", 8, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowTemplate.Height = 30;

            // Очистка и создание колонок
            dataGridView1.Columns.Clear();
            CreateColumns();
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                DataPropertyName = "Name",
                HeaderText = "Название блюда",
                Width = 200,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                DataPropertyName = "Price",
                HeaderText = "Цена (₽)",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0",
                    Font = new Font("Segoe UI", 8, FontStyle.Bold),
                    ForeColor = Color.DarkGreen
                }
            });

            // Добавьте остальные колонки аналогично
        }

        private void LoadMenuData()
        {
            try
            {
                var establishment = MenuRepository.GetGastronomikaEstablishment();
                allDishes = establishment.RegularMenu.Dishes
                    .Concat(establishment.SeasonMenu.Dishes)
                    .ToList();

                bindingSource.DataSource = new BindingList<Dish>(allDishes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки меню: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeFilterControls()
        {
            var filterPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.WhiteSmoke
            };

            var filterLabel = new Label
            {
                Text = "Фильтр по типу блюда:",
                Location = new Point(10, 10),
                AutoSize = true
            };

            var dishTypeComboBox = new ComboBox
            {
                Location = new Point(150, 7),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            UpdateDishTypesComboBox(dishTypeComboBox);

            filterPanel.Controls.Add(filterLabel);
            filterPanel.Controls.Add(dishTypeComboBox);
            this.Controls.Add(filterPanel);
            filterPanel.BringToFront();
        }

        private void UpdateDishTypesComboBox(ComboBox comboBox)
        {
            var dishTypes = allDishes
                .Select(d => d.DishType)
                .Distinct()
                .OrderBy(t => t)
                .ToList();

            dishTypes.Insert(0, "Все типы");
            comboBox.DataSource = dishTypes;
            comboBox.SelectedIndexChanged += (s, e) => ApplyFilters(comboBox.SelectedItem.ToString());
        }

        private void ApplyFilters(string selectedDishType)
        {
            var filtered = selectedDishType == "Все типы"
                ? allDishes
                : allDishes.Where(d => d.DishType == selectedDishType);

            bindingSource.DataSource = new BindingList<Dish>(filtered.ToList());

            if (!string.IsNullOrEmpty(bindingSource.Sort))
                bindingSource.Sort = bindingSource.Sort;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddDishGastronomy())
            {
                if (addForm.ShowDialog() == DialogResult.OK && addForm.dish != null)
                {
                    allDishes.Add(addForm.dish);
                    bindingSource.ResetBindings(false);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var selectedDish = (Dish)dataGridView1.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Удалить блюдо '{selectedDish.Name}'?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                allDishes.Remove(selectedDish);
                bindingSource.ResetBindings(false);
            }
        }

        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var column = dataGridView1.Columns[e.ColumnIndex];
            var direction = sortDirections.TryGetValue(column.Name, out var dir)
                ? dir == ListSortDirection.Ascending
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending
                : ListSortDirection.Ascending;

            sortDirections[column.Name] = direction;
            bindingSource.Sort = $"{column.Name} {direction}";
            UpdateSortGlyphs(column.Name);
        }

        private void UpdateSortGlyphs(string sortedColumnName)
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.HeaderCell.SortGlyphDirection = SortOrder.None;

            dataGridView1.Columns[sortedColumnName].HeaderCell.SortGlyphDirection =
                sortDirections[sortedColumnName] == ListSortDirection.Ascending
                    ? SortOrder.Ascending
                    : SortOrder.Descending;
        }
    }
}