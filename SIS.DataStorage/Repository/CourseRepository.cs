using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using SIS.DataStorage.Interfaces;
using SIS.Models.Models;


namespace SIS.DataStorage.Repository
{
    public class CourseRepository : BaseRepository, ICourseRepository
    {
        public CourseRepository(IConfiguration configuration) : base(configuration)
        { }
        public async Task<List<Courses>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM Course";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Courses>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Courses> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM Course WHERE CourseID = @CourseID";

                var parameters = new DynamicParameters();
                parameters.Add("CourseID", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Courses>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> CreateAsync(Courses entity)
        {
            try
            {
                var query = "INSERT INTO Course (Title, CourseCredits, DepartmentID) VALUES (@Title, @CourseCredits, @DepartmentID)";

                var parameters = new DynamicParameters();
                parameters.Add("Title", entity.Title, DbType.String);
                parameters.Add("CourseCredits", entity.Credits, DbType.String);
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

        public async Task<int> UpdateAsync(Courses entity)
        {

            try
            {
                var query = "UPDATE Course SET Title = @Title, CourseCredits = @CourseCredits, DepartmentID = @DepartmentID WHERE CourseID = @CourseID";

                var parameters = new DynamicParameters();
                parameters.Add("Title", entity.Title, DbType.String);
                parameters.Add("CourseCredits", entity.Credits, DbType.Int32);
                parameters.Add("DepartmentID", entity.DepartmentID, DbType.Int32);


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

        public async Task<int> DeleteAsync(Courses entity)
        {
            try
            {
                var query = "DELETE FROM Course WHERE CourseID = @CourseID";

                var parameters = new DynamicParameters();
                parameters.Add("CourseID", entity.CourseID, DbType.Int32);

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