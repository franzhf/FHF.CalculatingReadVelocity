using System;
using System.Collections.Generic;
using CRV.CoreComponent;

namespace TrackerActivity.DataAccess
{
    public interface IDataProvider<T>
    {
        T ReadAll();
        T Read(Guid ID);
        void Write(T item);
        void WriteAll(List<T> items);
    }
}
