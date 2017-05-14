using System;
using System.Drawing;

/*
 1. Model – readonly property, имя водителя, задается параметром в конструкторе
2. Color – property, цвет машины, по умолчанию синий. Не использовать строку (тип string),
ищите стандартные типы
3. CarNumber – property, номер машины, setter закрыт для внешнего кода
4. Category - readonly property, категория транспортного средства (BCDEF – только одна),
задается параметром в конструкторе
5. CarPassport – readonly property, создается автоматически при создании машины
6. ChangeOwner – method, закрепляет нового водителя за машиной, принимает через
параметры нового владельца и новый номер машины. Поменять владельца в паспорте.
Изменить у владельца машину. Изменить номер мышины
     */

namespace Domain
{
    public class Car
    {
        /// <summary>
        ///     Создаю машины
        /// </summary>
        /// <param name="model"> Имя водителя </param>
        /// <param name="category"> категория транспортного средства (BCDEF – только одна)</param>
        private Car(string model, char category)
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
            CarNumber = carNumber;
            CarPassport.Owner = owner;
            try
            {
                CarPassport.Owner.OwnCar(this);
                return "Новый водитель установлен";
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
        }
    }
}