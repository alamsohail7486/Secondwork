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
    public class CustomerContext
    {
        static string conString = ConfigurationManager.ConnectionStrings["Information"].ConnectionString;
        SqlConnection db = new SqlConnection(conString);
        public void InsertCustomer(customer customer)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Name", customer.Name);
                param.Add("@Age", customer.Age);
                param.Add("@Contact_no", customer.Contact_no);
                param.Add("@Address", customer.Address);
                param.Add("@Salary", customer.Salary);
                param.Add("@Hobby", customer.Hobby);
                db.Execute("InsertCustomer", param, commandType: System.Data.CommandType.StoredProcedure);
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

        //updated data from table for customer...
            public List<customer> GetCustomers()
            {
                try
                {
                    db.Open();
                    List<customer> customers = SqlMapper.Query<customer>
                        (db, "CustomerList", commandType: System.Data.CommandType.StoredProcedure).ToList();
                    return customers;

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {

                }
            }
                   //Deleting works done from here...
                public void DeleteCustomer(int Id)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", Id);
                db.Execute("DeleteCustomer", param, commandType: System.Data.CommandType.StoredProcedure);


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
        }
    }
