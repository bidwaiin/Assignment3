using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDB
{
    public class CustomerService
    {
        DBContext dBContext;
        public CustomerService(DBContext _dBContext)
        {
            dBContext = _dBContext;
        }
        public List<Customer> getCustomers()
        {
            List<Customer> customers = new List<Customer>();

            customers = dBContext.db.Query<Customer>("Select * From Customers").ToList();

            return customers;
        }

        public Customer getCustomer(int id)
        {
            Customer customer = new Customer();

            customer = dBContext.db.QueryFirstOrDefault<Customer>("Select * From Customers where CustomerID=@CustomerID", new { CustomerID = id });

            return customer;
        }
        public void saveCustomer(Customer c)
        {
            string sqlCustomerInsert = "INSERT INTO Customers (FirstName,LastName,Email) Values (@CustomerFName,@CustomerLName,@Email);";
            dBContext.db.Execute(sqlCustomerInsert, new { CustomerFName = c.FirstName, CustomerLName = c.LastName, Email = c.Email });

        }

        public void updateCustomer(Customer c)
        {
            string sqlCustomerUpdate = "UPDATE Customers SET FirstName=@CustomerFName,LastName=@CustomerLName,Email=@Email   where CustomerID=@CustomerID";
            dBContext.db.Execute(sqlCustomerUpdate, new { CustomerID=c.CustomerID, CustomerFName = c.FirstName, CustomerLName = c.LastName, Email = c.Email });

        }

        public void deleteCustomer(int id)
        {
            Customer customer = new Customer();

            dBContext.db.Execute("DELETE  From Customers where CustomerID=@CustomerID", new { CustomerID = id });

           
        }

        public Customer spgetCustomer(int id)
        {
            Customer customer = new Customer();
            customer=dBContext.db.QueryFirstOrDefault<Customer>("usp_Customers", new { CustId = id }, commandType: CommandType.StoredProcedure);

            return customer;

        }
    }
}
