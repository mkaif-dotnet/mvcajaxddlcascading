using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using mvcajaxddlcascading.Models;
using Newtonsoft.Json;

namespace mvcajaxddlcascading.Controllers
{
    public class StudentController : Controller
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-6DK8V12M\\MSSQLSERVER01; initial catalog=db_27625; integrated security=true");
        
        public ActionResult StudentForm()
        {
            return View();
        }
        public void InsertData(StudentModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert_student", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@studentname", obj.studentname);
            cmd.Parameters.AddWithValue("@studentage", obj.studentage);
            cmd.Parameters.AddWithValue("@country", obj.Country);
            cmd.Parameters.AddWithValue("@state", obj.State);
            cmd.Parameters.AddWithValue("@city", obj.City);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateData(StudentModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update_student", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@studentname", obj.studentname);
            cmd.Parameters.AddWithValue("@studentage", obj.studentage);
            cmd.Parameters.AddWithValue("@studentid", obj.studentid);
            cmd.Parameters.AddWithValue("@country", obj.Country);
            cmd.Parameters.AddWithValue("@state", obj.State);
            cmd.Parameters.AddWithValue("@city", obj.City);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public JsonResult ShowData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("show_student", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ShowCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from tblcountry", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ShowState(int A)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from tblstate where countryid='"+A+"'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ShowCity(int A)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from tblcity where stateid='" + A + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditData(StudentModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("edit_student", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@studentid",obj.studentid);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public void RemoveData(StudentModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete_student", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@studentid", obj.studentid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}