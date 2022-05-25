using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FinalPro.Models;
using System.IO;
using System.Data;
using Microsoft.Extensions.Configuration;


namespace FinalPro.DAL
{
    public class Pro
    {
        public string cnn = "";
        public Pro()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:Conn").Value;
        }
    public List<Schedule> cancelapp()
    {
        List<Schedule> listCustomer = new List<Schedule>();
        using (SqlConnection con = new SqlConnection(cnn))
        {
            using (SqlCommand cmd = new SqlCommand("Selectee", con))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listCustomer.Add(new Schedule()
                    {
                        PatientID = int.Parse(reader["PatientID"].ToString()),
                        Specialization = reader["Specialization"].ToString(),
                        Doctor= reader["Doctor"].ToString(),
                        VisitDate = reader["VisitDate"].ToString(),
                        AppointmentTime = reader["AppointmentTime"].ToString(),
                    });
                }

            }
        }
        return listCustomer;
    }

        
        public int DoctorAd(AddDoctor AD)
        {
            int result;
            SqlConnection conn = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("doctor", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fname", AD.FirstName);
            cmd.Parameters.AddWithValue("@lname", AD.LastName);
            cmd.Parameters.AddWithValue("@sex", AD.Sex);
            cmd.Parameters.AddWithValue("@sp", AD.Specialization);
            cmd.Parameters.AddWithValue("@vh", AD.VisitingHours);
            conn.Open();
            result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public int PatientAD(AddPatient AD)
        {
            int result;
            SqlConnection conn = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Patient", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fname", AD.FirstName);
            cmd.Parameters.AddWithValue("@lname", AD.LastName);
            cmd.Parameters.AddWithValue("@sex", AD.Sex);
            cmd.Parameters.AddWithValue("@age", AD.Age);
            cmd.Parameters.AddWithValue("@dob", AD.DOB);
            conn.Open();
            result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;

        }
        public int SchedAD(Schedule AD)
        {
            int result;
            SqlConnection conn = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Sche", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", AD.PatientID);
            cmd.Parameters.AddWithValue("@sp", AD.Specialization);
            cmd.Parameters.AddWithValue("@Doc", AD.Doctor);
            cmd.Parameters.AddWithValue("@vd", AD.VisitDate);
            cmd.Parameters.AddWithValue("@app", AD.AppointmentTime);
            conn.Open();
            result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;

        }
        public int CheckUse(Login us)
        {
            SqlConnection conn = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("usertab",conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@un", us.UserName);
            cmd.Parameters.AddWithValue("@ps", us.Password);
            conn.Open();
            IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return (1);

            conn.Close();
            return (0);
        }
        public int DeleteData(Schedule cus)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("cancelapp", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@patientid", cus.PatientID);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


    }
}
