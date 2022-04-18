using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBookWeb.Databases.Contacts
{
    [Table("t_contact")]
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("f_name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required]
        [Column("f_phone_no", TypeName = "varchar(11)")]
        public string PhoneNo { get; set; }

        [Required]
        [Column("f_address", TypeName = "varchar(50)")]
        public string Address { get; set; }

        [Column("f_deleted")]
        public bool Deleted { get; set; }
    }
}
