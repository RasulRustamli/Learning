using Learning.Models;
using Learning.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = new AppUser()
            {
                Surname = vm.Surname,
                Name = vm.Name,
                Email = vm.Email,
                UserName = vm.UserName,
            };
            var result = await userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVm vm)
        {
            var user = await userManager.FindByEmailAsync(vm.UsernameOrEmail);
            if(user == null)
            {
                user=await userManager.FindByNameAsync(vm.UsernameOrEmail);
                if (user == null) throw new Exception("UserName or Password incorrect");
            }
            var result =  await signInManager.CheckPasswordSignInAsync(user, vm.Password, false);
            if(!result.Succeeded) throw new Exception("UserName or Password incorrect");

            await signInManager.SignInAsync(user, false);
            return View();

        }
    }
}
