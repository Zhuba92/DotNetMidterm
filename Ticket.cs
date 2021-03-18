using System; 
using System.Collections.Generic;

namespace MidTerm
{
    public class Ticket
    {
        public string ticketNumber {get; set;}
        public string ticketSummary {get; set;}
        public string ticketStatus {get; set;}
        public string ticketPriority {get; set;}
        public string ticketSubmitter {get; set;}
        public string ticketAssignedTo {get; set;}
        public string ticketSeverity {get; set;}
        public List<string> ticketWatchers {get; set;}

        public Ticket()
        {
            ticketWatchers = new List<string>();
        }

        public string displayTicketNames()
        {
            string names = "";
            for (int i = 0; i < ticketWatchers.Count; i++)
            {
                if (i < ticketWatchers.Count - 1)
                {
                    names += ticketWatchers[i] + "|";
                }
                else names += ticketWatchers[i];
            }
            return names;
        }

        public string Display()
        {
            return $"{ticketNumber},{ticketSummary},{ticketStatus},{ticketPriority},{ticketSubmitter},{ticketAssignedTo},{ticketSeverity},{displayTicketNames()}";
        }
    }
}
