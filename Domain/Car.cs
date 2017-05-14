using System;
using System.Drawing;


namespace Domain
{
    public class Car
    {
        /// <summary>
        ///     Создаю машины
        /// </summary>
        /// <param name="model"> Имя водителя </param>
        /// <param name="category"> категория транспортного средства (BCDEF – только одна)</param>
        public Car(string model, char category)
        {
            Model = model;
            if (category - 66 <= 70 - 66) // ASCII `B` Code = 66, F Code = 70; a<=x<=b == x-a <= b-a 
                Category = category;
            else
                throw new ArgumentOutOfRangeException(nameof(category),
                    "Вы попытались создать машину с недекларированной категорией");
            CarPassport = new CarPassport(this);
            CarNumber = ToString();
        }

        /// <summary>
        ///     имя водителя
        /// </summary>
        public string Model { get; }

        public Color Color { get; set; } = Color.Blue;
        public string CarNumber { get; private set; } // FIXME: или internal?
        public char Category { get; }
        public CarPassport CarPassport { get; }

        /// <summary>
        ///     закрепляет нового водителя за машиной
        /// </summary>
        /// <param name="owner"> Новый хозяин</param>
        /// <param name="carNumber">Новый номер машины</param>
        public string ChangeOwner(Driver owner, string carNumber)
        {
           
            try
            {
                CarPassport.Owner=owner;
                CarPassport.Owner.OwnCar(this);
                CarNumber=carNumber;
               
                return "Новый водитель установлен";
            }
            catch (ArgumentException e)
            {
                CarPassport.Owner=null;
                return e.Message;
            }
        }
    }
}