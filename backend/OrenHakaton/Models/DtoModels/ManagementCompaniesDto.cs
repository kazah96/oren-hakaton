namespace OrenHakaton.Models.DtoModels
{
    using System.Collections.Generic;

    using OrenHakaton.Controllers;

    public class ManagementCompaniesDto : IEntityDto
    {
        public int ManagementCompanyId { get; set; }
        public string Title { get; set; }
        public string Yandex { get; set; }
        public string Google { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public List<Houses> Houses { get; } = new List<Houses>();
    }
}