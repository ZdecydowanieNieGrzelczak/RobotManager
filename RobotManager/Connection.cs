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
            connection = new SqlConnection(connetionString);
            connection.Open();
            return connection.State == ConnectionState.Open;
        }

        public bool Close()
        {
            connection.Close();
            return connection.State == ConnectionState.Closed;
        }


        public RobotModel GetRobot(string robotName = "M4RK")
        {
            RobotModel tempRobot = new RobotModel();
            string query = "SELECT * FROM Robots WHERE RobotName = " + '\'' + 'M' + '4' + 'R' + 'K' + '\'' ;

            SqlDataReader dataReader;
            SqlCommand getCommand = new SqlCommand(query, connection);

            dataReader = getCommand.ExecuteReader();
            dataReader.Read();

            tempRobot.Name = robotName;
            tempRobot.GroupID = (int)dataReader.GetValue(2);

            

            return tempRobot;
        }

    }
}
