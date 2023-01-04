using System;
using BloodeAPI.Interfaces;
using BloodeAPI.Models;
using BloodeAPI.Utilities;
using Microsoft.EntityFrameworkCore;

namespace BloodeAPI.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly BlooddonateContext _context;

        public AuthRepository(BlooddonateContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            user.Password = HashUtils.GenerateHashing(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> FindByUsernameAsync(string username)
        {
            return  (await _context.Users.FirstOrDefaultAsync((u) => u.PhoneNumber == username));
        }

        public bool VerifyPassword(User user,string password)
        {
            return VerifyPasswordHash(password, user.Password);
        }

        private bool VerifyPasswordHash(string password1, string password2)
        {
            return HashUtils.GenerateHashing(password1) == password2;
        }
    }

}

