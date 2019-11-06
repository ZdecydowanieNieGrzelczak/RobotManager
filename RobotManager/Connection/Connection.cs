using RobotManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public SqlConnection Connection;



        public SQLMediator(string userName= "tmedp_user" , string password="Tme12345", string target="HARADEV", string initialCatalog="praktyka")
        {
            UserName = userName;
            Password = password;
            Target = target;
            InitialCatalog = initialCatalog;
        }

        public bool Connect()
        {

            string connetionString = @"Data Source=" + Target + ";Initial Catalog=" + InitialCatalog + ";User ID=" + UserName + ";Password=" + Password;
            Connection = new SqlConnection(connetionString);
            Connection.Open();
            return Connection.State == ConnectionState.Open;
        }

        public bool Close()
        {
            Connection.Close();
            return Connection.State == ConnectionState.Closed;
        }




        public void GetSkillsList(ObservableCollection<RobotModel> robots)
        {
            foreach(RobotModel robot in robots)
            {
                List<Skill> skillList = new List<Skill>();

                SqlDataReader dataReader;
                SqlCommand getCommand = new SqlCommand("dbo.ExctractRobotSkillsByName", Connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                getCommand.Parameters.Add(new SqlParameter("@RobotName", robot.Name));

                dataReader = getCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    skillList.Add(new Skill((string)dataReader.GetValue(0), Int2BoolConverter((int)dataReader.GetValue(1))));
                }

                dataReader.Close();
                robot.SkillsList = skillList;
            }
            


        }


        public void GetFeatureList(ObservableCollection<RobotModel> robotList)
        {
            
            foreach(RobotModel robot in robotList)
            {
                List<Feature> getFeatureList = new List<Feature>();

                SqlDataReader dataReader;
                SqlCommand getCommand = new SqlCommand("dbo.ExctractRobotFeaturesByName", Connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                getCommand.Parameters.Add(new SqlParameter("@RobotName", robot.Name));

                

                dataReader = getCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    getFeatureList.Add(new Feature((string)dataReader.GetValue(0), (int)dataReader.GetValue(1)));
                }

                robot.FeaturesList = getFeatureList;
                dataReader.Close();
            }
            
        }

        public bool DeleteRobot(string robotName)
        {


            SqlCommand deleteCommand = new SqlCommand("dbo.DeleteRobot", Connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            deleteCommand.Parameters.Add(new SqlParameter("@RobotName", robotName));

            if(deleteCommand.ExecuteNonQuery() == 0)
            {
                return false;
            }

            return true;
        }


        public List<string> GetGroupsList()
        {
            List<string> groups = new List<string>();

            string query = "SELECT GroupName FROM Groups";


            SqlDataReader dataReader;
            SqlCommand getCommand = new SqlCommand(query, Connection);

            dataReader = getCommand.ExecuteReader();
            while (dataReader.Read())
            {
                groups.Add((string)(dataReader.GetValue(0)));
            }

            dataReader.Close();
            return groups;
        }


        public ObservableCollection<RobotModel> GetRobots()
        {
            ObservableCollection<RobotModel> robotList = new ObservableCollection<RobotModel>();






            if (Connection.State != ConnectionState.Open)
            {
                if (!Connect())
                {
                    Console.Write("cannont connect to database");
                    this.Close();
                    return null;
                }
            }

            List<string> groups = GetGroupsList();



            string query = "SELECT RobotName, GroupName, GroupID FROM Robots INNER JOIN Groups ON Groups.ID = Robots.GroupID";


            SqlDataReader robotReader;
            SqlCommand getCommand = new SqlCommand(query, Connection);

            robotReader = getCommand.ExecuteReader();
            while (robotReader.Read())
            {
                robotList.Add(new RobotModel((string)robotReader.GetValue(0), (string)robotReader.GetValue(1), (int)robotReader.GetValue(2), groups));
            }

            robotReader.Close();

            GetFeatureList(robotList);
            GetSkillsList(robotList);


            return robotList;
        }

        public void ModifyOrAddRobot(RobotModel updatedRobot, string procedureName)
        {


            SqlCommand ModifyCommand = new SqlCommand(procedureName, Connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            DataTable FeatureTable = new DataTable();
            FeatureTable.Columns.Add("FeatureName", typeof(string));
            FeatureTable.Columns.Add("Magnitude", typeof(int));

            DataTable SkillTable = new DataTable();
            SkillTable.Columns.Add("SkillName", typeof(string));
            SkillTable.Columns.Add("Possible", typeof(int));


            foreach(Skill skill in updatedRobot.SkillsList)
            {
                SkillTable.Rows.Add(skill.Name, skill.IsPossible);
            }
            foreach(Feature feat in updatedRobot.FeaturesList)
            {
                FeatureTable.Rows.Add(feat.Name, feat.Magnitude);
            }

            ModifyCommand.Parameters.Add(new SqlParameter("@RobotName", updatedRobot.Name));
            ModifyCommand.Parameters.Add(new SqlParameter("@GroupName", updatedRobot.GroupName));
            ModifyCommand.Parameters.Add(new SqlParameter("@FeatureTable", FeatureTable));
            ModifyCommand.Parameters.Add(new SqlParameter("@SkillTable", SkillTable));


            ModifyCommand.ExecuteNonQuery();
        }

        public bool Int2BoolConverter(int value)
        {
            return value == 1;
        }

    }
 
}
