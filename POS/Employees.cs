using System;
using System.ComponentModel;
using System.Data;
using System.Reflection.Metadata;
using Microsoft.Data.SqlClient;

namespace POS
{
    class Employees
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime HireDate { get; set; }
        private DateTime? complectionWork;
        public DateTime? ComplectionWork { 
            get { return complectionWork; } 
            set { if (value > HireDate)
            {
                complectionWork = value;
            }} }
        public required string Username { get; set; }


        public void ShowEmployee(string username)
        {
            Username = username;

            DBActions db = new DBActions();
            db.ExecuteStoredProcedureReader("ShowEmployeesInfoByUsername", 
            cmd => cmd.Parameters.AddWithValue("@Username", Username), 
            reader => 
            {
                if (reader.Read())
                {
                    Name = reader["Name"].ToString();
                    Surname = reader["Surname"].ToString();
                    HireDate = (DateTime)reader["Hire_Date"];
                    ComplectionWork = (DateTime)reader["Complection_Work"];
                }
                if (ComplectionWork != null)
                {
                    Console.WriteLine($"User: {Username}\nName: {Name}\nSurname: {Surname}\nHire date: {HireDate}");
                    Console.WriteLine($"User {Username} has been finished work at {ComplectionWork}");
                }
                else
                {
                    Console.WriteLine($"User: {Username}\nName: {Name}\nSurname: {Surname}\nHire date: {HireDate}");
                }

            });
        }
    }
}