namespace OrenHakaton.Models
{
    using OrenHakaton.Controllers;

    public class CheckUserDto : IEntityDto
    {
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}