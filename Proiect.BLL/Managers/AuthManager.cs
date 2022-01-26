using Microsoft.AspNetCore.Identity;
using Proiect.BLL.Interfaces;
using Proiect.BLL.Models;
using Proiect.DAL.Entities;
using Proiect.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.BLL.Managers
{
    

    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUnitOfWork _unitOfWork;

        public AuthManager(UserManager<User> userManager,
            SignInManager<User> signInManager,
            ITokenHelper tokenHelper,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHelper = tokenHelper;
            _unitOfWork = unitOfWork;
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null)
                return new LoginResult
                {
                    Success = false

                };
            else
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
                if (result.Succeeded)
                {
                    var token = await _tokenHelper.CreateAccessToken(user);

                    return new LoginResult
                    {
                        Success = true,
                        AccessToken = token

                    };
                }
                else
                    return new LoginResult
                    {
                        Success = false
                    };
            }
            

        }

        public async Task<bool> Register(RegisterModel registerModel)
        {
            var user = new User
            {
                Email = registerModel.Email,
                UserName = registerModel.Email
            };
            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, registerModel.Role);
                if (registerModel.Role == "Donator")
                {
                    var donor = new Donor
                    {
                        FirstName = registerModel.Email,
                        LastName = registerModel.Email,
                        User = user,
                        UserId = user.Id

                    };

                    await _unitOfWork.Donors.Create(donor);

                }

                else if(registerModel.Role == "Pacient")
                {
                    var patient = new Patient 
                    {
                        FirstName = registerModel.Email,
                        LastName = registerModel.Email,
                        User = user,
                        UserId = user.Id

                    };

                    await _unitOfWork.Patient.Create(patient);


                }
                else if(registerModel.Role == "Doctor")
                {
                    var doctor = new Doctor
                    {
                        FirstName = registerModel.Email,
                        LastName = registerModel.Email,
                        User = user,
                        UserId = user.Id
                    };
                }

                return true;

            }
            else
            {
                return false;
            }

        }
    }
}
