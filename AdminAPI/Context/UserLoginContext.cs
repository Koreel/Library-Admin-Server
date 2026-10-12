using AdminAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminAPI.Context;

public class UserLoginContext :DbContext
{
    public UserLoginContext(DbContextOptions<UserLoginContext> options) : base(options)
    {
            
    }
    
    DbSet<LoginRequestModel> LoginRequestSet { get; set; }
    
    public DbSet<User> Users { get; set; }
}
