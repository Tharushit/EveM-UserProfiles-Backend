using Evem_Backend.DTO;
using Evem_Backend.Interfaces.Repositories;
using Evem_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evem_Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EvemContext _context;

        public UserRepository(EvemContext context)
        {
            _context = context;
        }
       

        public async Task<bool> UpdateUserRole(int id,int eventIdOfUser, UpdateUserRoleDTO request)
        {
            var nullUser = new UserEventRole();
            nullUser.Id = 0;
            var eventTableRow = _context.UserEventRoles.Where(eventTableRow => eventTableRow.EmployeeId == id&& eventTableRow.EventId== eventIdOfUser).FirstOrDefault() == null ? nullUser : _context.UserEventRoles.Where(eventTableRow => eventTableRow.EmployeeId == id && eventTableRow.EventId == eventIdOfUser).FirstOrDefault();

            if (eventTableRow.Id == 0)
            {
                return false;
            }
            try
            {
                eventTableRow.EmployeeRole = request.EmployeeRole;
                _context.Update(eventTableRow);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> AddUserToEvent(AddUserToEventDTO request)
        {
          
            if (request == null)
            {
                return false;
            }
            try
            {
                var userEventTable = new UserEventRole
                {
                    EventId = request.EventId,
                    EmployeeId = request.EmployeeId,
                    EmployeeRole = request.EmployeeRole
                };
                _context.UserEventRoles.Add(userEventTable);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<List<UserEventRole>> getCommiteeUsers(int eventIdOfUser, string userRole)
        {
            return await _context.UserEventRoles.Where(e => e.EmployeeRole ==userRole && e.EventId== eventIdOfUser).ToListAsync();

        }

        public async Task<bool> RemoveUserFromEvent(int userId,int eventId)
        {
            var nullEvent = new UserEventRole();
            nullEvent.Id = 0;

            var eventTableRow = _context.UserEventRoles.Where(eventTableRow => eventTableRow.EventId == eventId&&eventTableRow.EmployeeId==userId).FirstOrDefault() == null ? nullEvent : _context.UserEventRoles.Where(eventTableRow => eventTableRow.EventId == eventId && eventTableRow.EmployeeId == userId).FirstOrDefault();

            if (eventTableRow.EventId == 0)
            {
                return false;
            }
            try
            {

                _context.UserEventRoles.Remove(eventTableRow);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }

   
}
