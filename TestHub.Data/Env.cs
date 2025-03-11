using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;

namespace TestHub.DAL
{
    public class Env
    {
        private string dbHost;
        private string dbUser;
        private string dbPass;
        private string dbPort;
        private string dbName;

        public Env()
        {
            DotNetEnv.Env.Load();
            DbHost = Environment.GetEnvironmentVariable("DB_HOST");
            DbUser = Environment.GetEnvironmentVariable("DB_USER");
            DbPass = Environment.GetEnvironmentVariable("DB_PASS");
            DbPort = Environment.GetEnvironmentVariable("DB_PORT");
            DbName = Environment.GetEnvironmentVariable("DB_NAME");
        }

        public string DbHost { get => dbHost; set => dbHost = value; }
        public string DbUser { get => dbUser; set => dbUser = value; }
        public string DbPass { get => dbPass; set => dbPass = value; }
        public string DbPort { get => dbPort; set => dbPort = value; }
        public string DbName { get => dbName; set => dbName = value; }
    }
}
