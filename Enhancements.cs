using System; 
using System.Collections.Generic;

namespace MidTerm
{
    public class Enhancements
    {
        public string enhancementNumber {get; set;}
        public string enhancementSummary {get; set;}
        public string enhancementStatus {get; set;}
        public string enhancementPriority {get; set;}
        public string enhancementSubmitter {get; set;}
        public string enhancementAssignedTo {get; set;}
        public string enhancementSoftware {get; set;}
        public double enhancementCost {get; set;}
        public string enhancementReason {get; set;}
        public double enhancementEstimate {get; set;}
        public List<string> enhancementWatchers {get; set;}

        public Enhancements()
        {
            enhancementWatchers = new List<string>();
        }

        public string displayEnhancementNames()
        {
            string names = "";
            for (int i = 0; i < enhancementWatchers.Count; i++)
            {
                if (i < enhancementWatchers.Count - 1)
                {
                    names += enhancementWatchers[i] + "|";
                }
                else names += enhancementWatchers[i];
            }
            return names;
        }

        public string Display()
        {
            return $"{enhancementNumber},{enhancementSummary},{enhancementStatus},{enhancementPriority},{enhancementSubmitter},{enhancementAssignedTo},{enhancementSoftware},${enhancementCost},{enhancementReason},${enhancementEstimate},{displayEnhancementNames()}";
        }
    }
}
