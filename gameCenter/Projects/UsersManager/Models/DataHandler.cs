using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace gameCenter.Projects.UsersManager.Models
{
    internal class DataHandler
    {
        static readonly string directory = Directory.GetParent(Environment.CurrentDirectory)!.ToString();

        static readonly string path = directory + @"/gameCenter/Projects/UsersManager/Data/users.json";

        static readonly string jsonString = File.ReadAllText(path);

        public static List<User> GetUserList()
        {
            return JsonSerializer.Deserialize<List<User>>(jsonString)!;
        }
    }
}
