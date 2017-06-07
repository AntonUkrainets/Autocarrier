using Autocarrier.Data;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Autocarrier
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository repository = null;

        private bool driverWasAdded;
        private bool driverWasChanged;

        private bool carWasAdded;
        private bool carWasChanged;

        private bool tripWasAdded;
        private bool tripWasChanged;

        public MainWindow()
        {
            this.InitializeComponent();

            this.repository = new Repository();
            this.Loaded += this.MainWindow_Loaded;

            this.dataGridDrivers.CurrentCellChanged += this.DataGridDrivers_CurrentCellChanged;
            this.dataGridDrivers.RowEditEnding += this.DataGridDrivers_RowEditEnding;
            this.dataGridDrivers.AddingNewItem += this.DataGridDrivers_AddingNewItem;

            this.dataGridCars.CurrentCellChanged += DataGridCars_CurrentCellChanged;
            this.dataGridCars.RowEditEnding += this.DataGridCars_RowEditEnding;
            this.dataGridCars.AddingNewItem += this.DataGridCars_AddingNewItem;

            this.dataGridTrips.CurrentCellChanged += this.DataGridTrips_CurrentCellChanged;
            this.dataGridTrips.RowEditEnding += this.DataGridTrips_RowEditEnding;
            this.dataGridTrips.AddingNewItem += this.DataGridTrips_AddingNewItem;
        }

        /// <summary>
        /// событие добавление новой поездки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridTrips_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            this.tripWasAdded = true;
        }

        /// <summary>
        /// событие измнение выбранной поездки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridTrips_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            this.tripWasChanged = true;
        }

        /// <summary>
        /// событие при создании новой поездки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridTrips_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.tripWasChanged)
            {
                Trip trip = this.GetCurrentTrip();

                if (this.tripWasAdded)
                    this.repository.AddTrip(trip);

                else this.repository.UpdateTrip(trip);

                this.tripWasChanged = false;
                this.tripWasAdded = false;
            }
        }
        
        /// <summary>
        /// событие добавление новой машины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridCars_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            this.carWasAdded = true;
        }

        /// <summary>
        /// событие редактирования выбранной машины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridCars_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            this.carWasChanged = true;
        }

        /// <summary>
        /// событие при создании новой машины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridCars_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.carWasChanged)
            {
                Car car = this.GetCurrentCar();

                if (this.carWasAdded)
                    this.repository.AddCar(car);

                else this.repository.UpdateCar(car);

                this.carWasChanged = false;
                this.carWasAdded = false;
            }
        }

        /// <summary>
        /// получить выбранного водителя
        /// </summary>
        /// <returns></returns>
        private Driver GetCurrentDriver()
        {
            return this.dataGridDrivers.SelectedItem as Driver;
        }

        /// <summary>
        /// получить выбранную машину
        /// </summary>
        /// <returns></returns>
        private Car GetCurrentCar()
        {
            return this.dataGridCars.SelectedItem as Car;
        }

        /// <summary>
        /// получить выбранную поездку
        /// </summary>
        /// <returns></returns>
        private Trip GetCurrentTrip()
        {
            return this.dataGridTrips.SelectedItem as Trip;
        }

        /// <summary>
        /// добавление нового водителя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridDrivers_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            this.driverWasAdded = true;
        }

        /// <summary>
        /// событие при создании нового водителя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridDrivers_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.driverWasChanged)
            {
                Driver driver = this.GetCurrentDriver();

                if (this.driverWasAdded)
                    this.repository.AddDriver(driver);

                else this.repository.UpdateDriver(driver);

                this.driverWasChanged = false;
                this.driverWasAdded = false;
            }
        }

        /// <summary>
        /// редактирование выбранного водителя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridDrivers_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            this.driverWasChanged = true;
        }

        /// <summary>
        /// событие загрузки окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadData();
        }

        /// <summary>
        /// метод загрузки машин, поездок и водителей из базы данных в DataGrid
        /// </summary>
        private void LoadData()
        {
            this.dataGridCars.ItemsSource = this.repository.GetCars();
            this.dataGridTrips.ItemsSource = this.repository.GetTrips();
            this.dataGridDrivers.ItemsSource = this.repository.GetDrivers();
        }

        /// <summary>
        /// кнопка удаления поездок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteTrips_Click(object sender, RoutedEventArgs e)
        {
            Trip trip = this.GetCurrentTrip();

            if (trip == null)
                return;

            this.repository.DeleteTrip(trip);
            this.LoadData();
        }

        /// <summary>
        /// кнопка удаления водителя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteDriver_Click(object sender, RoutedEventArgs e)
        {
            Driver driver = this.GetCurrentDriver();

            if (driver == null)
                return;

            this.repository.DeleteDriver(driver);
            this.LoadData();
        }

        /// <summary>
        /// событие изменения имени водителя в TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = this.textBox.Text;

            if (string.IsNullOrEmpty(search))
                this.dataGridDrivers.ItemsSource = this.repository.GetDrivers();

            else
                this.dataGridDrivers.ItemsSource = this.repository.SearchDrivers(search);
        }

        /// <summary>
        /// кнопка удаления машины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteCar_Click(object sender, RoutedEventArgs e)
        {
            Car car = this.GetCurrentCar();

            if (car == null)
                return;

            this.repository.DeleteCar(car);
            this.LoadData();
        }

        /// <summary>
        /// событие изменение названия машины в TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = this.textBox1.Text;

            if (string.IsNullOrEmpty(search))
                this.dataGridCars.ItemsSource = this.repository.GetCars();

            else
                this.dataGridCars.ItemsSource = this.repository.SearchCars(search);
        }

        /// <summary>
        /// событие изменения названия поездки в TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = this.textBox2.Text;

            if (string.IsNullOrEmpty(search))
                this.dataGridTrips.ItemsSource = this.repository.GetTrips();

            else
                this.dataGridTrips.ItemsSource = this.repository.SearchTrips(search);
        }
    }
}
/*Необходимо реализовать программу для автоперевозчиков. В ней должен быть интерфейс для добавления, 
поиска, изменения и удаления информации о: 
1) автомобиле: марка, год выпуска, пробег, стоимость, тонаж, номер.
2) водителе: ФИО, стаж, оклад, место проживания, телефон.
3) рейсах: от куда, куда, водитель, машина, груз и время перевозки. 
Предусмотреть грамотную нормализацию и связи бд и таблиц.
Обязательно использовать: Entity Model-First, LINQ, нормальный интерфейс, комментарии XML,
обработка исключений, иначе будет соответственная оценка.*/