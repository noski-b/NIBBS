﻿using Microsoft.Data.SqlClient;
using PosReversalNIBBS_API.Data;
using PosReversalNIBBS_API.Models.Domain;

namespace PosReversalNIBBS_API.Configurations.Implementation
{
    public class PositionOfficeManager
    {
      // private PosNibbsDbContext context = new PosNibbsDbContext();

        public void GetAccountFromPositionOffice()
        {
            string connectionString = "Data Source=172.25.1.247,1554;Initial Catalog=position_office;User ID=pos_auto_revsl;Password=Auto@1234$";

            // Create a connection object.
            SqlConnection connection = new SqlConnection(connectionString);


            Console.WriteLine("Getting records from Position_Office database");
            //logger.Info("Getting records from Postition office");

            try
            {
                connection.Open();
                string sqlQuery = "";

                SqlCommand command= new SqlCommand(sqlQuery, connection);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    try
                    {
                        var context = new PosNibbsDbContext();

                        var entity = new ExcelResponse()
                        {
                            Account_Id = reader.GetInt32(1)
                        };

                        // This is to check whether the record already exist in the db
                        var records = context.ExcelResponses.Where(x => x.Processor_Name.ToLower().Trim() == entity.Processor_Name.ToLower().Trim()).FirstOrDefault();
                        if (records == null)
                        {
                            context.ExcelResponses.Add(entity);
                            context.SaveChanges();
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            { 
                connection.Close();
                Console.WriteLine("All records are updated with account Id")
            }

           // return new List<ExcelResponse>();
        }
    }
}
