using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayStation
{

    class Program
    {
        public static List<Way> Ways = new List<Way>();
        static List<Customer1> Customers = new List<Customer1>();

        

        static void Main(string[] args)
        {
            //test
            Ways.Add(new Way("Минск", "Молодечно", "01:20", 5, 25));
            Ways.Add(new Way("Варшава", "Минск", "11:15", 6, 55));
            Ways.Add(new Way("Воложин", "Гомель", "06:20", 7, 75));
            Ways.Add(new Way("Вилейка", "Вильнус", "03:11", 9, 35));
            //
            string Choice, LocalChoise;
            bool exit = false;
            Employer admin = new Employer("admin");
            Customer1 tempacc = new Customer1("test","test",0);
            try
            {
                while (!exit)
                {
                    Choice = "0";
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Вы хотите войти как:\n" +
                        "1.Пользователь\t2.Администратор\t3. Выйти из Приложения");
                    Console.ResetColor();
                    Choice = Console.ReadLine();
                    switch (Choice)
                    {
                        case "1":
                            {
                                string name, pass;
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Введите логин");
                                Console.ResetColor();
                                name = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Введите пароль");
                                Console.ResetColor();
                                pass = Console.ReadLine();
                                tempacc = Login(name, pass);
                                if (tempacc == null) Choice = "0";
                                break;
                            }
                        case "2":
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Вы вошли, как администратор");
                                Console.ResetColor();
                                break;
                            }
                        case "3":
                            {
                                exit = true;
                                break;
                            }
                    }

                    if (Choice == "3") break;


                    while (Choice == "1")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nЛогин: {tempacc.GetName()}\tДеньги на счету: {tempacc.GetMoney()}\n\n" +
                            "........Меню........\n" +
                            "1. Купить билет\t2. Продать билет\t3. Сменить пароль\n" +
                            "4. Мои билеты\t5. Билеты для покупок\t6.Выйти из аккаунта");
                        Console.ResetColor();
                        LocalChoise = Console.ReadLine();
                        switch (LocalChoise)
                        {
                            case "1":
                                {
                                    tempacc.BuyTicket();
                                    break;
                                }
                            case "2":
                                {
                                    tempacc.SellTicket();
                                    break;
                                }
                            case "3":
                                {
                                    tempacc.ChangePass();
                                    break;
                                }
                            case "4":
                                {
                                    tempacc.ShowTickets();
                                    break;
                                }
                            case "5":
                                {
                                    admin.GetInfo();
                                    break;
                                }
                            case "6":
                                {
                                    Choice = "0";
                                    LocalChoise = "0";
                                    break;
                                }
                        }
                    }
                    while (Choice == "2")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("........Меню........\n" +
                            "1. Создать маршрут\t2. Удалить маршрут\n" +
                            "3. Все маршруты\t4.Выйти из аккаунта");
                        Console.ResetColor();
                        LocalChoise = Console.ReadLine();
                        switch (LocalChoise)
                        {
                            case "1":
                                {
                                    Ways.Add(admin.MakeTrip());
                                    break;
                                }
                            case "2":
                                {

                                    admin.DeleteTrip();
                                    break;
                                }
                            case "3":
                                {
                                    admin.GetInfo();
                                    break;
                                }
                            case "4":
                                {
                                    Choice = "0";
                                    LocalChoise = "0";
                                    break;
                                }
                        }

                    }
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы ввели данные в неверном формате. Перезапустите приложение. \n" +
                    "Нажмите любую кнопку, чтобы выйти..");
                Console.ReadKey();
                Console.ResetColor();
            }
        }

        public static Customer1 Login(string name,string pass)
        {
            bool newacc = true;
            Customer1 tempobj = null;
            
                for (int i = 0; i < Customers.Count; i++)
                {
                    if (Customers[i].GetName() == name)
                    {
                        newacc = false;
                        if (Customers[i].GetPass() == pass)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"{name}, Вы успешно залогинились");
                            Console.ResetColor();

                            tempobj = Customers[i];
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"{name}, Вы ввели неверный пароль");
                            Console.ResetColor();
                        }
                    }
                }
                if (newacc)
                {
                    double money;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Будет создан новый аккаунт\n" +
                        "Введите сумму, которую хотите положить на счёт");
                    Console.ResetColor();
                    money = Convert.ToDouble(Console.ReadLine());
                    tempobj = new Customer1(name, pass, money);
                    Customers.Add(tempobj);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Аккаунт был успешно создан");
                    Console.ResetColor();
            }
            
            
            return tempobj;
        }
    }
}
