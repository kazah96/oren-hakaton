namespace OrenHakaton.Models.DtoModels
{
    using System.Collections.Generic;

    using OrenHakaton.Controllers;

    public class PollsDto : IEntityDto
    {
        public int PollId { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }

        public List<ManagementCompanies> ManagementCompanies { get; } = new List<ManagementCompanies>();
    }
}