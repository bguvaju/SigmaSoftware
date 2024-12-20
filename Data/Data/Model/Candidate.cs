using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Candidate : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? LastName { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public DateTime? TimeToCall { get; set; }

        public string? LinkedInProfile { get; set; }

        public string? GithubProfile { get; set; }

        public string? Comment { get; set; }
    }
}
