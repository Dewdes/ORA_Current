using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    public class AddressDAL
    {
        #region ADDRESS DAL METHODS

        private static ErrorLog errorLog = new ErrorLog();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="empID"></param>
        public static void CreateAddress(AddressDM address, long empID)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlCommand cmd = new SqlCommand("CREATE_ADDRESS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_ID", empID);
                    cmd.Parameters.AddWithValue("@Address", address.Address);
                    cmd.Parameters.AddWithValue("@City", address.City);
                    cmd.Parameters.AddWithValue("@State", address.State);
                    cmd.Parameters.AddWithValue("@Zip_Code", address.Zip_Code);
                    cmd.Parameters.AddWithValue("@Country", address.Country);
                    cmd.Parameters.AddWithValue("@Phone", address.Phone);
                    cmd.Parameters.AddWithValue("@Email", address.Email);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                errorLog.ErrorLogger("CreateAddress", DateTime.Now, e.Message);
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<AddressDM> ReadAllAddress()
        {
            List<AddressDM> addressList = new List<AddressDM>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_ALL_ADDRESS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows) return (addressList);
                        while (reader.Read())
                        {
                            var address = new AddressDM
                            {
                                Address_ID = (Int64)reader["Address_ID"],
                                Address = (string)reader["Address"],
                                City = (string)reader["City"],
                                State = (string)reader["State"],
                                Zip_Code = (int)reader["Zip_Code"],
                                Country = (string)reader["Country"],
                                Phone = (string)reader["Phone"],
                                Email = (string)reader["Email"]
                            };
                            addressList.Add(address);
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (addressList);
            }
            catch (Exception ex)
            {
                SqlConnect.Connection.Close();
                errorLog.ErrorLogger("ReadAllAddress", DateTime.Now, ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static AddressDM ReadAddressByID(string id)
        {
            try
            {
                AddressDM address = new AddressDM();
                using (SqlCommand cmd = new SqlCommand("READ_ADDRESS_BY_ID", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlConnect.Connection.Open();
                    cmd.Parameters.AddWithValue("@Employee_ID", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows) return (address);
                        while (reader.Read())
                        {
                            address.Address_ID = (Int64)reader["Address_ID"];
                            address.Address = (string)reader["Address"];
                            address.City = (string)reader["City"];
                            address.State = (string)reader["State"];
                            address.Zip_Code = (int)reader["Zip_Code"];
                            address.Country = (string)reader["Country"];
                            address.Phone = (string)reader["Phone"];
                            address.Email = (string)reader["Email"];
                            address.Employee_ID = (Int64)reader["Employee_ID"];
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (address);
            }
            catch (Exception ex)
            {
                SqlConnect.Connection.Close();
                errorLog.ErrorLogger("ReadAddressByID", DateTime.Now, ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        public static void UpdateAddress(AddressDM address)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_ADDRESS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Address_ID", address.Address_ID);
                    cmd.Parameters.AddWithValue("@Address", address.Address);
                    cmd.Parameters.AddWithValue("@City", address.City);
                    cmd.Parameters.AddWithValue("@State", address.State);
                    cmd.Parameters.AddWithValue("@Zip_Code", address.Zip_Code);
                    cmd.Parameters.AddWithValue("@Country", address.Country);
                    cmd.Parameters.AddWithValue("@Phone", address.Phone);
                    cmd.Parameters.AddWithValue("@Email", address.Email);
                    cmd.Parameters.AddWithValue("@Employee_ID", address.Employee_ID);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                errorLog.ErrorLogger("UpdateAddress", DateTime.Now, e.Message);
                throw (e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        public static void DeleteAddress(AddressDM address)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE_ADDRESS", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Address_ID", address.Address_ID);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                SqlConnect.Connection.Close();
                errorLog.ErrorLogger("DeleteAddress", DateTime.Now, ex.Message);
                throw ex;
            }
        }
        #endregion
    }
}
