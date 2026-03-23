using MySql.Data.MySqlClient;

namespace CoreLibrary
{
    public static class ActivityLogger
    {
        public static void Log(MySqlConnection conn, string empId, string username, string action)
        {
            string query = @"INSERT INTO activity_logs 
                             (employee_id, username, action, created_at) 
                             VALUES (@emp, @user, @action, NOW())";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@emp", empId);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@action", action);
                cmd.ExecuteNonQuery();
            }
        }
    }
}