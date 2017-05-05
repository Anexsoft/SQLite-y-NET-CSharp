using SQLiteExample.Persistence;
using SQLiteExample.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContext.Up();

            foreach(var user in UserService.GetAll())
            {
                Console.WriteLine(
                    string.Format("#{0}: - {1}, {2} - Age: {3}", user.Id, user.Name, user.Lastname, (DateTime.Today.Year - user.Birthday.Year))
                );
            }

            Console.Read();
        }
    }
}
