using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AmitaWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }

        private bool connection_open;
        private MySqlConnection connection;

        public Product()
        {

        }

        public Product(int arg_id)
        {
            Get_Connection();
            Id = arg_id;
            //    m_Person = new CPersonMaster();
            //  List<CPersonMaster> PersonList = new List<CPersonMaster>();
            //PersonList = CComs_PM.Fetch_PersonMaster(connection, 4, arg_id);

            //if (PersonList.Count==0)
            //  return "";

            //m_Person = PersonList[0];

            //DB_Connect.CloseTheConnection(connection);
            try
            {


                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText =
            string.Format("select commodityname) Productname from XXIBM_PRODUCT_CATALOGUE limit 0,10",
                                              Title);

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    reader.Read();

                    if (reader.IsDBNull(0) == false)
                        Title = reader.GetString(0);
                    else
                        Title = null;

                    
                    reader.Close();

                }
                catch (MySqlException e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                        + e.ErrorCode + " - " + e.Message + "; \n\nPlease Continue";
                    //MessageBox.Show(MessageString, "SQL Read Error");
                    reader.Close();
                    Title = MessageString;
                    //Address1 = Address2 = null;
                }
            }
            catch (MySqlException e)
            {
                string MessageString = "The following error occurred loading the Column details: "
                    + e.ErrorCode + " - " + e.Message;
                Title = MessageString;
                //Address1 = Address2 = null;
            }




            connection.Close();


        }

        private void Get_Connection()
        {
            connection_open = false;

            connection = new MySqlConnection();
            //connection = DB_Connect.Make_Connnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            //            if (db_manage_connnection.DB_Connect.OpenTheConnection(connection))
            if (Open_Local_Connection())
            {
                connection_open = true;
            }
            else
            {
                //					MessageBox::Show("No database connection connection made...\n Exiting now", "Database Connection Error");
                //					 Application::Exit();
            }

        }

        private bool Open_Local_Connection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

