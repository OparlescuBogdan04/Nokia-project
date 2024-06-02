using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace Nokia
{
    public static class RecurringUser
    {
        private static readonly string recurring_user_file_path = $"{Environment.GetFolderPath(0)}/Credentials.bin";

        public static bool ExistingCredentialsFile()
        {
            return File.Exists(recurring_user_file_path);
        }

        public static User ReadFile()
        {
            FileStream file_stream = new FileStream(recurring_user_file_path, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            User user = (User)bf.Deserialize(file_stream);
            file_stream.Close();
            return user;
        }

        public static void WriteFile(User user)
        {
            FileStream file_stream = new FileStream(recurring_user_file_path, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file_stream, user);
            file_stream.Close();
        }
    }
}
