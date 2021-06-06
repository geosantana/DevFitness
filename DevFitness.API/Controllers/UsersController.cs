using DevFitness.API.Core.Entites;
using DevFitness.API.Models.inputModels;
using DevFitness.API.Models.viewModels;
using DevFitness.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFitness.API.Controllers
{
    //  api/users
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DevFitnessDbContext _dbContext;

        public UsersController(DevFitnessDbContext  dbContext)
        {
            _dbContext = dbContext;
        }
        // api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            var userViewModel = new UserViewModel(user.Id, user.FullName, user.Height, user.Weight, user.BirthDate);
            return Ok(userViewModel);
        }

        // api/users
        [HttpPost]
        public IActionResult Post([FromBody] CreateuserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Height, inputModel.Weight, inputModel.BirthDate);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            // return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = user.Id }, inputModel);
        }

        // api/users/4
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserInputModel inputModel)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound();

            user.Update(inputModel.Height, inputModel.Weight);

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
