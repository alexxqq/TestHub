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
        public Env()
        {
            DotNetEnv.Env.Load();
            DbHost = Environment.GetEnvironmentVariable("DB_HOST")?? "localhost";
            DbUser = Environment.GetEnvironmentVariable("DB_USER")?? "postgres";
            DbPass = Environment.GetEnvironmentVariable("DB_PASS")?? "1234";
            DbPort = Environment.GetEnvironmentVariable("DB_PORT")?? "5432";
            DbName = Environment.GetEnvironmentVariable("DB_NAME")?? "postgres";
        }

        public string DbHost { get; set; }
        public string DbUser { get; set; }
        public string DbPass { get; set; }
        public string DbPort { get; set; }
        public string DbName { get; set; }
    }
}
