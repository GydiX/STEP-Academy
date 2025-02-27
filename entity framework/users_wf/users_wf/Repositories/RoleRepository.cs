using Microsoft.EntityFrameworkCore;
using users_wf.Models;

namespace users_wf.Repositories
{
    public class RoleRepository
    {
        private readonly AppDbContext _context;
        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddRoleAsync(string name)
        {
            try
            {

                if (!(await IsUniqueAsync(name)))
                {
                    Console.WriteLine($"Role {name} is already exists");
                    return false;
                }

                var role = new Role
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name.ToLower()
                };

                await _context.Roles.AddAsync(role);
                var res = await _context.SaveChangesAsync();
                return res > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private async Task<bool> IsUniqueAsync(string roleName)
        {
            var role = await FindRoleByNameAsync(roleName);
            return role == null;
        }

        public async Task<Role?> FindRoleByIdAsync(string id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            return role;
        }

        public async Task<Role?> FindRoleByNameAsync(string name, bool includes = false)
        {
            if (includes)
            {
                var role = await _context.Roles
                    .Include(r => r.Users)
                    .FirstOrDefaultAsync(r => r.Name == name.ToLower());
                return role;
            }
            else
            {
                var role = await _context.Roles
                    .FirstOrDefaultAsync(r => r.Name == name.ToLower());
                return role;
            }
        }
    }
}
