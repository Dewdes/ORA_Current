﻿using ORA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public void CreateClient(ClientsDM _client)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                    using (SqlCommand cmd = new SqlCommand("CREATE_ADDRESS", SqlConnect.Connection))
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

        public List<ClientsDM> ReadClient()
        {
            List<ClientsDM> _clientList = new List<ClientsDM>();
            try
            {
                    using (SqlCommand cmd = new SqlCommand("READ_CLIENT", SqlConnect.Connection))
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

        public void UpdateClient(ClientsDM _client)
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

        public void DeleteClient(ClientsDM _client)
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
