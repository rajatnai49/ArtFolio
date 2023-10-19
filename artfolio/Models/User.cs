using System.Collections.Generic;

namespace artfolio.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] DisplayPicture { get; set; }
        public string WorkDescription { get; set; }
        public byte[] WorkImage { get; set; }
        public string Password { get; set; }

        public List<Photo> Photos { get; set; } = new List<Photo>();
        public Customization Customization { get; set; }
        public Contact Contact { get; set; }
    }
}
