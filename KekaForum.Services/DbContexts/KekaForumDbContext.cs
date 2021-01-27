using KekaForum.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace KekaForum.Services.DbContexts
{
    public class KekaForumDbContext:IKekaForumDbContext
    {
        private readonly IConfiguration Configuration;
        private readonly string DevConnection = "Server=(local)\\sqlexpress;Database=KekaForumDB;Trusted_Connection=True;MultipleActiveResultSets=True;";

        public KekaForumDbContext(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public DbConnection Connection
        {
            get
            {
                //***
                //*** Create a new connection if null or disposed
                //***
                if (_connection == null)
                {
                    _connection = new SqlConnection(DevConnection);
                    _connection.Open();
                }
                //***
                //*** Open the connection if the connection state is anything other than disposed
                //***
                else if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }

        private DbConnection _connection;

        public DbConnection GetDbConnection()
        {
            return this.Connection;
        }
    }
}
