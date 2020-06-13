namespace OrenHakaton.Models.DtoModels
{
    using System.Collections.Generic;

    using OrenHakaton.Controllers;

    public class HousesDto : IEntityDto
    {
        public int HouseId { get; set; }
        public string Address { get; set; }
        public string ApartmentsCount { get; set; }
        public int State { get; set; }

        public List<Apartments> Apartments { get; } = new List<Apartments>();
    }
}