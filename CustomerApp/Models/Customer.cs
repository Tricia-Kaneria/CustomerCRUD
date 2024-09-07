using System.ComponentModel.DataAnnotations;
namespace CustomerApp.Models
{
    public class Customer
    {
        [Key]
        [Display(Name = "Id")]
        public int id { get; set; }

        [StringLength(75)]
        [Display(Name = "First Name")]
        [Required]
        public string firstName { get; set; } = "";

        [StringLength(75)]
        [Display(Name = "Last Name")]
        [Required]
        public string lastName { get; set; } = "";

        [StringLength(50)]
        [Display(Name = "Tel No.")]
        [Required]
        public string phoneNo { get; set; } = "";

        [StringLength(75)]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Required]
        public string email { get; set; } = "";
    }
}
