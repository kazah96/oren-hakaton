namespace OrenHakaton.Models.DtoModels
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using OrenHakaton.Controllers;

    [DataContract]
    public class UsersDto : IEntityDto
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string Telephone { get; set; }

        [DataMember]
        public string Mail { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public List<Apartments> Apartments { get; } = new List<Apartments>();
    }
}