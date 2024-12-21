using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    [Table("candidate", Schema = "public")]
    public class Candidate : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string? first_name { get; set; }

        [Required]
        [MaxLength(100)]
        public string? last_name { get; set; }

        [Phone]
        public string? phone_number { get; set; }

        [Required]
        [EmailAddress]
        public string? email { get; set; }

        public DateTime? time_to_call { get; set; }

        public string? linkedin_profile { get; set; }

        public string? github_profile { get; set; }

        public string? comment { get; set; }
    }
}
