using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SystemTasksDBContext _dbContext;

        public UserRepository(SystemTasksDBContext systemTasksDBContext)
        {
            _dbContext = systemTasksDBContext;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<UserModel> UpdateUser(UserModel user, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> CreateUser(UserModel user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user;
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
