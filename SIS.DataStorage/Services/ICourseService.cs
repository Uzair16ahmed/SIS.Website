using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.Models.Models;


namespace SIS.DataStorage.Services
{
    public interface ICourseService
    {
        public Task<List<Courses>> GetAllCourses();
        public Task<Courses> GetCourseById(int id);
        public Task<int> CreateCourseAsync(Courses course);
        public Task<int> UpdateCourseAsync(Courses course);
        public Task<int> DeleteCourseAsync(Courses course);
    }
}


