using System;
using AutoMapper;
using BloodeAPI.Interfaces;
using BloodeAPI.Models;
using BloodeAPI.ViewModels.Request;
using Microsoft.EntityFrameworkCore;

namespace BloodeAPI.Repositories
{
	public class UserRepository : IUserInterface
    {
        private readonly BlooddonateContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UserRepository> _logger;


        public UserRepository(BlooddonateContext context, ILogger<UserRepository> logger, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
        }

        public async Task<User?> GetUser(int id)
        {
            try
            {
                var user =  await this._context.Users.FirstOrDefaultAsync(usr => usr.Id == id);
                return user;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);
                return null;
            }
        }

    }
}

