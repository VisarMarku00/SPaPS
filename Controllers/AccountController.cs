using SPaPS.Models.AccountModels;
using Microsoft.AspNetCore.Mvc;
using SPaPS.Models;
using Microsoft.AspNetCore.Identity;
using SPaPS.Data;
using DataAccess.Services;
using SpaPS.Controllers;

namespace SPaPS.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly SPaPSContext _context;
        private readonly IEmailSenderEnhance _emailService;


        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, SPaPSContext context, IEmailSenderEnhance emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(userName: model.Email, password: model.Password, isPersistent: false, lockoutOnFailure: true);

            if (!result.Succeeded || result.IsLockedOut || result.IsNotAllowed)
            {
                ModelState.AddModelError("Error", "Wrong username or password!");
                return View(model);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {

            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists != null) 
            {
                ModelState.AddModelError("Error", "User already exists");
                return View(model);
            }

            IdentityUser user = new IdentityUser()
            {
                UserName=model.Email,
                Email = model.Email,
                PhoneNumber=model.PhoneNumber
            };

            var createUser= await _userManager.CreateAsync(user, model.Password);

            if (!createUser.Succeeded)
            {
                return (RedirectToAction("Index", "Home"));
            }

            user = await _userManager.FindByEmailAsync(model.Email);

            Client client = new Client()
            {
                UserId = user.Id,
                Name = model.Name,
                Address = model.Address,
                IdNo= model.IdNo,
                ClientTypeId=model.ClientTypeId,
                CityId=model.CityId,
                CountryId=model.CountryId
            };

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            //emailsetup emailsetup = new emailsetup()
            //{
            //    to = model.email,
            //    username = model.email,
            //    password = model.password,
            //    template = "register",
            //    requestpath = _emailservice.postalrequest(request)
            //};

            //await _emailservice.sendemailasync(emailsetup);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
