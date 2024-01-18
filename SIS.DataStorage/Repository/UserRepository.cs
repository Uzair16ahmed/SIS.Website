using Dapper;
using Microsoft.Extensions.Configuration;
using SIS.DataStorage.Interfaces;
using SIS.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.DataStorage.Repository
{
  public  class UserRepository : BaseRepository,IUserRepository
    {

        public UserRepository(IConfiguration configuration): base(configuration)
        { }

        public async Task<List<User>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM UserRegistration";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<User>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM UserRegistration WHERE Userid = @Userid";

                var parameters = new DynamicParameters();
                parameters.Add("UserId", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<User>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> CreateAsync(User entity)
        {
            try
            {
                var query = "INSERT INTO UserRegistration (Username, Password, Confirmpwd,Email,Gender,MaritalStatus) VALUES (@Username, @Password, @Confirmpwd,@Email,@Gender,@MaritalStatus)";

                var parameters = new DynamicParameters();
                parameters.Add("Username", entity.Username, DbType.String);
                parameters.Add("Password", entity.Password, DbType.String);
                parameters.Add("Confirmpwd", entity.Confirmpwd, DbType.String);
                parameters.Add("Email", entity.Email, DbType.String);
                parameters.Add("Gender", entity.Gender, DbType.String);
                parameters.Add("MaritalStatus", entity.MaritalStatus, DbType.String);

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

        public async Task<int> UpdateAsync(User entity)
        {
 
            try
            {
                var query = "UPDATE UserRegistration SET Username = @Username, Password = @Password, Confirmpwd = @Confirmpwd, Email = @Email, Gender = @Gender, MaritalStatus = @MaritalStatus WHERE UserId = @UserId";

                var parameters = new DynamicParameters();
                parameters.Add("Username", entity.Username, DbType.String);
                parameters.Add("Password", entity.Password, DbType.String);
                parameters.Add("Confirmpwd", entity.Confirmpwd, DbType.String);
                parameters.Add("Email", entity.Email, DbType.String);
                parameters.Add("Gender", entity.Gender, DbType.String);
                parameters.Add("MaritalStatus", entity.MaritalStatus, DbType.String);

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

        public async Task<int> DeleteAsync(User entity)
        {
            try
            {
                var query = "DELETE FROM UserRegistration WHERE UserId = @UserId";

                var parameters = new DynamicParameters();
                parameters.Add("UserId", entity.UserId, DbType.Int32);

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
