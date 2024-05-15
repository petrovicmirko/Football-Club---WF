using System.Configuration;

namespace Football_Club___WF.Util
{
    internal class MyConnection
    {
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["Fudbalski_klub_is"].ConnectionString;
    }
}
