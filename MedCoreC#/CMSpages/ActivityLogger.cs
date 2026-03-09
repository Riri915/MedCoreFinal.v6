using MySql.Data.MySqlClient;

namespace MedCoreC_
{
    internal static class ActivityLogger
    {
        private static readonly string connStr =
            "server=localhost;user id=root;password=;database=medcore;";

        public static void Log(string employeeId, string username, string action)
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                    INSERT INTO activity_logs (employee_id, username, action)
                    VALUES (@empId, @user, @action);
                ";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@empId", employeeId);
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@action", action);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
