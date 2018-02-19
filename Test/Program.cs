using Antra.Training.Contoso.Data;
using Antra.Training.Contoso.Model;
using Antra.Training.Contoso.Data.Repositories;
using Antra.Training.Contoso.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ContosoDbContext())
            {
                Person p1 = new Student()
                {
                    FirstName = "Bohong",
                    LastName = "Xiao"
                };

                Department d1 = new Department()
                {
                    Name = "D1",
                    Budget = 15000,
                    StartDate = DateTime.Now
                };

                DepartmentRepository dp = new DepartmentRepository(db);
                dp.Add(d1);

                
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                    Console.Write(e.ToString());
                    Console.Read();
                }
                

            }
        }
    }
}
