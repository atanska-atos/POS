using System;
using System.ComponentModel;
using System.Data;
using System.Reflection.Metadata;
using Microsoft.Data.SqlClient;

namespace POS
{
    class EmployeeManager
    {
        public void AddEmployee(Employees emp)
        {
            DBActions db = new DBActions();
            try{
                db.ExecuteStoredProcedureVoid("AddEmployee", cmd => 
                cmd.Parameters.AddRange(new SqlParameter[] {
                    new SqlParameter("@Name", emp.Name),
                    new SqlParameter("@Surname", emp.Surname),
                    new SqlParameter("@Hire_Date", DateTime.Now),
                    new SqlParameter("@Username", emp.Username)
                }));

                Console.WriteLine($"Employee {emp.Username} has been added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong with adding user {emp.Username}.\n{ex}");
            }
            
        }

        public void RemoveEmployee(Employees emp)
        {
            try
            {
                DBActions db = new DBActions();
                db.ExecuteStoredProcedureVoid("RemoveEmployee", cmd => cmd.Parameters.AddRange(new SqlParameter[] {
                    new SqlParameter("@Name", emp.Name),
                    new SqlParameter("@Surname", emp.Surname),
                    new SqlParameter("@username", emp.Username)
                }));
                Console.WriteLine($"User {emp.Username} has been remove successfully from the list.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong with removing user {emp.Username}.\n{ex}");
            }
        }
        
        public void FinishWorkEmployee(Employees emp)
        {
            try
            {
                DBActions db = new DBActions();
                db.ExecuteStoredProcedureVoid("FinishWorkEmployee", cmd => cmd.Parameters.AddRange(new SqlParameter[] {
                    new SqlParameter("@Name", emp.Name),
                    new SqlParameter("@Surname", emp.Surname),
                    new SqlParameter("@Username", emp.Username),
                    new SqlParameter("@ComplectionWork",emp.ComplectionWork)
                }));
                Console.WriteLine($"User {emp.Username} finished work {emp.ComplectionWork}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong with finishing work for user {emp.Username}.\n{ex}");
            }
            
        }
    }
}