using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MVCLoginApplication.Models;
using System.Security.Policy;

namespace MVCLoginApplication.pcClassCopy
{
    public class pcExamCenterListClass
    {
        public static int pcFillDistrictList(ref List<SelectListItem> oInddlDistrictList)
        {
            int intRecFound = 0;

            string ConnectionString = "Data Source = 20.235.106.35\\PCCENTERDB; Initial Catalog = MYPCMSCITOES; User Id = pcmscit; Password = Pcmscit@987#;";
            SqlConnection conn=new SqlConnection(ConnectionString);
            conn.Open();
            string selectData = "select ROW_NUMBER() OVER (ORDER BY District ASC) AS SrNo,  District from  TBLEEXAMCENTER group by  District ";
            SqlCommand cmd = new SqlCommand();
            
            SqlDataReader reader = null;
            cmd.Connection = conn;
            cmd.CommandType=System.Data.CommandType.Text;
            cmd.CommandText = selectData;
            reader= cmd.ExecuteReader();

            oInddlDistrictList.Clear();
            if (oInddlDistrictList.Count == 0)
            {
                oInddlDistrictList.Add(new SelectListItem()
                {
                    Text = "Select All",
                    Value= "Select All",
                    Selected=false,
                }) ;
                
            }
            while (reader.Read())
            {
                oInddlDistrictList.Add(new SelectListItem
                {
                    Text = reader["District"].ToString().Trim(),
                    Value = reader["District"].ToString(),
                    Selected=false,
                });
            };
            reader.Close();
            conn.Close();
            return intRecFound;
        }

        public static List<pcExamCenterList> pcExamCenterListData(string strDistrictNm,string strFilterNm)
        {
            List<pcExamCenterList> gvExamCenterList= new List<pcExamCenterList>();

            string ConnectionStringNew = "Data Source = 20.235.106.35\\PCCENTERDB; Initial Catalog = MYPCMSCITOES; User Id = pcmscit; Password = Pcmscit@987#;";
            SqlConnection conn = new SqlConnection(ConnectionStringNew);            
                           
            conn.Open();
            string selectData = "";
            if (strDistrictNm == "Select All")
            {
                selectData = "select Center_Code,Center_Name,Center_Address,Phone from TBLEEXAMCENTER";
            }
            else
            {
                selectData = "select Center_Code,Center_Name,Center_Address,Phone from TBLEEXAMCENTER where District = '" + strDistrictNm + "'";
            }
            SqlCommand cmd = new SqlCommand();

            SqlDataReader reader = null;
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = selectData;
            reader = cmd.ExecuteReader();

            if(reader != null)
            {
                while (reader.Read())
                {
                    pcExamCenterList opcExamCenterList=new pcExamCenterList();

                    opcExamCenterList.txtCenterCode = reader["Center_Code"].ToString();
                    opcExamCenterList.txtCenterName= reader["Center_Name"].ToString();
                    opcExamCenterList.txtCenterAddress= reader["Center_Address"].ToString();
                    opcExamCenterList.txtTelephoneNo = reader["Phone"].ToString();

                    gvExamCenterList.Add(opcExamCenterList);

                }
            }
            reader.Close();
            conn.Close();
            return gvExamCenterList;
        }
        
    }

}