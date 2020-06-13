namespace OrenHakaton.Models.DtoModels
{
    using System.Collections.Generic;

    using OrenHakaton.Controllers;

    public class EmployeesMCDto : IEntityDto
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Specialties> Specialties { get; } = new List<Specialties>();
        public List<ManagementCompanies> ManagementCompanies { get; } = new List<ManagementCompanies>();
    }
}