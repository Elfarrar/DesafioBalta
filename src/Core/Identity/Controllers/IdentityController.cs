using Base.Configuration.Models;
using Base.Controllers;
using Identity.Helpers.Interfaces;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Identity.Controllers
{
    [Route("api/identity")]
    public class IdentityController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly IAutenticationHelper _autenticationHelper;

        public IdentityController(SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager,
                              IOptions<AppSettings> appSettings,
                              IAutenticationHelper autenticationHelper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _autenticationHelper = autenticationHelper;
        }

        [HttpPost("new_user")]
        public async Task<ActionResult> NewUser(NewUser newUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = newUser.Email,
                Email = newUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, newUser.Password);

            if (result.Succeeded)
            {
                return CustomResponse(await _autenticationHelper.GenerateJwt(newUser.Email));
            }

            foreach (var error in result.Errors)
            {
                AddProcessmentErrors(error.Description);
            }

            return CustomResponse();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLogin login)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password,
                false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await _autenticationHelper.GenerateJwt(login.Email));
            }

            if (result.IsLockedOut)
            {
                AddProcessmentErrors("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse();
            }

            AddProcessmentErrors("Usuário ou Senha incorretos");
            return CustomResponse();
        }
    }
}
