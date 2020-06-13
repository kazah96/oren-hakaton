namespace OrenHakaton.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore;

    public class OrenHakatonContext : DbContext
    {
        public DbSet<ManagementCompanies> ManagementCompanies { get; set; }
        public DbSet<Houses> Houses { get; set; }
        public DbSet<Apartments> Apartments { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Specialties> Specialties { get; set; }
        public DbSet<EmployeesMC> EmployeesMC { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<Polls> Polls { get; set; }
        public DbSet<Meetings> Meetings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=oren-hakaton.db");
    }

    public class ManagementCompanies
    {
        [Key]
        public int ManagementCompanyId { get; set; }
        public string Title { get; set; }
        public string Yandex { get; set; }
        public string Google { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public List<Houses> Houses { get; } = new List<Houses>();
    }

    public class Houses
    {
        [Key]
        public int HouseId { get; set; }
        public string Address { get; set; }
        public string ApartmentsCount { get; set; }
        public int State { get; set; }

        public List<Apartments> Apartments { get; } = new List<Apartments>();
    }

    public class Apartments
    {
        [Key]
        public int ApartmentId { get; set; }
        public string Number { get; set; }
        public string Layout { get; set; }
    }

    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public List<Apartments> Apartments { get; } = new List<Apartments>();
    }

    public class Specialties
    {
        [Key]
        public int SpecialityId { get; set; }
        public string Name { get; set; }
    }

    public class EmployeesMC
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Specialties> Specialties { get; } = new List<Specialties>();
        public List<ManagementCompanies> ManagementCompanies { get; } = new List<ManagementCompanies>();
    }

    public class Requests
    {
        [Key]
        public int RequestId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }

        public List<ManagementCompanies> ManagementCompanies { get; } = new List<ManagementCompanies>();
    }

    public class Polls
    {
        [Key]
        public int PollId { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }

        public List<ManagementCompanies> ManagementCompanies { get; } = new List<ManagementCompanies>();
    }

    public class Meetings
    {
        [Key]
        public int PollId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Result { get; set; }

        public List<Houses> Houses { get; } = new List<Houses>();
        public List<ManagementCompanies> ManagementCompanies { get; } = new List<ManagementCompanies>();
    }
}