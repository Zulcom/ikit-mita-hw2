using System;

namespace Domain
{
    public class Driver
    {
        public Driver(DateTime licenceDate, string name)
        {
            LicenceDate = licenceDate;
            Name = name;
        }

        /// <summary>
        /// дата выдачи прав
        /// </summary>
        public DateTime LicenceDate { get; }

        public string Name { get; }

        /// <summary>
        ///  Водительский стаж
        /// </summary>
        public int Experience => DateTime.Today.Year - LicenceDate.Year;

        /// <summary>
        ///  Категории автомобиля - может быть несоколько
        /// </summary>
        public string Category { get; set; }

        public Car Car { get; private set; }

        /// <summary>
        /// закрепляет машину за водителем. 
        /// если водитель не имеет категории управления этой машиной - бросает исключение.
        /// </summary>
        /// <param name="car"> закрепляемая машина</param>
        public void OwnCar(Car car)
        {
            if (Category.Contains(car.Category.ToString())) { 
                    this.Car = car;           
                }
            else throw new ArgumentException($"Водитель не имеет категории {car.Category}", "car");
        }
    }
}