using Application.Common;
using Application.Constants;
using Application.Entities;
using Data;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Services.CandidateService.Interface;
using Services.HelperService;

namespace Services.CandidateService.Implementation
{
    public class CandidateService : ICandidateService
    {
        private readonly ApplicationDbContext _context;
        public CandidateService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResData<Candidate>> UpsertCandidate(UpsertCandidate candidate, CancellationToken cancellationToken)
        {
            ServiceResData<Candidate> serviceRes = new();
            Candidate result;
            string successMessage = string.Empty;
            try
            {
                var existingCandidate = await _context.Candidates
                            .FirstOrDefaultAsync(c => c.email == candidate.Email);
                if (existingCandidate != null)
                {
                    existingCandidate.first_name = candidate.FirstName;
                    existingCandidate.last_name = candidate.LastName;
                    existingCandidate.phone_number = candidate.PhoneNumber;
                    existingCandidate.email = candidate.Email;
                    existingCandidate.time_to_call = candidate.TimeToCall;
                    existingCandidate.linkedin_profile = candidate.LinkedInProfile;
                    existingCandidate.github_profile = candidate.GithubProfile;
                    existingCandidate.comment = candidate.Comment;
                    _context.Candidates.Update(existingCandidate);
                    successMessage = ResponseConstants.CandidateUpdateSuccess;
                    result = existingCandidate;
                }
                else
                {
                    var newCandidate = new Candidate
                    {
                        Id = Guid.NewGuid().ToString(),
                        first_name = candidate.FirstName,
                        last_name = candidate.LastName,
                        phone_number = candidate.PhoneNumber,
                        email = candidate.Email,
                        time_to_call = candidate.TimeToCall,
                        linkedin_profile = candidate.LinkedInProfile,
                        github_profile = candidate.GithubProfile,
                        comment = candidate.Comment
                    };
                    _context.Candidates.Add(newCandidate);
                    successMessage = ResponseConstants.CandidateCreateSuccess;
                    result = newCandidate;
                }
                await _context.SaveChangesAsync(); 
                serviceRes = new ServiceResData<Candidate>
                {
                    code = 200,
                    description = successMessage,
                    message = "Success",
                    Data = result
                };
                return serviceRes;
            }
            catch (Exception ex)
            {
                await Helper.ErrorLog(ex.ToString());
                serviceRes = new ServiceResData<Candidate>()
                {
                    code = 500,
                    description = ResponseConstants.CandidateCreateError,
                    message = ex.Message
                };
                return serviceRes;
            }
        }
    }
}
