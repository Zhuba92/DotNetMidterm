using System;
using System.IO;
using System.Collections.Generic;
using NLog.Web;
using System.Linq;

namespace MidTerm
{
    class Program 
    {
        static void Main(string[] args)
        {
            Ticket ticket = new Ticket();
            Enhancements enhancement = new Enhancements();
            Task task = new Task();

            List<String> enhancementList = new List<string>();

            string enhancementsFile = "Enhancements.csv";
            StreamReader sr1 = new StreamReader(enhancementsFile);
            while(!sr1.EndOfStream)
            {
                string enhancementInfo = sr1.ReadLine();
                string[] enhancementInfoSplit = enhancementInfo.Split(",");
                string ticketID = enhancementInfoSplit[0];
                enhancementList.Add(ticketID);
                string summary = enhancementInfoSplit[1];
                enhancementList.Add(summary);
                string status = enhancementInfoSplit[2];
                enhancementList.Add(status);
                string priority = enhancementInfoSplit[3];
                enhancementList.Add(priority);
                string submitter = enhancementInfoSplit[4];
                enhancementList.Add(submitter);
                string assigned = enhancementInfoSplit[5];
                enhancementList.Add(assigned);
                string[] watching = enhancementInfoSplit[6].Split("|");
                for(int i = 0; i < watching.Length; i++)
                {
                    if(i < watching.Length - 1)
                    {
                        enhancementList.Add(watching[i] + ", ");
                    }
                    else
                    {
                        enhancementList.Add(watching[i]);
                    }
                }
                string software = enhancementInfoSplit[7];
                enhancementList.Add(software);
                string cost = enhancementInfoSplit[8];
                enhancementList.Add(cost);
                string reason = enhancementInfoSplit[9];
                enhancementList.Add(reason);
                string estimate = enhancementInfoSplit[10];
                enhancementList.Add(estimate);
            }
            sr1.Close();

            List<String> ticketList = new List<string>();
            string ticketFile = "Tickets.csv";
            StreamReader sr2 = new StreamReader(ticketFile);
            while(!sr2.EndOfStream)
            {
                string ticketInfo = sr2.ReadLine();
                string[] ticketInfoSplit = ticketInfo.Split(",");
                string ticketID = ticketInfoSplit[0];
                ticketList.Add(ticketID);
                string summary = ticketInfoSplit[1];
                ticketList.Add(summary);
                string status = ticketInfoSplit[2];
                ticketList.Add(status);
                string priority = ticketInfoSplit[3];
                ticketList.Add(priority);
                string submitter = ticketInfoSplit[4];
                ticketList.Add(submitter);
                string assigned = ticketInfoSplit[5];
                ticketList.Add(assigned);
                string[] watching = ticketInfoSplit[7].Split("|");
                for(int i = 0; i < watching.Length; i++)
                {
                    if(i < watching.Length - 1)
                    {
                        ticketList.Add(watching[i] + ", ");
                    }
                    else
                    {
                        ticketList.Add(watching[i]);
                    }
                }
                string severity = ticketInfoSplit[6];
                ticketList.Add(severity);
            }
            sr2.Close();

            List<String> taskList = new List<string>();
            string taskFile = "Task.csv";
            StreamReader sr3 = new StreamReader(taskFile);
            while(!sr3.EndOfStream)
            {
                string taskInfo = sr3.ReadLine();
                string[] taskSplit = taskInfo.Split(",");
                string taskID = taskSplit[0];
                taskList.Add(taskID);
                string summary = taskSplit[1];
                taskList.Add(summary);
                string status = taskSplit[2];
                taskList.Add(status);
                string priority = taskSplit[3];
                taskList.Add(priority);
                string submitter = taskSplit[4];
                taskList.Add(submitter);
                string assigned = taskSplit[5];
                taskList.Add(assigned);
                string[] watching = taskSplit[8].Split("|");
                for(int i = 0; i < watching.Length; i++)
                {
                    if(i < watching.Length - 1)
                    {
                        taskList.Add(watching[i] + ", ");
                    }
                    else
                    {
                        taskList.Add(watching[i]);
                    }
                }
                string projectName = taskSplit[6];
                taskList.Add(projectName);
                string dueDate = taskSplit[7];
                taskList.Add(dueDate);
            }
            sr3.Close();

            Console.WriteLine("Please enter the number of what you would like to do: \n1. Search for a ticket\n2. Create a ticket ");
            int firstChoice = Int32.Parse(Console.ReadLine());

            if(firstChoice == 2)
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

            else if(firstChoice == 1)
            {
                Console.WriteLine("Which would you like to search by:\n1. Status\n2. Priority\n3. Submitter");
                int searchBy = Int32.Parse(Console.ReadLine());

                if(searchBy == 1)
                {
                    // using "in progress to test
                    Console.Write("What status would you like to search for: ");
                    string status = Console.ReadLine();
                    IEnumerable<String> searchedStatus = enhancementList.Where(s => s.Contains(status));
                    IEnumerable<String> searchedStatus1 = ticketList.Where(s => s.Contains(status));
                    IEnumerable<String> searchedStatus2 = taskList.Where(s => s.Contains(status));
                    Console.WriteLine($"There are {searchedStatus.Count() + searchedStatus1.Count() + searchedStatus2.Count()} tickets that have a status of: {status}\n");
                    foreach(String s in searchedStatus)
                    {
                        Console.WriteLine(s);
                    }
                    foreach(String s in searchedStatus1)
                    {
                        Console.WriteLine(s);
                    }
                    foreach(String s in searchedStatus2)
                    {
                        Console.WriteLine(s);
                    }   
                }
                else if(searchBy == 2)
                {
                    // using "high" to test
                    Console.Write("What Priority would you like to search for: ");
                    string priority = Console.ReadLine();
                    IEnumerable<String> searchedPrio = enhancementList.Where(s => s.Contains(priority));
                    IEnumerable<String> searchedPrio1 = ticketList.Where(s => s.Contains(priority));
                    IEnumerable<String> searchedPrio2 = taskList.Where(s => s.Contains(priority));
                    Console.WriteLine($"There are {searchedPrio.Count() + searchedPrio1.Count() + searchedPrio2.Count()} tickets that have a priority of: {priority}\n");
                    foreach(String s in searchedPrio)
                    {
                        Console.WriteLine(s);
                    }
                    foreach(String s in searchedPrio1)
                    {
                        Console.WriteLine(s);
                    }
                    foreach(String s in searchedPrio2)
                    {
                        Console.WriteLine(s);
                    }
                }
                else if(searchBy == 3)
                {
                    // using "high" to test
                    Console.Write("What Submitter would you like to search for: ");
                    string submitter = Console.ReadLine();
                    IEnumerable<String> searchedSubmitter = enhancementList.Where(s => s.Contains(submitter));
                    IEnumerable<String> searchedSubmitter1 = ticketList.Where(s => s.Contains(submitter));
                    IEnumerable<String> searchedSubmitter2 = taskList.Where(s => s.Contains(submitter));
                    Console.WriteLine($"There are {searchedSubmitter.Count() + searchedSubmitter1.Count() + searchedSubmitter2.Count()} tickets that were submitted by {submitter}\n");
                    foreach(String s in searchedSubmitter)
                    {
                        Console.WriteLine(s);
                    }
                    foreach(String s in searchedSubmitter1)
                    {
                        Console.WriteLine(s);
                    }
                    foreach(String s in searchedSubmitter2)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
        }
    }
}
