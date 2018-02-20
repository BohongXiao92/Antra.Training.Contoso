using Antra.Training.Contoso.Data.Repositories;
using Antra.Training.Contoso.Model;
using Antra.Training.Contoso.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Transactions;

namespace Antra.Training.Contoso.Service
{
    public class CourseService : ICourseService
    {
        /*************** Constructor ****************/
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        /*************** Methods ****************/
        public IEnumerable<Course> GetAllCourses()
        {
            return _courseRepository.GetAll().ToList();
        }
        public Course GetCourseById(int id)
        {
            return _courseRepository.GetById(id);
        }
        public IEnumerable<Course> GetCoursesByTitle(string title)
        {
            return _courseRepository.GetMany(c => c.Title.Contains(title)).ToList();
        }
        // TODO ... Get Students Group By Department
        public IEnumerable<Course> GetAllCoursesIncludeInstructors()
        {
            throw new NotImplementedException();
        }
        // TODO ... Get Students Group By Instructor
        public IEnumerable<Course> GetAllCoursesIncludeStudents()
        {
            throw new NotImplementedException();
        }
        public void CreateCourse(Course course)
        {
            using (var transaction = new TransactionScope())
            {
                _courseRepository.Add(course);
                _courseRepository.SaveChanges();
                transaction.Complete();
            }
        }
        public void UpdateCourse(Course course)
        {
            using (var transaction = new TransactionScope())
            {
                _courseRepository.Update(course);
                _courseRepository.SaveChanges();
                transaction.Complete();
            }
        }
    }

    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCourseById(int id);
        IEnumerable<Course> GetCoursesByTitle(string title);
        IEnumerable<Course> GetAllCoursesIncludeInstructors();
        IEnumerable<Course> GetAllCoursesIncludeStudents();
        void CreateCourse(Course course);
        void UpdateCourse(Course course);
    }
}
