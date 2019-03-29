using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayStation
{
    class Employer: Person,IAdmin
    {
       

        public Employer(string name) : base(name) { }

        public Way MakeTrip()
        {
            string target, home, time;
            int seats;
            double cost;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Введите место отправления");
            Console.ResetColor();
            home = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Введите место прибытия");
            Console.ResetColor();
            target = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Введите время продолжительности пути в формате HH:MM");
            Console.ResetColor();
            time = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Введите стоимость");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            cost = Convert.ToDouble(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Введите Количество мест");
            Console.ResetColor();
            seats = Convert.ToInt32(Console.ReadLine());
            return new Way(target, home, time, cost, seats);
            
        }
        public void DeleteTrip()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Введите id маршрута, который хотите удалить");
            Console.ResetColor();
            int id = Convert.ToInt32(Console.ReadLine());
            bool deleted=false;
            for (int i = 0; i < Program.Ways.Count; i++)
            {
                if (Program.Ways[i]._id == id)
                {
                    Program.Ways.Remove(Program.Ways[i]);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Маршрут удалён");
                    Console.ResetColor();
                    deleted = true;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (!deleted) Console.WriteLine($"Маршрута с id: {id} не существет");
            Console.ResetColor();
        }
        public void GetInfo()
        {
            for (int i = 0; i < Program.Ways.Count; i++)
            {
                Program.Ways[i].GetInformation();
            }
        }
       
    }
}
