using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class clsReservationDL
    {
        public static async Task<DataTable> GetAllReservation()
        {
            DataTable Table = new DataTable();
            string Query = "select * from View_GetAllReservation";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                   await Connection.OpenAsync();
                    SqlDataReader reader = Command.ExecuteReader();

                    Table.Load(reader);
                   
                }
            }
            return Table;
        }

        public static async Task<DataTable> GetAll_Today_Reservation()
        {
            DataTable Table = new DataTable();
            string Query = "SP_GetAllReservationsToday";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    await Connection.OpenAsync();
                    SqlDataReader reader =await Command.ExecuteReaderAsync();

                    Table.Load(reader);

                }
            }
            return Table;
        }
        public static async Task<int>AddNewReservation(int PersonID, int TableID
            , DateTime ReservationDate, bool Status)
        {
            int ReservationID=0;
            string Query = "SP_InsertReservation";
            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    try
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        await Connection.OpenAsync();
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        Command.Parameters.AddWithValue("@TableID", TableID);
                        object Result = await Command.ExecuteScalarAsync();
                        if (Result != DBNull.Value)
                        {
                            ReservationID = (int)Result;
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                }

            }
            return ReservationID;
        }

       
    }
}