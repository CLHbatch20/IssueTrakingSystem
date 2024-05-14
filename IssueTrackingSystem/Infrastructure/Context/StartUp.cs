using MySql.Data.MySqlClient;
using System.Data.Common;

namespace IssueTrackingSystem.Infrastructure.Context
{
    public class StartUp 
    {
        private readonly string _connectionString = "server=localhost;user=root;database=trackingsystemdb;password=123456789";
       
        public void CreateDB()
        {
            using (var connection = new MySqlConnection(_connectionString)) 
            {
                var query = "CREATE DATABASE IF NOT EXISTS TrackingSystemDB";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        
        public void CreateUserTable()
        {
            var query = @"CREATE TABLE users(
                        Id char(36),
                        username varchar(35) NOT NULL,
                        Email Varchar(35) NOT NULL,
                        password Varchar(35) NOT NULL,
                        Role enum('Product','Engineer') NOT NULL,
                        PRIMARY KEY (Id)
                            )";
            var connection = _connectionString;
            CreateTable( query);
        }

       public void CreateCategory()
        {
            var query = @"CREATE TABLE category(
                        Id char(36),
                        Name Varchar(36) NOT NULL,
                        Description TEXT,
                        Primary Key (Id)
                           )";
            var connection = _connectionString;
            CreateTable( query);
        }

        public void CreateIssues()
        {
            var query = @"CREATE TABLE issues(
                        Id char(36),
                        Title Varchar(50) NOT NULL,
                        Description TEXT,
                        CreatedAT DATETIME,
                        UpdatedAt DATETIME,
                        Priority ENUM('Low', 'Medium', 'High'),
                        Status ENUM('Open','InProgress','Done'),
                        CategoryId char(36),
                        ReporterId char(36),    
                        DueDate DATETIME,
                        AssigneeId char(36),
                        Primary Key (Id),
                        Foreign Key(CategoryId) References Category(Id),
                        Constraint fk_ReporterId Foreign Key(ReporterId) References Users(Id),
                        Constraint fk_AssigneeId Foreign Key(AssigneeId) References Users(Id))";
            var connection = _connectionString;
            CreateTable( query);    
        }

        public void CreateTable(string query)
        {
            try
            {
                using (var connections = new MySqlConnection(_connectionString))
                {
                    var queries = query;
                    using (var command = new MySqlCommand(query, connections))
                    {
                        connections.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + $"Error in creating{query}");
            }
        }




    }
}
