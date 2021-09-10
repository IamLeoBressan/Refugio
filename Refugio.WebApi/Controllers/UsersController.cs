﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Refugio.Seguranca;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController: ControllerBase
    {
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;
        private readonly IConfiguration configuration;

        public UsersController(UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CriarUsuario(RegisterModel model)
        {
            var user = new Usuario
            {
                Nome = model.Nome,
                Sobrenome = model.Sobrenome,
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                return Ok(BuildToken(model.ToLoginModel()));
            else
                return BadRequest(result.Errors);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Login(LoginModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password,
                 isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return BuildToken(model);
            }
            else
            {
                ModelState.AddModelError("mensagens", "Usuário ou senha incorreto.");
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        public async Task<Usuario> BuscarUsuario()
        {
            var login = User.Identity.Name;

            var usuario = await userManager.FindByNameAsync(login);

            return usuario;
        }

        private UserToken BuildToken(LoginModel model)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, model.UserName),
                new Claim("UserName", model.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
