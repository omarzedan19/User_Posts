using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_project.Controllers.models;

namespace test_project.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
        private readonly AppDbContext dbContext;

        public UserController(AppDbContext dbContext)
        {
           this.dbContext=dbContext;
        }
        /*
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return dbContext.users.ToList();
        }

        */
        [HttpPost]
        public void Adduser([FromBody] User user)
        {
            dbContext.users.Add(user);
            dbContext.SaveChanges();
        }
        
        [HttpDelete("{id}")]
        public void Deleteuser(int id)
        {

            var filteredUsers = dbContext.users.FirstOrDefault(user => user.Id.Equals(id));
            if (filteredUsers != null)
                dbContext.users.Remove(filteredUsers);
            dbContext.SaveChanges();
        }
        
        
        
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            return dbContext.users.FirstOrDefault(user => user.Id.Equals(id));
        }
        

        /* public UserController(Iuser firstuser)
         {
             dbContext = firstuser;
         }


         [HttpPost]
         public void Adduser( [FromBody] User user)
         {
             //dbContext.Adduser(user);
             dbContext.Add(user);

         }

         [HttpDelete("{id}")]
         public void Deleteuser(int id)
         {
             // dbContext.Deleteuser(id);
             dbContext.Remove(id);

         }

         [HttpGet]
         public List<User> GetAllUsers()
         {
           return  dbContext.GetAllUsers();
         }

         [HttpGet("{id}")]
         public User GetUser(int id)
         {
             return dbContext.GetUser(id);
         }
        */
    }

}
