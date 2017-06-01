using System;
using System.Data;
using System.Data.SqlClient;

namespace ExploringDataTableNETCore2.ConsoleApp
{
    class Program
    {
        private const string _connectionString = "";

        static void Main(string[] args)
        {
            string query = "", query2 = "";

            Console.WriteLine("Hello World!");
            Console.WriteLine("Let's play with ASP.NET Core and DataTables !");

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                Console.WriteLine("1 - Let's play with SqlDataAdapters");

                DataTable _dt = ExecuteDataTableSqlDA(con, query);
                if (_dt == null)
                {
                    Console.WriteLine("DataTable is null");
                }
                else if (_dt.Rows.Count == 0)
                {
                    Console.WriteLine("DataTable has no rows");
                }
                else
                {
                    Console.WriteLine($"DataTable has {_dt.Rows.Count} rows");
                }
                _dt = null;

                Console.WriteLine("2 - Let's play with SqlDataReader");
                _dt = ExecuteDataTable(con, CommandType.Text, query2, null);

                if (_dt == null)
                {
                    Console.WriteLine("DataTable is null");
                }
                else if (_dt.Rows.Count == 0)
                {
                    Console.WriteLine("DataTable has no rows");
                }
                else
                {
                    Console.WriteLine($"DataTable has {_dt.Rows.Count} rows");
                }
                _dt = null;
            }

            Console.ReadLine();
        }

        static DataTable ExecuteDataTable(SqlConnection con, CommandType cmdType, string cmdText, SqlParameter[] cmdParameters)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Numero");
            dt.Columns.Add("Active");
            dt.Columns.Add("Mail");

            using (SqlCommand cmd = new SqlCommand(cmdText, con))
            {
                cmd.CommandType = cmdType;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dt.Rows.Add(reader.GetGuid(0), reader.GetString(1), reader.GetBoolean(2), reader.GetValue(3) != DBNull.Value ? reader.GetString(3) : string.Empty);
                    }
                }
            }

            return dt;
        }

        static DataTable ExecuteDataTableSqlDA(SqlConnection conn, string cmdText)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmdText, conn);
            da.Fill(dt);
            return dt;
        }
    }
}