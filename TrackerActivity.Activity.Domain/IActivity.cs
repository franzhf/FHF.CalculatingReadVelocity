using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace CRV.CoreComponent
{
    public interface IActivity
    {
        string Name { get; set; }
        Guid ID { get; }
        Session  DemandSession { get; } 
        Session SessionSettings { get; set; }
        int demandOfSessions { get; set; }
        void CalculateDemandTime();
        
    }
}
