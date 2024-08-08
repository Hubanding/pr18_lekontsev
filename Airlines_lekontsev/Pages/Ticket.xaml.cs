using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Airlines_lekontsev.Pages
{
    /// <summary>
    /// Логика взаимодействия для Ticket.xaml
    /// </summary>
    public partial class Ticket : Page
    {
        public List<TicketContext> AllTickets;
        public Ticket(string from, string to)
        {
            InitializeComponent();
            AllTickets = TicketContext.AllTicket().FindAll(x =>
                 (x.From == from && to == "") || (from == "" && x.To == to) || (x.From == from && x.To == to));
            CreateUI();
        }
        public void CreateUI()
        {
            foreach (TicketContext ticket in AllTickets)
            {
                parent.Children.Add(new Elements.Item(ticket));
            }
        }
    }
}
