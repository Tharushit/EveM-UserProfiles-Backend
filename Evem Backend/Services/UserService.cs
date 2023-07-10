using Evem_Backend.DTO;
using Evem_Backend.Interfaces.Repositories;
using Evem_Backend.Interfaces.Services;
using Evem_Backend.Models;
using Evem_Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Evem_Backend.Services
{
    public class UserService : IUserService

    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }


        public async Task<bool> UpdateUserRole(int id, int eventIdOfUser, UpdateUserRoleDTO request)
        {
            var result = await _userRepository.UpdateUserRole(id,eventIdOfUser, request);
            return result;
        }

        public async Task<List<UserEventRole>> getCommiteeUsers(int eventIdOfUser, string userRole)
        {
            var commiteeUsersList = await _userRepository.getCommiteeUsers(eventIdOfUser,userRole);
            return commiteeUsersList;
        }

        public async Task<bool> RemoveUserFromEvent(int userId, int eventId)
        {
            return await _userRepository.RemoveUserFromEvent(userId,eventId);
        }

        public async Task<bool> AddUserToEvent(AddUserToEventDTO request)
        {
            return await _userRepository.AddUserToEvent(request);
        }
    }
}
