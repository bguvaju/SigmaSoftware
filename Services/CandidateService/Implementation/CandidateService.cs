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
                            .FirstOrDefaultAsync(c => c.Email == candidate.Email);
                if (existingCandidate != null)
                {
                    existingCandidate.FirstName = candidate.FirstName;
                    existingCandidate.LastName = candidate.LastName;
                    existingCandidate.PhoneNumber = candidate.PhoneNumber;
                    existingCandidate.Email = candidate.Email;
                    existingCandidate.TimeToCall = candidate.TimeToCall;
                    existingCandidate.LinkedInProfile = candidate.LinkedInProfile;
                    existingCandidate.GithubProfile = candidate.GithubProfile;
                    existingCandidate.Comment = candidate.Comment;
                    _context.Candidates.Update(existingCandidate);
                    successMessage = ResponseConstants.CandidateUpdateSuccess;
                    result = existingCandidate;
                }
                else
                {
                    var newCandidate = new Candidate
                    {
                        FirstName = candidate.FirstName,
                        LastName = candidate.LastName,
                        PhoneNumber = candidate.PhoneNumber,
                        Email = candidate.Email,
                        TimeToCall = candidate.TimeToCall,
                        LinkedInProfile = candidate.LinkedInProfile,
                        GithubProfile = candidate.GithubProfile,
                        Comment = candidate.Comment
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
