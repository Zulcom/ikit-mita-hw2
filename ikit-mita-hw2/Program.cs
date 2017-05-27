using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace ikit_mita_hw2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("FR001: Покупаю машину лада категории D...");
            Car lada = new Car("Лада", 'D');
            Console.WriteLine(" покупка совершена");
            Console.Write("FR001: Крашу её в баклажановый цвет...");
            lada.Color = Color.DarkMagenta;
            Console.WriteLine(" окрашено");
            Console.Write("FR002: Владелец лады: ");
            try
            {
                Console.Write(lada.CarPassport.Owner.Name);
            }
            catch (Exception)
            {
                Console.WriteLine("Водителя нет!");
            }
            Console.Write("FR003: Нанимаю инструктора Вольдемар...");
            Driver voldemar = new Driver(new DateTime(1997, 02, 13), "Вольдемар");
            Console.WriteLine("Нанят");
            Console.Write("FR003: Заполняю его категории: В и С...");
            voldemar.Category = "BC";
            Console.WriteLine("заполнены");
            Console.WriteLine("FR004: Меняю водителя Лады на Вольдемара, новый номер машины о777оо ...");
            Console.WriteLine(lada.ChangeOwner(voldemar, "o777oo"));
            Console.WriteLine("FR005: Добавляю ему категорию D и вновь выдаю ему машину...");
            voldemar.Category += "D";
            Console.WriteLine(lada.ChangeOwner(voldemar, "o777oo"));
            Console.Write("FR006: Номер машины Вольдемара...");
            Console.WriteLine(voldemar.Car.CarNumber);
            Console.Write("FR007: Имя владельца Лады...");
            try
            {
                Console.WriteLine(lada.CarPassport.Owner.Name);
            }
            catch (Exception)
            {
                Console.WriteLine("Водителя нет!");
            }
            Console.Read();
        }
    }
}