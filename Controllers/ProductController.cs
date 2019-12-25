using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using dto = AmitaWebApp.Models;

namespace AmitaWebApp.Controllers
{
    public class ProductController : Controller
    {
        private MySqlDatabase MySqlDatabase { get; set; }
        public ProductController(MySqlDatabase mySqlDatabase)
        {
            this.MySqlDatabase = mySqlDatabase;
        }

        [HttpPost]
        public void Complete(dto.Product input)
        {
            var cmd = this.MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"select   * from XXIBM_PRODUCT_CATALOGUE limit 0,10;";
            //cmd.Parameters.AddWithValue("@TaskId", input.TaskId);
            //cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy/MM/dd"));

            var recs = cmd.ExecuteNonQuery();
        }
        
    }
}
