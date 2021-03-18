using System;
using System.IO;
using System.Collections.Generic;
using NLog.Web;

namespace MidTerm
{
    class Program 
    {
        static void Main(string[] args)
        {
            Console.Write("Would you like to create a ticket (Y/N)? ");
            char choice = Console.ReadLine().ToUpper()[0];

            while (choice == 'Y')
            {
                Console.WriteLine("Please enter the number of the ticket type you would like to create:\n1. Bug/Defect ticket\n2. Enahancement ticket\n3. Task ticket");
                int ticketType = Convert.ToInt32(Console.ReadLine());

                if(ticketType == 1)
                {
                    string file = "Tickets.csv";
                    StreamWriter sw = new StreamWriter(file);
                    Ticket ticket = new Ticket();

                    Console.Write("Enter a ticket number: ");
                    ticket.ticketNumber = Console.ReadLine();
                    Console.Write("Enter a summary: ");
                    ticket.ticketSummary = Console.ReadLine();
                    Console.Write("Enter a status: ");
                    ticket.ticketStatus = Console.ReadLine();
                    Console.Write("Enter a priority: ");
                    ticket.ticketPriority = Console.ReadLine();
                    Console.Write("Enter a submitter: ");
                    ticket.ticketSubmitter = Console.ReadLine();
                    Console.Write("Enter an assigned to: ");
                    ticket.ticketAssignedTo = Console.ReadLine();
                    Console.WriteLine("Please enter a serverity: ");
                    ticket.ticketSeverity = Console.ReadLine();
                    Console.Write("Would you like to add a watcher (Y/N)? ");
                    char addWatcher = Console.ReadLine().ToUpper()[0];
                    
                    while (addWatcher == 'Y')
                    {
                        Console.Write("Enter the name of the watcher: ");
                        string addName = Console.ReadLine();
                        ticket.ticketWatchers.Add(addName);
                        Console.Write("Would you like to add another watcher (Y/N)? ");
                        addWatcher = Console.ReadLine().ToUpper()[0];
                    } 

                    sw.WriteLine(ticket.Display());
                    sw.Close();
                    Console.Write("Would you like to create another ticket (Y/N)? ");
                    choice = Console.ReadLine().ToUpper()[0];
                }

                else if(ticketType == 2)
                {
                    string file = "Enhancements.csv";
                    StreamWriter sw = new StreamWriter(file);
                    Enhancements enhancement = new Enhancements();

                    Console.Write("Enter a ticket number: ");
                    enhancement.enhancementNumber = Console.ReadLine();
                    Console.Write("Enter a summary: ");
                    enhancement.enhancementSummary = Console.ReadLine();
                    Console.Write("Enter a status: ");
                    enhancement.enhancementStatus = Console.ReadLine();
                    Console.Write("Enter a priority: ");
                    enhancement.enhancementPriority = Console.ReadLine();
                    Console.Write("Enter a submitter: ");
                    enhancement.enhancementSubmitter = Console.ReadLine();
                    Console.Write("Enter an assigned to: ");
                    enhancement.enhancementAssignedTo = Console.ReadLine();
                    Console.Write("Enter the type of software: ");
                    enhancement.enhancementSoftware = Console.ReadLine();
                    Console.Write("Enter a cost: ");
                    enhancement.enhancementCost = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter an reason for this change: ");
                    enhancement.enhancementReason = Console.ReadLine();
                    Console.Write("Enter a estimate: ");
                    enhancement.enhancementEstimate = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Would you like to add a watcher (Y/N)? ");
                    char addWatcher = Console.ReadLine().ToUpper()[0];
                    
                    while (addWatcher == 'Y')
                    {
                        Console.Write("Enter the name of the watcher: ");
                        string addName = Console.ReadLine();
                        enhancement.enhancementWatchers.Add(addName);
                        Console.Write("Would you like to add another watcher (Y/N)? ");
                        addWatcher = Console.ReadLine().ToUpper()[0];
                    }
                    sw.WriteLine(enhancement.Display());
                    sw.Close();
                    Console.Write("Would you like to create another ticket (Y/N)? ");
                    choice = Console.ReadLine().ToUpper()[0];
                }

                else if (ticketType == 3)
                {
                    string file = "Task.csv";
                    StreamWriter sw = new StreamWriter(file);
                    Task task = new Task();

                    Console.Write("Enter a ticket number: ");
                    task.taskNumber = Console.ReadLine();
                    Console.Write("Enter a summary: ");
                    task.taskSummary = Console.ReadLine();
                    Console.Write("Enter a status: ");
                    task.taskStatus = Console.ReadLine();
                    Console.Write("Enter a priority: ");
                    task.taskPriority = Console.ReadLine();
                    Console.Write("Enter a submitter: ");
                    task.taskSubmitter = Console.ReadLine();
                    Console.Write("Enter an assigned to: ");
                    task.taskAssignedTo = Console.ReadLine();
                    Console.WriteLine("Please enter the project name: ");
                    task.taskProjectName = Console.ReadLine();
                    Console.WriteLine("Pleaser enter a due date (MM/DD/YY): ");
                    task.taskDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Would you like to add a watcher (Y/N)? ");
                    char addWatcher = Console.ReadLine().ToUpper()[0];
                    
                    while (addWatcher == 'Y')
                    {
                        Console.Write("Enter the name of the watcher: ");
                        string addName = Console.ReadLine();
                        task.taskWatchers.Add(addName);
                        Console.Write("Would you like to add another watcher (Y/N)? ");
                        addWatcher = Console.ReadLine().ToUpper()[0];
                    }
                    sw.WriteLine(task.Display());
                    sw.Close();
                    Console.Write("Would you like to create another ticket (Y/N)? ");
                    choice = Console.ReadLine().ToUpper()[0];
                }
                else if(ticketType != 1 && ticketType != 2 && ticketType != 3)
                {
                    Console.WriteLine("Incorrect entry, Please enter a correct number\n");
                }
            } 
        }
    }
}
