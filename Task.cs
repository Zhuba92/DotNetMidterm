using System; 
using System.Collections.Generic;

namespace MidTerm
{
    public class Task
    {
        public string taskNumber {get; set;}
        public string taskSummary {get; set;}
        public string taskStatus {get; set;}
        public string taskPriority {get; set;}
        public string taskSubmitter {get; set;}
        public string taskAssignedTo {get; set;}
        public string taskSeverity {get; set;}
        public string taskProjectName {get; set;}
        public DateTime taskDate {get; set;}
        public List<string> taskWatchers {get; set;}

        public Task()
        {
            taskWatchers = new List<string>();
        }

        public string displayTaskNames()
        {
            string names = "";
            for (int i = 0; i < taskWatchers.Count; i++)
            {
                if (i < taskWatchers.Count - 1)
                {
                    names += taskWatchers[i] + "|";
                }
                else names += taskWatchers[i];
            }
            return names;
        }

        public string Display()
        {
            return $"{taskNumber},{taskSummary},{taskStatus},{taskPriority},{taskSubmitter},{taskAssignedTo},{taskProjectName},{taskDate},{displayTaskNames()}";
        }
    }
}
