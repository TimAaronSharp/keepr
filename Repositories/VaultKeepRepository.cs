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
    public class VaultKeepRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepRepository(IDbConnection db)
        {
            _db = db;
        }

        // Find One Find Many add update delete
        // public IEnumerable<VaultKeep> GetAll()
        // {
        //     return _db.Query<VaultKeep>("SELECT * FROM vaultkeeps");
        // }

        public IEnumerable<VaultKeepReturnModel> GetByVaultKeepByVaultId(int id)
        {
            // return _db.QueryFirstOrDefault<VaultKeep>($"SELECT * FROM vaultkeeps WHERE id = {id}", id);
            return _db.Query<VaultKeepReturnModel>($@"SELECT * FROM vaultkeeps vk
                                                         INNER JOIN keeps k ON k.id = vk.keepId
                                                         WHERE (vaultId = {id})", id);
        }

        public VaultKeep Add(VaultKeep vaultKeep)
        {
            //INSERT INTO vaults - inserts the arguments to the matching parameters(order is important), then executes a separate SELECT query to get the ID of the last inserted item, and then auto increments to get a new id(provided auto increment is set on the table).
            //the new { vault.Name.... etc} is the object constructor that will be used in the insert query.

            DateTime created = new DateTime();

            int id = _db.ExecuteScalar<int>($@"INSERT INTO vaultkeeps (VaultId, KeepId, UserId, DateCreated)
                                            VALUES(@VaultId, @KeepId, @UserId, @created);
                                            SELECT LAST_INSERT_ID()", new
            {
                vaultKeep.VaultId,
                vaultKeep.KeepId,
                vaultKeep.UserId,
                created
            });
            vaultKeep.Id = id;
            return vaultKeep;

        }

        public VaultKeep GetOneByIdAndUpdate(int id, VaultKeep vaultKeep)
        {
            //Queries for the first Vault that matches the id passed in. If it doesn't find it, it defaults to handle the error gracefully without crashing. If it finds the id, it updates the fields with the data you are sending.
            return _db.QueryFirstOrDefault<VaultKeep>($@"
                UPDATE vaultkeeps SET  
                    Name = @Name,
                    Description = @Description
                WHERE Id = {id};
                SELECT * FROM vaults WHERE id = {id};", vaultKeep);
        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute($@"
                DELETE FROM vaultkeeps WHERE Id = {id}
            ", id);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}