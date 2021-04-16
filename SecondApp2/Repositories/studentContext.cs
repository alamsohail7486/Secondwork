using Dapper;
using SecondApp2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SecondApp2.Repositories
{
    public class studentContext
    {
        static string conString = ConfigurationManager.ConnectionStrings["Information"].ConnectionString;
        SqlConnection db = new SqlConnection(conString);
        public void InsertStudent(student student)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@name", student.Name);
                param.Add("@address", student.Address);
                param.Add("@phone", student.Phone_no);
                param.Add("@age", student.Age);
                param.Add("@standard", student.Standard);
                param.Add("@email_id", student.Email_id);
                db.Execute("InsertToInformation", param, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }
        }
        //updated works from here ...
        public List<student> GetStudents()
        {
            try
            {
                db.Open();
                List<student> students = SqlMapper.Query<student>(db, "GetAllStudent", commandType: System.Data.CommandType.StoredProcedure).ToList();
                return students;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }

        public void DeleteStudent(int Id)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", Id);
                db.Execute("DeleteStudent", param, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;

            }
            finally
            {

            }
        }
    }
}