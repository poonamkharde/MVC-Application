using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLoginApplication.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MVCLoginApplication.pcClass
{
    public class pcClsExamCenter
    {
        public static int pcFillddlDistrict(ref List<SelectListItem> oInddlDistrict)
        {
            int intRecFound = 0;

            string ConnectionString = "Data Source = 20.235.106.35\\PCCENTERDB; Initial Catalog = MYPCMSCITOES; User Id = pcmscit; Password = Pcmscit@987#;";

            //ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            string selectData = "select ROW_NUMBER() OVER (ORDER BY District ASC) AS SrNo,  District from  TBLEEXAMCENTER group by  District ";

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = selectData;
            
            reader= cmd.ExecuteReader();

            oInddlDistrict.Clear();
            if (oInddlDistrict.Count==0)
            {
                oInddlDistrict.Add(new SelectListItem
                {
                    Text = "Select All",
                    Value = "0",
                    Selected = false
                });
            }
            while(reader.Read())
            {
                oInddlDistrict.Add(new SelectListItem
                {
                    Text = reader["District"].ToString().Trim(),
                    Value = reader["SrNo"].ToString(),
                    Selected = false,
                });
            }
            reader.Close();

            return intRecFound;
        }
    }
}