using Microsoft.EntityFrameworkCore;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Interfaces;
using IdentityService.Infrastructure.Persistence;

namespace IdentityService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IdentityDbContext _context;

    public UserRepository(IdentityDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> ExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }
}
