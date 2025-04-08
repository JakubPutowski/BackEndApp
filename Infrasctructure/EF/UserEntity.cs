using ApplicationCore.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrasctructure.EF;

public class UserEntity : IdentityUser
{
    public UserDetails Details {get; set; }
}