using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace OOPRocks
{
    [Serializable]
    public struct Point3d : ISerializable
    {

        public double x = 0;
        public double y = 0;
        public double z = 0;

        public Point3d()
        {
        }
        public Point3d(double _x, double _y, double _z)
        {
            this.x = _x;
            this.y = _y;
            this.z = _z;
        }

        public Point3d(SerializationInfo info, StreamingContext context)
        {
            x = (double)info.GetValue("Point3d.x", typeof(double));
            y = (double)info.GetValue("Point3d.y", typeof(double));
            z = (double)info.GetValue("Point3d.z", typeof(double));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Point3d.x", x, typeof(double));
            info.AddValue("Point3d.y", y, typeof(double));
            info.AddValue("Point3d.z", z, typeof(double));
        }

        public override string ToString()
        {
            return string.Format("({0},{1},{2})", x, y, z);
        }
    }

    [Serializable]
    public class DbObject : ISerializable
    {
        public int ObjectId { get; set; } = -1;

        public DbObject()
        {
        }

        public DbObject(SerializationInfo info, StreamingContext context)
        {
            ObjectId = (int)info.GetValue("DbObject.ObjectId", typeof(int));
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DbObject.ObjectId", ObjectId, typeof(int));
        }

        public override string ToString()
        {
            return ObjectId.ToString();
        }

    }

    [Serializable]
    public class DbDrawable : DbObject
    {
        public DbDrawable()
        {

        }
        public DbDrawable(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }


    [Serializable]
    public class DbPoint : DbDrawable
    {
        public Point3d Position { get; set; }

        public DbPoint()
        {
            Position = new Point3d(0, 0, 0);
        }

        public DbPoint(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Position = (Point3d)info.GetValue("DbPoint.Position", typeof(Point3d));
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("DbPoint.Position", Position, typeof(Point3d));
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", base.ToString(), Position.ToString());
        }
    }

    [Serializable]
    public class DbLine : DbDrawable
    {
        public Point3d StartPoint { get; set; } = new Point3d(0, 0, 0);
        public Point3d EndPoint { get; set; } = new Point3d(0, 0, 0);

        public DbLine()
        {

        }

        public DbLine(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            StartPoint = (Point3d)info.GetValue("DbLine.StartPoint", typeof(Point3d));
            EndPoint = (Point3d)info.GetValue("DbLine.EndPoint", typeof(Point3d));
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("DbLine.StartPoint", StartPoint, typeof(Point3d));
            info.AddValue("DbLine.EndPoint", EndPoint, typeof(Point3d));
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", base.ToString(), StartPoint.ToString(), EndPoint.ToString());
        }
    }

    [Serializable]
    public class DbCircle : DbDrawable
    {
        public Point3d Position { get; set; } = new Point3d(0, 0, 0);
        public double Radius { get; set; } = 1.0;


        public DbCircle()
        {

        }

        public DbCircle(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Position = (Point3d)info.GetValue("DbCircle.Position", typeof(Point3d));
            Radius = (double)info.GetValue("DbCircle.Radius", typeof(double));
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("DbCircle.Position", Position, typeof(Point3d));
            info.AddValue("DbCircle.Radius", Radius, typeof(double));
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", base.ToString(), Position.ToString(), Radius.ToString());
        }
    }

}
