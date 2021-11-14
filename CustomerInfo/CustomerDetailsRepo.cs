using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CustomerInfo
{
  public  class CustomerDetailsRepo
  {
        //INSERT
        public void Add(CustomerDetails customer)
        {
            using (IDbConnection con = new SqlConnection(ConnectDb.Constr))
            {
                string query = "AddCustomer";
                var p = new DynamicParameters();
                p.Add("FirstName", customer.FirstName);
                p.Add("MiddleNames", customer.MiddleNames);
                p.Add("LastName", customer.LastName);
                p.Add("Gender", customer.Gender);
                p.Add("Email", customer.Email);
                p.Add("Telephone", customer.Telephone);
                p.Add("PostalCode", customer.PostalCode);
                p.Add("Street", customer.Street);
                p.Add("City", customer.City);
                p.Add("Country", customer.Country);
                con.Execute(query, p, commandType:CommandType.StoredProcedure);
                
            }
        }

        //UPDATE
        public void Update(CustomerDetails customer)
        {
            using (IDbConnection con = new SqlConnection(ConnectDb.Constr))
            {
                string query = "UpdateCustomer";
                var p = new DynamicParameters();
                p.Add("FirstName", customer.FirstName);
                p.Add("MiddleNames", customer.MiddleNames);
                p.Add("LastName", customer.LastName);
                p.Add("Gender", customer.Gender);
                p.Add("Email", customer.Email);
                p.Add("Telephone", customer.Telephone);
                p.Add("PostalCode", customer.PostalCode);
                p.Add("Street", customer.Street);
                p.Add("City", customer.City);
                p.Add("Country", customer.Country);
                p.Add("Id", customer.Id);
                con.Execute(query, p, commandType: CommandType.StoredProcedure);

            }
        }


        //GET ALL
        public IEnumerable<CustomerDetails> GetAll()
        {
            using (IDbConnection con = new SqlConnection(ConnectDb.Constr))
            {
                string query = "GetCustomers";
                return con.Query<CustomerDetails>(query, commandType:CommandType.StoredProcedure);
            }
        }

        //GET BY ID
        public CustomerDetails GetByID(int id)
        {
            return GetAll().ToList().Where(x => x.Id == id).FirstOrDefault();            
        }

        //DELETE
        public void Delete(int id)
        {
            using (IDbConnection con = new SqlConnection(ConnectDb.Constr))
            {
                string query = "DeleteCustomer";
                con.Query<CustomerDetails>(query, new { Id = id }, commandType:CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
