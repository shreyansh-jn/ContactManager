using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_DataAccess.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "First Name should be less than 20 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Last Name should be less than 20 characters")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone number is invalid")]
        public string Phone { get; set; }

        //Status means that the user is marked deleted or not
        //By default it is always set to false
        [Required]
        public bool Status { get; set; } = false;
    }
}
