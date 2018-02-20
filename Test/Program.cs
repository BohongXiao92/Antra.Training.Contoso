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

                Instructor sUpdate = new Instructor()
                {
                    Id = 14,
                    FirstName = "Shangxiang",
                    LastName = "Sun",
                    DateofBirth = DateTime.Now,
                    Email = "Shangxiang@gmail.com",
                    Password = "ssa21345dfas",
                    EnrollmentDate = DateTime.Now
                };

                StudentRepository sr = new StudentRepository(db);
                PersonRepository pr = new PersonRepository(db);
                StudentService ss = new StudentService(pr, sr);
                //sr.Add(sUpdate);
                //sr.Update(sUpdate);
                

                try
                {
                    //ss.CreateStudent(sUpdate);
                    ss.UpdateStudent(sUpdate);
                    Console.WriteLine("Yeah!!!!!!!!!!!!!!!!!!!!!");

                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                }
                Console.ReadLine();
            }
        }
    }
}
