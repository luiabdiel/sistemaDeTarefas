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

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userById = await GetUserById(id);

            if(userById == null)
            {
                throw new Exception($"UserId: {userById} not found");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<UserModel> CreateUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await GetUserById(id);

            if (userById == null)
            {
                throw new Exception($"UserId: {userById} not found");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
