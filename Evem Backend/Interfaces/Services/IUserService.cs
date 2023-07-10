using Evem_Backend.DTO;
using Evem_Backend.Models;

namespace Evem_Backend.Interfaces.Services
{
    public interface IUserService 
    {

        public Task<bool> UpdateUserRole(int id, int eventIdOfUser, UpdateUserRoleDTO request);

        public Task<List<UserEventRole>> getCommiteeUsers(int eventIdOfUser, string userRole);

        public Task<bool> RemoveUserFromEvent(int userId, int eventId);

        public Task<bool> AddUserToEvent(AddUserToEventDTO request);

    }
}
