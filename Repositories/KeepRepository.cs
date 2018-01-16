using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using keepr.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;

namespace keepr.Repositories
{
    public class KeepRepository
    {
        private readonly IDbConnection _db;

        public KeepRepository(IDbConnection db)
        {
            _db = db;
        }

        // Find One Find Many add update delete
        public IEnumerable<Keep> GetAll()
        {
            return _db.Query<Keep>("SELECT * FROM keeps");
        }

        public Keep GetById(int id)
        {
            return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM keeps WHERE id = {id}", id);
        }
        public IEnumerable<Keep> GetKeepsByUserId(int id)
        {
            return _db.Query<Keep>($"SELECT * FROM keeps WHERE userid = {id}", id);
        }

        public Keep Add(Keep keep)
        {
            //INSERT INTO keeps - inserts the arguments to the matching parameters(order is important), then executes a separate SELECT query to get the ID of the last inserted item, and then auto increments to get a new id(provided auto increment is set on the table).
            //the new { keep.Name.... etc} is the object constructor that will be used in the insert query.

            int defaultValue = 0;
            DateTime created = new DateTime();

            int id = _db.ExecuteScalar<int>($@"INSERT INTO keeps (UserId, Name, Description, Views, Shares, VaultsAddedTo, ImageURL, DateCreated)
             VALUES(@UserId, @Name, @Description, @defaultValue, @defaultValue, @defaultValue, @ImageURL, @created);
             SELECT LAST_INSERT_ID()", new
            {
                keep.UserId,
                keep.Name,
                keep.Description,
                defaultValue,
                keep.ImageURL,
                created
            });
            keep.Id = id;
            return keep;

        }

        public Keep GetOneByIdAndUpdate(int id, Keep keep)
        {
            //Queries for the first Keep that matches the id passed in. If it doesn't find it, it defaults to handle the error gracefully without crashing. If it finds the id, it updates the fields with the data you are sending.
            return _db.QueryFirstOrDefault<Keep>($@"
                UPDATE keeps SET  
                    UserId = @UserId,
                    Name = @Name,
                    Description = @Description,
                    Views = @Views,
                    VaultsAddedTo = @VaultsAddedTo,
                    ImageURL = @ImageURL

                WHERE Id = {id};
                SELECT * FROM keeps WHERE id = {id};", keep);
        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute($@"
                DELETE FROM keeps WHERE Id = {id}
            ", id);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}