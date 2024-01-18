using System;
using System.Collections.Generic;
using SIS.DataStorage.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.Models.Models;


namespace SIS.DataStorage.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<List<Courses>> GetAllCourses()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Courses> GetCourseById(int id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task<int> CreateCourseAsync(Courses course)
        {
            return await _courseRepository.CreateAsync(course);
        }

        public async Task<int> UpdateCourseAsync(Courses course)
        {
            return await _courseRepository.UpdateAsync(course);
        }

        public async Task<int> DeleteCourseAsync(Courses course)
        {
            return await _courseRepository.DeleteAsync(course);
        }
    }
}

