namespace OrenHakaton.Models.DtoModels
{
    using System.Collections.Generic;

    using OrenHakaton.Controllers;

    public class RequestsDto : IEntityDto
    {
        public int RequestId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }

        public List<ManagementCompanies> ManagementCompanies { get; } = new List<ManagementCompanies>();
    }
}