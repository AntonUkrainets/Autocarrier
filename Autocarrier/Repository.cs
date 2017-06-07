using Autocarrier.Data;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Autocarrier
{
    class Repository
    {
        private AutocarrierModel model = null;

        /// <summary>
        /// создание репозитория
        /// </summary>
        public Repository()
        {
            model = new AutocarrierModel();
        }

        /// <summary>
        /// получение списка водителей
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Driver> GetDrivers()
        {
            return model.Drivers.ToList();
        }

        /// <summary>
        /// получение списка машин
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Car> GetCars()
        {
            return model.Cars.ToList();
        }

        /// <summary>
        /// получение списка поездок
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Trip> GetTrips()
        {
            return model.Trips.ToList();
        }

        /// <summary>
        /// удаление водителя
        /// </summary>
        /// <param name="driver">имя водителя, по которому его необходимо удалить</param>
        public void DeleteDriver(Driver driver)
        {
            this.model.Drivers.Remove(driver);
            this.model.SaveChanges();
        }

        /// <summary>
        /// добавление водителя
        /// </summary>
        /// <param name="driver"></param>
        public void AddDriver(Driver driver)
        {
            this.model.Drivers.Add(driver);
            this.model.SaveChanges();
        }

        /// <summary>
        /// изменение данных о водителе
        /// </summary>
        /// <param name="driver">имя водителя, по которому его необходимо обновить</param>
        public void UpdateDriver(Driver driver)
        {
            this.model.Entry(driver).State = System.Data.Entity.EntityState.Modified;
            this.model.SaveChanges();
        }

        /// <summary>
        /// поиск водителя по имени
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<Driver> SearchDrivers(string search)
        {
            return this.model.Drivers.Where(x => x.FullName.Contains(search)).ToList();
        }

        /// <summary>
        /// добавление новой машины
        /// </summary>
        /// <param name="car">имя машины, по которой ее необходимо добавить</param>
        public void AddCar(Car car)
        {
            this.model.Cars.Add(car);
            this.model.SaveChanges();
        }

        /// <summary>
        /// изменение данных о машине
        /// </summary>
        /// <param name="car">имя машины, по которой ее необходимо обновить</param>
        public void UpdateCar(Car car)
        {
            this.model.Entry(car).State = System.Data.Entity.EntityState.Modified;
            this.model.SaveChanges();
        }

        /// <summary>
        /// удаление машины
        /// </summary>
        /// <param name="car">имя машины, по которой ее необходимо удалить</param>
        public void DeleteCar(Car car)
        {
            this.model.Cars.Remove(car);
            this.model.SaveChanges();
        }

        /// <summary>
        /// добавление новой поездки
        /// </summary>
        /// <param name="trip"></param>
        public void AddTrip(Trip trip)
        {
            this.model.Trips.Add(trip);
            this.model.SaveChanges();
        }

        /// <summary>
        /// обновление поездки
        /// </summary>
        /// <param name="trip">имя поздки, по которой ее необходимо обновить</param>
        public void UpdateTrip(Trip trip)
        {
            this.model.Entry(trip).State = System.Data.Entity.EntityState.Modified;
            this.model.SaveChanges();
        }

        /// <summary>
        /// удаление поздки
        /// </summary>
        /// <param name="trip">имя поздки, по которой ее необходимо удалить</param>
        public void DeleteTrip(Trip trip)
        {
            this.model.Trips.Remove(trip);
            this.model.SaveChanges();
        }

        /// <summary>
        /// поиск машины по ее имени
        /// </summary>
        /// <param name="search">имя машины, по которой ее необходимо искать</param>
        /// <returns></returns>
        public IEnumerable SearchCars(string search)
        {
            return this.model.Cars.Where(x => x.Mark.Contains(search)).ToList();
        }

        /// <summary>
        /// поиск поездки по ее имени
        /// </summary>
        /// <param name="fromWhere">имя поездки, по которой необходимо искать</param>
        /// <returns></returns>
        public IEnumerable SearchTrips(string fromWhere)
        {
            return this.model.Trips.Where(x => x.FromWhere.Contains(fromWhere)).ToList();
        }
    }
}