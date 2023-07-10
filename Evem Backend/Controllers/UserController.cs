using Evem_Backend.DTO;
using Evem_Backend.Interfaces.Services;
using Evem_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Evem_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;

        }


        [HttpPut("update-user-event-role/{id}/{eventIdOfUser}")]

        public async Task<IActionResult> UpdateUserRole(int id, int eventIdOfUser, UpdateUserRoleDTO request)
        {
            var result = await _userService.UpdateUserRole(id, eventIdOfUser, request);
            if (result)
            {
                return Ok("Updated Successfully.");

            }
            return BadRequest("Failed to Update");

        }

        [HttpGet("get-users/{eventIdOfUser}")]
        public async Task<IActionResult> getCommiteeUsers(int eventIdOfUser,string userRole)
        {
            try
            {
                var commiteeUserList = await _userService.getCommiteeUsers(eventIdOfUser,userRole);
                if (commiteeUserList.Count == 0)
                {
                    return NotFound();
                }
                List<CommitteeUserIdsDTO> pendingEventsList = new List<CommitteeUserIdsDTO>();

                foreach (var commiteeUser in commiteeUserList)
                {
                    pendingEventsList.Add(new CommitteeUserIdsDTO
                    {
                        EmployeeId = commiteeUser.EmployeeId,
                       
                    });
                }

                return Ok(pendingEventsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("remove-user-from-event/{userId}/{eventId}")]

        public async Task<IActionResult> RemoveUserFromEvent(int userId,int eventId)
        {
            var result = await _userService.RemoveUserFromEvent(userId,eventId);
            if (result)
            {
                return Ok("Deleted Successfully.");

            }
            return BadRequest("Failed to Delete");

        }

        [HttpPost("add-user-to-an-event")]

        public async Task<IActionResult> AddUserToEvent(AddUserToEventDTO request)
        {
           var result= await _userService.AddUserToEvent(request);
            if (result)
            {
                return Ok("Added successfully");
            }
            return BadRequest("Failed to add");
        }
    }
}
