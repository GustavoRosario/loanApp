using Microsoft.EntityFrameworkCore;
using LoanApp.Domain.Entities;

namespace LoanApp.Infrastructure.Entity.Data
{
    public class LoanAppDbContext : DbContext
    {
        public LoanAppDbContext(DbContextOptions<LoanAppDbContext> options) : base(options)
        {
        }

        public DbSet<lo_application> lo_application { get; set; }
        public DbSet<lo_doctor_type> lo_doctor_type { get; set; }
        public DbSet<lo_identification_type> lo_identification_type { get; set; }
        public DbSet<lo_province> lo_province { get; set; }
        public DbSet<lo_sex> lo_sex { get; set; }
        public DbSet<lo_type_family_relationship> lo_type_family_relationship { get; set; }
        public DbSet<lo_loan_amount> lo_loan_amount { get; set; }
        public DbSet<lo_communication_channel> lo_communication_channel { get; set; }
        public DbSet<lo_year_of_residence> lo_year_of_residence { get; set; }
    }
}
