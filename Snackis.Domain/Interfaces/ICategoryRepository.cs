using Snackis.Domain.Entities;

namespace Snackis.Infrastructure.Repositories
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task DeleteAsync(int id);
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
    }
}