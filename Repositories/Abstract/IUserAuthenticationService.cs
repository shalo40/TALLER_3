using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TALLER_3.Models.DTO;

namespace TALLER_3.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task LogoutAsync();

        Task<Status> RegisterAsync(RegistrationModel model);
        Task<Status> ChangePasswordAsync(ChangePasswordModel model, string username);
    }
}