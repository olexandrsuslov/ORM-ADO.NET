using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kps_web_api.Context;
using kps_web_api.Entities;
using Microsoft.Data.SqlClient;

namespace kps_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public UserRoleController(StoreDbContext context)
        {
            _context = context;
        }

        // GET: api/UserRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetUserRoles()
        {
          if (_context.UserRoles == null)
          {
              return NotFound();
          }
            return await _context.UserRoles.ToListAsync();
        }

        // GET: api/UserRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRole>> GetUserRole(int id)
        {
          if (_context.UserRoles == null)
          {
              return NotFound();
          }
            var userRole = await _context.UserRoles.FindAsync(id);

            if (userRole == null)
            {
                return NotFound();
            }

            return userRole;
        }

        // PUT: api/UserRole/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRole(int id, UserRole userRole)
        {
            if (id != userRole.UserRoleId)
            {
                return BadRequest();
            }

            _context.Entry(userRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserRole
        [HttpPost]
        public async Task<ActionResult<UserRole>> PostUserRole(UserRole userRole)
        {
          if (_context.UserRoles == null)
          {
              return Problem("Entity set 'StoreDbContext.UserRoles'  is null.");
          }
            _context.UserRoles.Add(userRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserRole", new { id = userRole.UserRoleId }, userRole);
        }

        // DELETE: api/UserRole/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRole(int id)
        {
            if (_context.UserRoles == null)
            {
                return NotFound();
            }
            var userRole = await _context.UserRoles.FindAsync(id);
            if (userRole == null)
            {
                return NotFound();
            }

            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        [HttpPost] 
        [Route("AddWithAdoNet")] 
        public void AddEmployee(UserRole userRole)  
        {  
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = "Data Source=localhost;Initial Catalog=master;User=SA;Password=reallyStrongPwd123;TrustServerCertificate=true";
            SqlCommand sqlCmd = new SqlCommand();  
            sqlCmd.CommandType = CommandType.Text;  
            sqlCmd.CommandText = "INSERT INTO UserRoles (UserRoleID,RoleName,Token) Values (@UserRoleID,@RoleName,@Token)";  
            sqlCmd.Connection = myConnection;  
            
            sqlCmd.Parameters.AddWithValue("@UserRoleID", userRole.UserRoleId);  
            sqlCmd.Parameters.AddWithValue("@RoleName", userRole.RoleName);  
            sqlCmd.Parameters.AddWithValue("@Token", userRole.Token);  
            myConnection.Open();  
            int rowInserted = sqlCmd.ExecuteNonQuery();  
            myConnection.Close();  
        }  
        
        [HttpDelete("DeleteWithAdoNet/{id}")]
        public void DeleteEmployeeByID(int id)  
        {  
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = "Data Source=localhost;Initial Catalog=master;User=SA;Password=reallyStrongPwd123;TrustServerCertificate=true";
            SqlCommand sqlCmd = new SqlCommand();  
            sqlCmd.CommandType = CommandType.Text;  
            sqlCmd.CommandText = $"DELETE FROM UserRoles WHERE UserRoleID={id}";  
            sqlCmd.Connection = myConnection; 
            
            myConnection.Open();  
            int rowDeleted = sqlCmd.ExecuteNonQuery();  
            myConnection.Close();  
        }  
        
        
        private bool UserRoleExists(int id)
        {
            return (_context.UserRoles?.Any(e => e.UserRoleId == id)).GetValueOrDefault();
        }
    }
}
