using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayStation
{
    interface IAdmin
    {
        Way MakeTrip();
        void DeleteTrip();
        void GetInfo();
    }
}
