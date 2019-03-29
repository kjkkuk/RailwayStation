using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayStation
{
    class Way
    {
        public int counter { get; private set; }
        static int id;
        string _target, _home, _time;
        public int _id { get; private set; }
        public double _cost { get; private set; }
        int _seats;
        public Way(string target,string home,string time,double cost,int seats)
        {
            _target = target;
            _home = home;
            _time = time;
            _cost = cost;
            _seats = seats;
            id++;
            _id = id;
            
        }

        public void GetInformation()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"id: {_id}\tТочка отправления: {_home}\tКонечная точка: {_target}\n" +
                $"Время в пути:{_time}\tСтоимость билета: {_cost}\n" +
                $"Всего мест: {_seats}\tСвободных мест:{_seats-counter}\n");
            Console.ResetColor();
        }

        public double GetCost() => _cost;
        public void CountUp() => ++counter;
        public void CountDown() => --counter;
    }
}
