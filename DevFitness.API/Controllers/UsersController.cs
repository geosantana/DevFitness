﻿using AutoMapper;
using DevFitness.API.Core.Entites;
using DevFitness.API.Models.inputModels;
using DevFitness.API.Models.viewModels;
using DevFitness.API.Persistence;
using Microsoft.AspNetCore.Http;
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
        private readonly IMapper _mapper;

        public UsersController(DevFitnessDbContext  dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        // api/users/5
        /// <summary>
        /// Retornar detalhes de usuário
        /// </summary>        
        /// <param name="id">Identificador de usuário</param>
        /// <returns>Objeto de detalhes do usuário.</returns>
        /// <response code="404">Usuário não encontrado.</response>
        /// <response code="000">Usuário encontrado com sucesso</response>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            //var userViewModel = new UserViewModel(user.Id, user.FullName, user.Height, user.Weight, user.BirthDate);
            var userViewModel = _mapper.Map<UserViewModel>(user);

            return Ok(userViewModel);
        }

        // api/users
        /// <summary>
        /// Cadastrar um usuário
        /// </summary>
        /// <remarks>
        /// Requisição de exemplo:
        /// {
        /// "fullName": "Luis Dev"
        /// "height": "1,72"
        /// "weight": 70
        /// "birthDate": "1992-01-01 00:00:00"
        /// }
        /// </remarks>
        /// <param name="inputModel">Objeto com dados de usuário</param>
        /// <returns>Objeto criado.</returns>
        /// <response code="201">Objeto criado com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] CreateuserInputModel inputModel)
        {
            //var user = new User(inputModel.FullName, inputModel.Height, inputModel.Weight, inputModel.BirthDate);            
            var user = _mapper.Map<User>(inputModel);
            
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
