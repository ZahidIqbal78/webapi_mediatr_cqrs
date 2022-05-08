using System.ComponentModel.DataAnnotations;

namespace webapi_mediatr_cqrs_example.Models
{
    public class Customer : BaseModel
    {
        [Required, StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? MiddleName { get; set; }

        [Required, StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(155)]
        public string? Email { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }

    }
}
