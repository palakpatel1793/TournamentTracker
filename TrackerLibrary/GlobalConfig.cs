using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using TrackerLibrary.DataAccess;
using System.Data.SqlClient;
using System.IO;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public const string PrizesFile = "PrizeModels.csv";
        public const string PersonsFile = "PersonsModels.csv";
        public const string TeamsFile = "TeamModels.csv";
        public const string TournamentFile = "TournamentModels.csv";
        public const string MatchupFile = "MatchupModels.csv";
        public const string MatchupEntryFile = "MatchupEntryModels.csv";

        public static IDataConnection Connection { get; private set; }
        public static object TeamFile { get; internal set; }

        public static void IntializeConnections(DatabaseType db)
        {
           
            if (db == DatabaseType.Sql)
            {
                // TODO - Setup the SQL Connector properly
                SqlConnector sql = new SqlConnector();
                Connection = sql;

            }
            else if(db == DatabaseType.TextFile)
            {
                //TODO - Create the Text Connection
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
