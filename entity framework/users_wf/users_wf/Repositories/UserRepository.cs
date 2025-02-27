using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using users_wf.DTOs;
using users_wf.Models;

namespace users_wf.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;
        private readonly RoleRepository _roleRepository;
        private readonly Mapper _mapper;

        public UserRepository(AppDbContext context, RoleRepository roleRepository, Mapper mapper)
        {
            _context = context;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<KeyValuePair<bool, string>> AddUserAsync(UserDTO dto)
        {
            if (!await IsUniqueEmailAsync(dto.Email))
            {
                return new KeyValuePair<bool, string>(false, $"Користувач з поштою '{dto.Email}' вже зареєстрований");
            }

            if (!await IsUniqueUserNameAsync(dto.UserName))
            {
                return new KeyValuePair<bool, string>(false, $"Ім'я користувача '{dto.UserName}' вже використовується");
            }

            var role = await _roleRepository.FindRoleByNameAsync(dto.Role);

            role ??= await _roleRepository.FindRoleByNameAsync("user");

            dto.Role = role.Id;

            // mapping - перетворення DTO у model
            //var user = new User
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Email = dto.Email.ToLower(),
            //    UserName = dto.UserName.ToLower(),
            //    FirstName = dto.FirstName,
            //    LastName = dto.LastName,
            //    Age = dto.Age,
            //    RoleId = role.Id
            //};

            // mapping через automapper
            var user = _mapper.Map<User>(dto);

            await _context.Users.AddAsync(user);
            var res = await _context.SaveChangesAsync();
            return new KeyValuePair<bool, string>(res > 0, string.Empty);
        }

        public async Task<User?> FindByEmailAsync(string email, bool loadRole = false)
        {
            return await FindByParamAsync(u => u.Email == email.ToLower(), loadRole);
        }

        public async Task<User?> FindByUserNameAsync(string userName, bool loadRole = false)
        {
            return await FindByParamAsync(u => u.UserName == userName.ToLower(), loadRole);
        }

        public async Task<User?> FindByIdAsync(string id, bool loadRole = false)
        {
            return await FindByParamAsync(u => u.Id == id, loadRole);
        }

        private async Task<User?> FindByParamAsync(Expression<Func<User, bool>> pred, bool loadRole = false)
        {
            var user = await _context.Users
                    .FirstOrDefaultAsync(pred);

            if (user == null)
            {
                return null;
            }

            if (loadRole)
            {
                await _context.Entry(user).Reference(u => u.Role).LoadAsync();
            }

            return user;
        }

        private async Task<bool> IsUniqueEmailAsync(string email)
        {
            return await FindByEmailAsync(email) == null;
        }

        private async Task<bool> IsUniqueUserNameAsync(string userName)
        {
            return await FindByUserNameAsync(userName) == null;
        }

        public async Task<KeyValuePair<bool, string>> LoginAsync(string email, string userName)
        {
            var user = await FindByEmailAsync(email);
            if (user == null)
            {
                return new KeyValuePair<bool, string>(false, "Пошта вказана невірно");
            }

            if(user.UserName != userName.ToLower())
            {
                return new KeyValuePair<bool, string>(false, "Ім'я користувача вказано невірно");
            }

            return new KeyValuePair<bool, string>(true, string.Empty);
        }
    }
}
