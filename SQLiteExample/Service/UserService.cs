using SQLiteExample.Entity;
using SQLiteExample.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SQLiteExample.Service
{
    public class UserService
    {
        public static IEnumerable<User> GetAll()
        {
            var result = new List<User>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM Users";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new User {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Name = reader["Name"].ToString(),
                                Lastname = reader["Lastname"].ToString(),
                                Birthday = Convert.ToDateTime(reader["Birthday"]),
                            });
                        }
                    }
                }
            }

            return result;
        }
    }
}
