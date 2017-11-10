using System;
using System.Data.SQLite;
using System.IO;
using Finance.Core.Properties;
using Nameless.WinFormsApplication;

namespace Finance.Core {

    /// <summary>
    /// WRITE YOUR DOCUMENTATION SUMMARY HERE.
    ///
    /// Singleton Pattern implementation for Bootstrap. (see: https://en.wikipedia.org/wiki/Singleton_pattern)
    /// </summary>
    public sealed class Bootstrap {

        #region Private Static Read-Only Fields

        private static readonly Bootstrap _instance = new Bootstrap();

        #endregion Private Static Read-Only Fields

        #region Public Static Properties

        /// <summary>
        /// Gets the unique instance of BootStrap.
        /// </summary>
        public static Bootstrap Instance {
            get { return _instance; }
        }

        #endregion Public Static Properties

        #region Static Constructors

        // Explicit static constructor to tell the C# compiler
        // not to mark type as beforefieldinit
        static Bootstrap() {
        }

        #endregion Static Constructors

        #region Private Constructors

        private Bootstrap() {
        }

        #endregion Private Constructors

        #region Public Methods

        public void Run() {
            // Set DATADIRECTORY
            var dataDirectory = Path.Combine(typeof(Bootstrap).Assembly.GetDirectoryPath(), "App_Data");
            if (!Directory.Exists(dataDirectory)) { Directory.CreateDirectory(dataDirectory); }
            AppDomain.CurrentDomain.SetData("DATADIRECTORY", dataDirectory);

            // Create SQLite database file and table schemas
            var databaseFilePath = Path.Combine(dataDirectory, "database.s3db");
            if (!File.Exists(databaseFilePath)) {
                SQLiteConnection.CreateFile(databaseFilePath);

                using (var connection = new SQLiteConnection($"Data Source={databaseFilePath}; Version=3;", true)) {
                    connection.Open();
                    using (var command = new SQLiteCommand(connection)) {
                        command.CommandText = Resources.SQL_DatabaseSchemas;
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        #endregion Public Methods
    }
}