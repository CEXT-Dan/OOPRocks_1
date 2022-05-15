using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace OOPRocks
{
    [Serializable]
    public class Database : ISerializable
    {
        public List<DbObject> DbObjects = new List<DbObject>();

        public Database()
        {
        }
        public Database(SerializationInfo info, StreamingContext context)
        {
            DbObjects = info.GetValue("DbObjects", typeof(List<DbObject>)) as List<DbObject>;
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DbObjects", DbObjects, typeof(List<DbObject>));
        }

        

    }
}
