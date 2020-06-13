namespace OrenHakaton.Models.DtoModels
{
    using OrenHakaton.Controllers;

    public class SpecialtiesDto : IEntityDto
    {
        public int SpecialityId { get; set; }
        public string Name { get; set; }
    }
}