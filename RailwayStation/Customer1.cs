using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayStation
{
    class Customer1: Person,IAccount
    {
        List<Way> Tickets = new List<Way>();
        double _money;
        string _pass;

        public Customer1(string name, string password, double money) : base(name)
        {
            _money = money;_pass = password;
        }
        public string GetPass() => _pass;
        public double GetMoney() => _money;

        public void BuyTicket()
        {
            int state=0;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Введите id маршрута билет которого хотите купить");
            Console.ResetColor();
            int tempid = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Program.Ways.Count; i++)
            {
                if (Program.Ways[i]._id == tempid)
                {
                    state = 1;
                    if (Program.Ways[i]._cost <= _money)
                    {
                        state = 2;
                        Tickets.Add(Program.Ways[i]);
                        Program.Ways[i].CountUp();
                        _money -= Program.Ways[i]._cost;
                    }
                    break;
                }
            }
            switch (state)
            {
                case 0:
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Маршрт с данным id не найден");
                        Console.ResetColor();
                        break;
                    }
                case 1:
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Вам не хватает средст для покупки билета");
                        Console.ResetColor();
                        break;
                    }
                case 2:
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Вы спешно купили билет");
                        Console.ResetColor();
                        break;
                    }
            }
        }

        public void SellTicket()
        {
            int state = 0;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Введите id маршрута билет которого хотите купить");
            Console.ResetColor();
            int tempid = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Program.Ways.Count; i++)
            {
                if (Program.Ways[i]._id == tempid)
                {
                    state = 1;
                    Tickets.Remove(Program.Ways[i]);
                    Program.Ways[i].CountDown();
                    _money += Program.Ways[i]._cost;
                    break;
                }
            }
            switch (state)
            {
                case 0:
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Билета с данным id не найденно у вас");
                        Console.ResetColor();
                        break;
                    }
                case 1:
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Вы успешно продаи билет");
                        Console.ResetColor();
                        break;
                    }
                
            }
        }

        public void ShowTickets()
        {
            for (int i = 0; i < Tickets.Count; i++)
            {
                Tickets[i].GetInformation();
            }
        }
        public void ChangePass()
        {
            string temppass, newpass;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Введите текущий пароль");
            Console.ResetColor();
            temppass = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Введите новый пароль");
            Console.ResetColor();
            newpass = Console.ReadLine();
            if (temppass == _pass)
            {
                _pass = newpass;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Пароль  успешно изменён");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Вы ввели неверный пароль");
                Console.ResetColor();
            }
        }
    }
}
