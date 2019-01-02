using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRV.CoreComponent
{
    // The null object pattern
    // Its purpose is to allow you to avoid throwing a NullReference-Exception 
    // and writing a plethora of null object checking code.
    [Serializable]
    public class NullActivity : IActivity
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Session DemandSession { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Session SessionSettings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int demandOfSessions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void CalculateDemandTime()
        {
            throw new Exception("There is not activity type");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
        }
    }
}
