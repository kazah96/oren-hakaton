namespace OrenHakaton.Models.DtoModels
{
    using OrenHakaton.Controllers;

    public class ApartmentsDto : IEntityDto
    {
        public int ApartmentId { get; set; }
        public string Number { get; set; }
        public string Layout { get; set; }
    }
}