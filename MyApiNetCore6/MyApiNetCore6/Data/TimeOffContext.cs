using Microsoft.EntityFrameworkCore;

namespace MyApiNetCore6.Data
{
    public class TimeOffContext: DbContext
    {
        public TimeOffContext(DbContextOptions<TimeOffContext> options): base(options) 
        {

        }
        #region DBSet
        public DbSet<TimeOff> ? TimeOffs { get; set; }
        #endregion
    }
}
