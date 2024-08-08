using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines_lekontsev.Classes
{
    public class TicketContext : Ticket
    {

        public TicketContext(int Price, string From, string To, DateTime StartTime, DateTime EndTime) : base(Price, From, To, StartTime, EndTime) { }
        public static List<TicketContext> AllTicket()
        {
            List<TicketContext> allTickets = new List<TicketContext>();

            MySqlConnection connection = WorkingDB.Connection.OpenConnection();
            MySqlDataReader ticketQuary = WorkingDB.Connection.Query("SELECT * FROM `Airlines`.`Tickets`;", connection);
            while (ticketQuary.Read())
            {
                allTickets.Add(new TicketContext(
                    ticketQuary.GetInt32(3),
                    ticketQuary.GetString(1),
                    ticketQuary.GetString(2),
                    ticketQuary.GetDateTime(4),
                    ticketQuary.GetDateTime(5)
                    ));
            }
            WorkingDB.Connection.CloseConnection(connection);
            return allTickets;
        }
    }
}