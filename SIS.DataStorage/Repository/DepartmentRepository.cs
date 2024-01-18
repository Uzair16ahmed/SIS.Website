using Microsoft.Extensions.Configuration;
using SIS.DataStorage.Interfaces;
using SIS.Models.Models;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SIS.DataStorage.Repository
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public DepartmentRepository(IConfiguration configuration) : base(configuration)
        { }
        public async Task<List<Department>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM Department";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Department>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Department> GetByIdAsync(string id)
        {
            try
            {
                var query = "SELECT * FROM Department WHERE DeptID = @DepartmentID";

                var parameters = new DynamicParameters();
                parameters.Add("DepartmentID", id, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Department>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> CreateAsync(Department entity)
        {
            try
            {
                var query = "INSERT INTO Department (DeptId, DepartmentName) VALUES (@DepartmentID, @DepartmentName)";

                var parameters = new DynamicParameters();
                parameters.Add("DepartmentID", entity.DepartmentID, DbType.String);
                parameters.Add("DepartmentName", entity.DepartmentName, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(Department entity)
        {

            try
            {
                var query = "UPDATE Department SET DepartmentID = @DepartmentID, DepartmentName = @DepartmentName  WHERE DepartmentID = @DepartmentID";

                var parameters = new DynamicParameters();
                parameters.Add("DepartmentID", entity.DepartmentID, DbType.String);
                parameters.Add("DepartmentName", entity.DepartmentName, DbType.String);


                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> DeleteAsync(Department entity)
        {
            try
            {
                var query = "DELETE FROM Department WHERE DeptId = @DepartmentID";

                var parameters = new DynamicParameters();
                parameters.Add("DepartmentID", entity.DepartmentID, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}
