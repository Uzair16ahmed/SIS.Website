using SIS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.DataStorage.Services
{
    public interface IDepartmentService
    {
        public Task<List<Department>> GetAllDepartments();
        public Task<Department> GetDepartmentById(int id);
        public Task<int> CreateDepartmentAsync(Department department);
        public Task<int> UpdateDepartmentAsync(Department department);
        public Task<int> DeleteDepartmentAsync(Department department);

    }
}
