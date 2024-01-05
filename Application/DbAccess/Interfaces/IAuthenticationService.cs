using Domain.Common;
using InTimeCourier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DbAccess.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ApiResponse> MakeLogin(LoginRequest login);
    }
}
