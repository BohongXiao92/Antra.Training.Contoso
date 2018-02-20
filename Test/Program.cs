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

                //StudentRepository sr = new StudentRepository(db);
                //PersonRepository pr = new PersonRepository(db);
                //StudentService ss = new StudentService(pr, sr);
                //Student s = new Student()
                //{
                //    FirstName = "Yufeng",
                //    LastName = "Luo",
                //    DateofBirth = DateTime.Now,
                //    Email = "YufengBeauty@gmail.com",
                //    Password = "luoyuFeng1932",
                //    EnrollmentDate = DateTime.Now
                //};

                //InstructorRepository insR = new InstructorRepository(db);
                //InstructorService insS = new InstructorService(insR);
                //Instructor ins = new Instructor()
                //{
                //    Id = 17,
                //    FirstName = "Bama",
                //    LastName = "Ao",
                //    DateofBirth = DateTime.Now,
                //    Email = "Bama19343@gmail.com",
                //    Password = "asdfa12343dfa",
                //    HireDate = DateTime.Now
                //};

                RoleRepository rr = new RoleRepository(db);
                RoleService rs = new RoleService(rr);

                Role role = new Role()
                {
                    RoleName = "Good",
                    Description = "This person is good"
                };

                try
                {
                    //ss.CreateStudent(s);
                    //ss.UpdateStudent(sUpdate);
                    //insS.CreateInstructor(ins);
                    //insS.UpdateInstructor(ins);
                    rs.CreateRole(role);
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
