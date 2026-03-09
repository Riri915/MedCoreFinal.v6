using BCrypt.Net;
using MySql.Data.MySqlClient;

namespace MedCoreC_
{
    internal static class AuthHelper
    {
        private static readonly string connStr =
            "server=localhost;user id=root;password=;database=medcore;";

        public static string HashPassword(string plainPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainPassword);
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }

        public static bool LoginUser(string username, string password, out string account_type)
        {
            account_type = string.Empty;

            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                    SELECT password_hash, account_type
                    FROM users
                    WHERE username = @username
                    LIMIT 1;
                ";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return false;

                        string storedHash = reader.GetString("password_hash");

                        if (!BCrypt.Net.BCrypt.Verify(password, storedHash))
                            return false;

                        account_type = reader.GetString("account_type");
                        return true;
                    }
                }
            }
        }
    }
}
