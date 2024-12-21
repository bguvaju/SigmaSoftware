using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.IntegrationTest.SeedData
{
    public class CandidateData
    {
        public static void AgentsSeedData(ApplicationDbContext context)
        {
            var candidates = new List<Candidate>
            {
                new Candidate
                {
                    Id = "deda8999-58fb-4911-b20b-fe5064d59c4e",
                    first_name = "Bikram",
                    last_name = "Guvaju",
                    phone_number = "123-456-7890",
                    email = "bikram.guvaju@yopmail.com",
                    time_to_call = DateTime.UtcNow.AddHours(1),
                    linkedin_profile = "https://www.linkedin.com/in/bikram-guvaju",
                    github_profile = "https://github.com/bikram-guvaju",
                    comment = "Experienced software engineer."
                },
                new Candidate
                {
                    Id = "9112de33-623a-4d7a-a38f-e1dcc600f8af",
                    first_name = "Valeria",
                    last_name = "Semendiai",
                    phone_number = "987-654-3210",
                    email = "valeria.semendiai@mailinator.com",
                    time_to_call = DateTime.UtcNow.AddHours(2),
                    linkedin_profile = "https://www.linkedin.com/in/valeria-semendiai",
                    github_profile = "https://github.com/valeria-semendiai",
                    comment = "test"
                }
            };
            context.AddRange(candidates);
            context.SaveChanges();
        }
    }
}
