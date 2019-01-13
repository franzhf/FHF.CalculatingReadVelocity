using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TrackerActivity.Domain.Activity
{
    public interface IActivity
    {
        string Name { get; set; }        
        Session  DemandSession { get; } 
        Session SessionSettings { get; set; }
        int demandOfSessions { get; set; }
        void CalculateDemandTime();
        
    }
}
