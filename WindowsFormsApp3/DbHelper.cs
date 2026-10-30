using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{
    public class DbHelper
    {
        private string _connStr = "Server = localhost; Database = VisionDB; User Id = sa; Password = 1; TrustServerCertificate = True; Connect Timeout = 5";

        public bool InsertResult(string sn, double row, double column, double angle, double score, bool isok )
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    conn.Open();
                    string sql = "INSERT INTO VisionResult (SN, [Row], [Column], Angle, Score, IsOK, Time) " +
                                 "VALUES (@SN, @Row, @Column, @Angle, @Score, @IsOK, @Time); ";
                    using (SqlCommand cmd = new SqlCommand(sql,conn))
                    { 
                        cmd.Parameters.AddWithValue("@SN", sn);
                        cmd.Parameters.AddWithValue("@Row", row);
                        cmd.Parameters.AddWithValue("@Column", column);
                        cmd.Parameters.AddWithValue("@Angle", angle);
                        cmd.Parameters.AddWithValue("@Score", score);
                        cmd.Parameters.AddWithValue("@IsOK", isok?1:0);
                        cmd.Parameters.AddWithValue("@Time", DateTime.Now);

                        cmd.ExecuteNonQuery();
                        
                    }
                    return true;
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("数据写入失败：" + ex.Message);
                return false;
            }
        }

        public DataTable QueryBySN(string sn)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    conn.Open();
                    string sql = "SELECT * FROM VisionResult WHERE SN = @SN; ";
                    using (SqlCommand cmd = new SqlCommand(sql,conn))
                    {
                        cmd.Parameters.AddWithValue("@SN",sn);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("数据查询失败：" + ex.Message);
            }
            return dt;
        }
    }
}

