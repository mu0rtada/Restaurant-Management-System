using System;
using System.Data;
using System.Data.SqlClient;

using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class clsFeedBack
    {
        public static async Task<DataTable>GetAllFeedBack()
        {
            DataTable Table = new DataTable();
            string Query = "select * from View_FeedBack";

            using(SqlConnection Connection=new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using(SqlCommand Command=new SqlCommand(Query,Connection))
                {
                   await Connection.OpenAsync();
                   
                    SqlDataReader Reader = await Command.ExecuteReaderAsync();
                
                    Table.Load(Reader);
                   
                }
            }
            return Table;
        }

        public static async Task<int?>AddNewFeedBack(int PersonID,
            int OrderID, byte? Rating)
        {
            int? FeedID = null;
            string Query = "SP_InsertFeedBack";
            using(SqlConnection Connection=new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using(SqlCommand Command=new SqlCommand(Query , Connection))
                {
                   await Connection.OpenAsync();
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@PersonID", PersonID);
                    Command.Parameters.AddWithValue("@OrderID", OrderID);
                    Command.Parameters.AddWithValue("@Rating",(object) Rating??DBNull.Value);

                    object Result=await Command.ExecuteScalarAsync();
                    
                    if (Result != DBNull.Value)
                    {
                        FeedID = Convert.ToInt32(Result);
                    }
                }
            }
            return FeedID;
        }
        public static async Task<Boolean>UpdateRating(int @FeedID,byte? @Rating)
        {
            string Query = "SP_UpdateRating";
            int RowsAffected = 0;
            using(SqlConnection Connection=new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using(SqlCommand Command=new SqlCommand(Query,Connection))
                {
                 
                    Command.CommandType = CommandType.StoredProcedure;
                   
                    Command.Parameters.AddWithValue("@FeedBackID", FeedID);
                   
                    Command.Parameters.AddWithValue("@Rating", (object)Rating ?? DBNull.Value);

                    RowsAffected = await Command.ExecuteNonQueryAsync();

                }
            }
            return RowsAffected > 0;

        }
        public static int ManyRatingThisPerson(int @PersonID)
        {
            int RatingCount = 0;

            string Query = "select dbo.ManyRatingThisPerson(@PersonID)";

            using (SqlConnection Connection = new SqlConnection(StrConnectionSetting.ConnectionString))
            {
                using(SqlCommand Command=new SqlCommand(Query,Connection))
                {
                    Command.Parameters.AddWithValue("@PersonID", PersonID);

                    object Result = Command.ExecuteScalar();
                    if(Result!=DBNull.Value)
                        RatingCount = (int)Result;

                }
            }
            return RatingCount;
        }
    }
}
