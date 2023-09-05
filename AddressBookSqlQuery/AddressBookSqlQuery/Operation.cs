using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSqlQuery
{
    public class Operation
    {
        public static void CreateDataBase()
        {
            SqlConnection con = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog=master; integrated Security= true");
            try
            {
                string query = "Create Database AddressBook";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("DataBase Created Sucessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is no database created ");
            }
            finally
            {
                con.Close();
            }
        }
        public static SqlConnection con = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog=AddressBook; integrated Security= true");
        public void CreateTable()
        {
            try
            {
                string query = "Create table AddressBookDetails(id int primary key identity(1,1),firstName varchar(20),lastName varchar(20),address varchar(30),city varchar(20),state varchar(20),zip bigint,phonenumber varchar(10),email varchar(30));";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Sucessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is no Table created " + ex);
            }
            finally
            {
                con.Close();
            }
        }
        public void AddDetails(Contact contact)
        {
            try
            {
                SqlCommand com = new SqlCommand("AddContactDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@firstName", contact.FirstName);
                com.Parameters.AddWithValue("@lastName", contact.LastName);
                com.Parameters.AddWithValue("@address", contact.Address);
                com.Parameters.AddWithValue("@city", contact.City);
                com.Parameters.AddWithValue("@state", contact.State);
                com.Parameters.AddWithValue("@zip", contact.Zip);
                com.Parameters.AddWithValue("@phonenumber", contact.PhoneNumber);
                com.Parameters.AddWithValue("@email", contact.Email);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Contact Added");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateDetails(Contact contact)
        {
            try
            {
                SqlCommand com = new SqlCommand("EditContactDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@firstName", contact.FirstName);
                com.Parameters.AddWithValue("@lastName", contact.LastName);
                com.Parameters.AddWithValue("@address", contact.Address);
                com.Parameters.AddWithValue("@city", contact.City);
                com.Parameters.AddWithValue("@state", contact.State);
                com.Parameters.AddWithValue("@zip", contact.Zip);
                com.Parameters.AddWithValue("@phonenumber", contact.PhoneNumber);
                com.Parameters.AddWithValue("@email", contact.Email);
                con.Open();
                int i = com.ExecuteNonQuery();
                Console.WriteLine("DataBase Updated");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteContact(string firstName)
        {
            try
            {
                SqlCommand com = new SqlCommand("DeleteContactDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@firstName", firstName);
                con.Open();
                int i = com.ExecuteNonQuery();
                Console.WriteLine("Database Deleted");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void SameCityDetails(string city)
        {
            try
            {
                SqlCommand com = new SqlCommand("DetailsinCity", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@city",city);
                con.Open();
                int i = com.ExecuteNonQuery();
                List<Contact> contacts = new List<Contact>();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    contacts.Add(
                        new Contact
                        {
                            Id = Convert.ToInt32(dr["id"]), 
                            FirstName = Convert.ToString(dr["firstName"]),
                            LastName = Convert.ToString(dr["lastName"]),
                            Address = Convert.ToString(dr["Address"]),
                            City = Convert.ToString(dr["city"]),
                            State = Convert.ToString(dr["state"]),
                            Zip = Convert.ToInt64(dr["zip"]),
                            PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                            Email = Convert.ToString(dr["email"]),
                        });
                }
                Console.WriteLine("The persons in the given city are ");
                foreach (var data in contacts)
                {
                    Console.WriteLine(data.FirstName+" "+data.LastName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void SameStateDetails(string State)
        {
            try
            {
                SqlCommand com = new SqlCommand("DetailsinState", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@state", State);
                con.Open();
                int i = com.ExecuteNonQuery();
                List<Contact> contacts = new List<Contact>();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    contacts.Add(
                        new Contact
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            FirstName = Convert.ToString(dr["firstName"]),
                            LastName = Convert.ToString(dr["lastName"]),
                            Address = Convert.ToString(dr["Address"]),
                            City = Convert.ToString(dr["city"]),
                            State = Convert.ToString(dr["state"]),
                            Zip = Convert.ToInt64(dr["zip"]),
                            PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                            Email = Convert.ToString(dr["email"]),
                        });
                }
                Console.WriteLine("The persons in the given State are ");
                foreach (var data in contacts)
                {
                    Console.WriteLine(data.FirstName + " " + data.LastName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void citycount()
        {
            try
            {
                SqlCommand com = new SqlCommand("CountinCity", con);
                com.CommandType = CommandType.StoredProcedure;
                con.Open();
                int i = com.ExecuteNonQuery();
                List<Contact> contacts = new List<Contact>();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    contacts.Add(
                        new Contact
                        {
                            City = Convert.ToString(dr["city"]),
                            count = Convert.ToInt32(dr["count"]) 
                        });
                }
                Console.WriteLine("The No of persons in the Each city are ");
                foreach (var data in contacts)
                {
                    Console.WriteLine(data.City +"-->"+data.count);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void Statecount()
        {
            try
            {
                SqlCommand com = new SqlCommand("CountinState", con);
                com.CommandType = CommandType.StoredProcedure;
                con.Open();
                int i = com.ExecuteNonQuery();
                List<Contact> contacts = new List<Contact>();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    contacts.Add(
                        new Contact
                        {
                            State = Convert.ToString(dr["state"]),
                            count = Convert.ToInt32(dr["count"])
                        });
                }
                Console.WriteLine("The No of persons in the Each State are ");
                foreach (var data in contacts)
                {
                    Console.WriteLine(data.State + "-->" + data.count);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void CreateMappingTable()
        {
            try
            {
                string query = "Create table AddressBookMapping(id int primary key identity(1,1), Contactid int Foreign Key References AddressBookDetails(id), Typeid int Foreign Key References Type(id));";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Sucessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is no Table created " + ex);
            }
            finally
            {
                con.Close();
            }
        }
        public void AddMappingValues(Contact contact)
        {
            try
            {
                SqlCommand com = new SqlCommand("AddMappingValues", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Contactid", contact.Id);
                com.Parameters.AddWithValue("@Typeid", contact.Typeid);
                con.Open();
                com.ExecuteNonQuery();
                Console.WriteLine("Contact Added");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void CountByType()
        {
            try
            {
                SqlCommand com = new SqlCommand("CountByType", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                List<Contact> contacts = new List<Contact>();
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    contacts.Add(
                        new Contact
                        {
                            Id = Convert.ToInt32(dr["Typeid"]),
                            count = Convert.ToInt32(dr["count"])
                        });
                }
                Console.WriteLine("The No of persons in the Each Type are ");
                foreach (var data in contacts)
                {
                    Console.WriteLine(data.Id + "-->" + data.count);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void UsingwithThread(List<Contact> list)
        { 
            DateTime start = DateTime.Now;
            foreach (var data in list)
            {
                Task thread = new Task(
                () =>
                {
                    Console.WriteLine("Being Added" + data.FirstName);
                    AddDetails(data);
                    Console.WriteLine("Added" + data.FirstName);
                });
                thread.Start();
                thread.Wait();
            }
            DateTime end = DateTime.Now;
            Console.WriteLine("Duration with Thread " + (end - start));
        }
        public void UsingWithoutThread(List<Contact> list)
        {
            DateTime start = DateTime.Now;
            foreach (var data in list)
            {
                AddDetails (data);
            }
            DateTime end = DateTime.Now;

            Console.WriteLine("Duration without Thread " + (end - start));
        }
    }
}
