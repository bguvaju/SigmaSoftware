using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.IntegrationTest.Dto
{
    public class CandidateDto
    {
        public string? Id { get; set; }
        public string? first_name { get; set; }

        public string? last_name { get; set; }

        public string? phone_number { get; set; }

        public string? email { get; set; }

        public DateTime? time_to_call { get; set; }

        public string? linkedin_profile { get; set; }

        public string? github_profile { get; set; }

        public string? comment { get; set; }
    }
}
