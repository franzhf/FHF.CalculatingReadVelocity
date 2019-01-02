using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CRV.CoreComponent;
using TrackerActivity.ManageRunningActivity;
using System.Xml.Serialization;

namespace TrackerActivity.DataAccess
{
    public class XMLDataProvider<T> : IDataProvider<ExecutableActivity> where T: ExecutableActivity, new()
    {
        string path;
        public XMLDataProvider()
        {
            path = @"F:\LocalRepositories\FHF.CalculatingReadVelocity\ExecutableActivityFolder\";
        }

        public ExecutableActivity ReadAll()
        {
            throw new NotImplementedException();
        }

        public ExecutableActivity Read(Guid ID)
        {
            ExecutableActivity activity = new T();

            using (var stream = File.OpenRead(path))
            {
                // mapping data
                
            }
            return activity;
        }

        public void Write(ExecutableActivity item)
        {
            // Create a file to write to.
            using (FileStream stream = new FileStream(path + item.ID, FileMode.Append))
            {
                XmlSerializer serializer = new XmlSerializer(item.GetType());
                serializer.Serialize(stream, item);
            }
        }

        public void WriteAll(List<ExecutableActivity> items)
        {
            throw new NotImplementedException();
        }
    }
}
