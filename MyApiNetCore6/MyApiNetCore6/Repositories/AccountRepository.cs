using Microsoft.AspNetCore.Identity;
using MyApiNetCore6.Models;
using MyApiNetCore6.Data;

namespace MyApiNetCore6.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public Task<string> SignInAsync(SignIn model)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> SignUpAsync(SignUp model)
        {
            throw new NotImplementedException();
        }
    }
}
