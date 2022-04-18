using System.ComponentModel.DataAnnotations;

namespace PhoneBookWeb.Models
{
    public class BaseContact
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(11)]
        public string PhoneNo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
    }

    public class UpdateContact : BaseContact
    {
        public int Id { get; set; }
    }

    public class DeleteContact
    {
        public int Id { get; set; }
    }

    public class Contacts
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }
    }

    public class ContactFilter
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(11)]
        public string PhoneNo { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }
    }
}