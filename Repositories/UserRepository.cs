using System.Data;
using keepr.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;

namespace keepr.Repositories
{
    public class UserRepository : DbContext
    {
        public UserRepository(IDbConnection db) : base(db)
        {
        }

        public UserReturnModel Register(UserRegisterModel creds)
        {
            // encrypt the password??
            creds.Password = BCrypt.Net.BCrypt.HashPassword(creds.Password);
            //sql

            int defaultValue = 0;
            DateTime created = new DateTime();

            try
            {
                System.Console.WriteLine("It got here");

                int id = _db.ExecuteScalar<int>(@"
                INSERT INTO users (Username, FirstName, LastName, Email, Password, AvatarURL, OwnKeepsViewed, OwnKeepsVaulted, DateCreated)
                VALUES (@Username, @FirstName, @LastName, @Email, @Password, @AvatarURL, @OwnKeepsViewed, @OwnKeepsVaulted, @DateCreated);
                SELECT LAST_INSERT_ID();
            ", creds);

                return new UserReturnModel()
                {
                    Id = id,
                    Username = creds.Username,
                    FirstName = creds.FirstName,
                    LastName = creds.LastName,
                    Email = creds.Email,
                    AvatarURL = creds.AvatarURL,
                    OwnKeepsViewed = defaultValue,
                    OwnKeepsVaulted = defaultValue,
                    DateCreated = created
                };
            }
            catch (MySqlException e)
            {
                System.Console.WriteLine("It didn't make it");
                System.Console.WriteLine("ERROR: " + e.Message);
                return null;
            }
        }

        public UserReturnModel Login(UserLoginModel creds)
        {
            // more sql
            User user = _db.QueryFirstOrDefault<User>(@"
                SELECT * FROM users WHERE email = @Email
            ", creds);
            if (user != null)
            {
                var valid = BCrypt.Net.BCrypt.Verify(creds.Password, user.Password);
                if (valid)
                {
                    return user.GetUserReturnModel();
                }
            }
            return null;
        }

        //Shouldn't lookup by email?
        //If you want to use below you need to re-enable a line found in
        // UserReturnModel.cs
        #region GetUserByEmail-Function-Unused
        // internal UserReturnModel GetUserByEmail(string email)
        // {
        //     User user = _db.QueryFirstOrDefault<User>(@"
        //         SELECT * FROM sharpusers WHERE email = @Email
        //     ", new { email });
        //     return user.GetReturnModel();
        // }
        #endregion

        internal UserReturnModel GetUserById(string id)
        {
            User savedUser = _db.QueryFirstOrDefault<User>(@"
            SELECT * FROM users WHERE id = @id
            ", new { id });
            if (savedUser != null)
            {
                return savedUser.GetUserReturnModel();
            }
            return null;
        }

        internal UserReturnModel UpdateUser(UserReturnModel user)
        {
            var i = _db.Execute(@"
                UPDATE users SET
                    email = @Email,
                    username = @Username
                WHERE id = @id
            ", user);
            if (i > 0)
            {
                return user;
            }
            return null;

        }

        internal string ChangeUserPassword(UserChangePasswordModel user)
        {
            User savedUser = _db.QueryFirstOrDefault<User>(@"
            SELECT * FROM users WHERE id = @id
            ", user);

            var valid = BCrypt.Net.BCrypt.Verify(user.OldPassword, savedUser.Password);
            if (valid)
            {
                user.NewPassword = BCrypt.Net.BCrypt.HashPassword(user.NewPassword);
                var i = _db.Execute(@"
                    UPDATE users SET
                        password = @NewPassword
                    WHERE id = @id
                ", user);
                return "Good Job";
            }
            return "Umm nope!";
        }
    }
}