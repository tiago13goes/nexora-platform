namespace IdentityService.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
    Task<bool> ExistsAsync(string email);
}
