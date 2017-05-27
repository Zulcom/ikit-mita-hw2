using System;
using System.Linq;

namespace Domain
{
    public class Driver
    {
        private string _category;
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
        public int Experience
        {
            get
            {
                TimeSpan timeSpan = DateTime.Now-LicenceDate;
                var years = timeSpan.Days/365;
                return years;
            }
        }

        /// <summary>
        ///  Категории автомобиля - может быть несоколько
        /// </summary>
        public string Category {
            get { return _category; }
            set
            {
                if (value.Any(c => !(c - 66 <= 70 - 66)))              
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "Вы попытались создать водителя с недекларированной категорией");
                 // else ...
                _category = value;
            }

        }

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