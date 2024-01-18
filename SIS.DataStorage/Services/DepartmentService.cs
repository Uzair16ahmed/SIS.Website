using SIS.DataStorage.Interfaces;
using SIS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.DataStorage.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<List<Department>> GetAllDepartments()
        {
            return await _departmentRepository.GetAllAsync();
        }

        public async Task<Department> GetDepartmentById(string id)
        {
            return await _departmentRepository.GetByIdAsync(id);
        }

        public async Task<int> CreateDepartmentAsync(Department department)
        {
            return await _departmentRepository.CreateAsync(department);
        }

        public async Task<int> UpdateDepartmentAsync(Department department)
        {
            return await _departmentRepository.UpdateAsync(department);
        }

        public async Task<int> DeleteDepartmentAsync(Department department)
        {
            return await _departmentRepository.DeleteAsync(department);
        }
    }
}
