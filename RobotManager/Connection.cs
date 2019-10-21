using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotManager
{
    public class SQLMediator
    {
        public string UserName;
        public string Password;
        public string Target;
        public string InitialCatalog;
        public SqlConnection connection;
        public string[] TableNames;


        public SQLMediator(string userName= "tmedp_user" , string password="Tme12345", string target="HARADEV", string initialCatalog="praktyka")
        {
            UserName = userName;
            Password = password;
            Target = target;
            InitialCatalog = initialCatalog;
            TableNames = new string[] { "RobotsXFeatures", "RobotsXSkills" };
        }

        public bool Connect()
        {

            string connetionString = @"Data Source=" + Target + ";Initial Catalog=" + InitialCatalog + ";User ID=" + UserName + ";Password=" + Password;
            connection = new SqlConnection(connetionString);
            connection.Open();
            return connection.State == ConnectionState.Open;
        }

        public bool Close()
        {
            connection.Close();
            return connection.State == ConnectionState.Closed;
        }


        public List<T> getTableAsList<T>(string tableName, string robotName, Func<string, T> converter)
        {
            List<T> list = new List<T>();

            string query = "SELECT * FROM " + '\'' + tableName + '\'';



            SqlDataReader dataReader;
            SqlCommand getCommand = new SqlCommand(query, connection);

            dataReader = getCommand.ExecuteReader();


            while (dataReader.Read())
            {
                list.Add(converter((string)dataReader.GetValue(1)));
            }
            return list;
        }



        //public List<Skill> getSkillsList()
        //{
        //    List<Skill> skillList = new List<Skill>();

        //    string query = "SELECT * FROM Skills";

        //    SqlDataReader dataReader;
        //    SqlCommand getCommand = new SqlCommand(query, connection);

        //    dataReader = getCommand.ExecuteReader();
        //    while (dataReader.Read())
        //    {
        //        skillList.Add(new Skill((string)dataReader.GetValue(1), false));
        //    }

        //    return skillList;

        //}

        //public List<Feature> getFeatureList()
        //{
        //    List<Feature> getFeatureList = new List<Feature>();

        //    string query = "SELECT * FROM Features";

        //    SqlDataReader dataReader;
        //    SqlCommand getCommand = new SqlCommand(query, connection);

        //    dataReader = getCommand.ExecuteReader();
        //    while (dataReader.Read())
        //    {
        //        getFeatureList.Add(new Feature((string)dataReader.GetValue(1), 0));
        //    }

        //    return getFeatureList;
        //}

        public bool DeleteRobot(string robotName)
        {
            foreach(string tableName in TableNames)
            {
                string query = "DELETE FROM " + tableName + " WHERE RobotID = (SELECT ID FROM Robots WHERE RobotName =" + '\'' + robotName + '\'' + ")"; ;
                SqlCommand deleteCommand = new SqlCommand(query, connection);
                deleteCommand.ExecuteNonQuery();
            }

            SqlCommand deleteRobot = new SqlCommand(("DELETE FROM Robots WHERE RobotName = " + '\'' + robotName + '\''), connection);
            deleteRobot.ExecuteNonQuery();

            return true;
        }



        public RobotModel GetRobot(string robotName = "M4RK")
        {
            RobotModel tempRobot = new RobotModel();


            string query = "SELECT * FROM Robots WHERE RobotName = " + '\'' + robotName + '\'' ;

            SqlDataReader dataReader;
            SqlCommand getCommand = new SqlCommand(query, connection);

            dataReader = getCommand.ExecuteReader();
            dataReader.Read();

            tempRobot.Name = robotName;
            tempRobot.GroupID = (int)dataReader.GetValue(2);

            

            return tempRobot;
        }

        public List<RobotModel> GetRobots()
        {
            List<RobotModel> robotList = new List<RobotModel>();


            //string query = "SELECT * FROM Robots WHERE RobotName = " + '\'' + robotName + '\'';

            SqlDataReader dataReader;
            SqlCommand getCommand = new SqlCommand(query, connection);

            dataReader = getCommand.ExecuteReader();
            dataReader.Read();

            tempRobot.Name = robotName;
            tempRobot.GroupID = (int)dataReader.GetValue(2);



            return robotList;
        }

    }
}
