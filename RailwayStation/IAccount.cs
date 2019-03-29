using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayStation
{
    interface IAccount
    {
        void BuyTicket();
        void SellTicket();

        void ShowTickets();
        void ChangePass();
    }
}
