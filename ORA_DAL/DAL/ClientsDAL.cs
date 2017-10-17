﻿using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORA_Data.DAL
{
    /// <summary>
    /// Basic CRUD methods for Client information. ClientsDM is the model being used here.
    /// </summary>
    /// 

    #region CLIENTS DAL METHODS

    public class ClientsDAL
    {
        public static void CreateClient(ClientsDM _client)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlCommand cmd = new SqlCommand("CREATE_CLIENT", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Client_Name", _client.ClientName);
                    cmd.Parameters.AddWithValue("@Client_Abbreviation", _client.ClientAbbreviation);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                throw (e);
            }
        }

        public static List<ClientsDM> ReadClients()
        {
            List<ClientsDM> _clientList = new List<ClientsDM>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_CLIENTS", SqlConnect.Connection))
                {
                    SqlConnect.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var _client = new ClientsDM();
                                _client.ClientId = (Int64)reader["Client_ID"];
                                _client.ClientName = (string)reader["Client_Name"];
                                _client.ClientAbbreviation = (string)reader["Client_Abbreviation"];
                                _clientList.Add(_client);
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_clientList);
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                throw (e);
            }
        }

        public static ClientsDM ReadClientById(string clientId)
        {
            ClientsDM _client = new ClientsDM();
            try
            {
                using (SqlCommand cmd = new SqlCommand("READ_CLIENT_BY_ID", SqlConnect.Connection))
                {
                    SqlConnect.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Client_ID", clientId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _client.ClientId = (Int64)reader["Client_ID"];
                                _client.ClientName = (string)reader["Client_Name"];
                                _client.ClientAbbreviation = (string)reader["Client_Abbreviation"];
                            }
                        }
                    }
                    SqlConnect.Connection.Close();
                }
                return (_client);
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                throw (e);
            }
        }

        public static void UpdateClient(ClientsDM _client)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE_CLIENT", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Client_ID", _client.ClientId);
                    cmd.Parameters.AddWithValue("@Client_Name", _client.ClientName);
                    cmd.Parameters.AddWithValue("@Client_Abbreviation", _client.ClientAbbreviation);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                throw (e);
            }
        }

        public static void DeleteClient(ClientsDM _client)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE_CLIENT", SqlConnect.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Client_ID", _client.ClientId);
                    SqlConnect.Connection.Open();
                    cmd.ExecuteNonQuery();
                    SqlConnect.Connection.Close();
                }
            }
            catch (Exception e)
            {
                SqlConnect.Connection.Close();
                throw (e);
            }
        }
    }

    #endregion
}
