using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace OOPRocks
{
    public class Application
    {
        //In this example we can save the state of our program and reconstruct it.
        //It's possible to save the state of the entire program, User variables, Fonts, Game Layout etc.
        //The classes are reconstructed and ready to go.
        //Challenge, do this without using oop.

        internal static void Main(string[] args)
        {
            string fileName = "E:\\TestSerialize.dat";

            //this can be soap or xml;
            var formatter = new BinaryFormatter();

            {//scope
                //create a database;
                Database db = createDatabase();

                // do your changes with the database, add objects;
                SaveDatabase(fileName, db, formatter);
            }

            {  //scope so we know the previous instance of db is dead

                //reconstruct the database class
                Database db = OpenDatabase(fileName, formatter);

                //print out the data

                foreach (var item in db.DbObjects)
                {
                    Console.WriteLine("Type={0}, Data={1}", item.GetType().Name, item.ToString());
                }
            }
        }
        internal static Database createDatabase()
        {
            Database db = new Database();
            {
                DbPoint pt = new DbPoint();
                pt.ObjectId = 1;
                pt.Position = new Point3d(10, 10, 0);
                db.DbObjects.Add(pt);
            }

            {
                DbPoint pt = new DbPoint();
                pt.ObjectId = 2;
                pt.Position = new Point3d(100, 100, 0);
                db.DbObjects.Add(pt);
            }

            {
                DbLine line = new DbLine();
                line.ObjectId = 3;
                line.StartPoint = new Point3d(100, 100, 0);
                line.EndPoint = new Point3d(10, 10, 0);
                db.DbObjects.Add(line);
            }

            {
                DbLine line = new DbLine();
                line.ObjectId = 4;
                line.StartPoint = new Point3d(10, 10, 0);
                line.EndPoint = new Point3d(100, 100, 0);
                db.DbObjects.Add(line);
            }

            {
                DbCircle circle = new DbCircle();
                circle.ObjectId = 5;
                circle.Position= new Point3d(1.001, 0, 0);
                circle.Radius = 10.5;
                db.DbObjects.Add(circle);
            }

            {
                DbCircle circle = new DbCircle();
                circle.ObjectId = 6;
                circle.Position = new Point3d(4.001, 0, 0);
                circle.Radius = 110.5;
                db.DbObjects.Add(circle);
            }
            return db;
        }

        internal static Database OpenDatabase(string filePath, IFormatter formatter)
        {
            FileStream s = new FileStream(filePath, FileMode.Open);
            Database db = (Database)formatter.Deserialize(s);
            s.Close();
            return db;
        }

        internal static void SaveDatabase(string filePath, Database db, IFormatter formatter)
        {
            FileStream s = new FileStream(filePath, FileMode.Create);
            formatter.Serialize(s, db);
            s.Close();
        }
    }
}