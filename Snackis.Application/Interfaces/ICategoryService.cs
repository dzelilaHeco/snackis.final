using Snackis.Domain.Entities;

namespace Snackis.Application.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(string name);
        Task DeleteAsync(int id);
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
    }
}