using Application.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.CandidateService.Implementation;
using Services.CandidateService.Interface;

namespace Sigma.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : BaseController
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost]
        public async Task<dynamic> CreateOrUpdate([FromBody] UpsertCandidate candidate, CancellationToken cancellationToken)
        {

            if (!ModelState.IsValid)
            {
                return ValidationResponse(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());
            }

            var result = await _candidateService.UpsertCandidate(candidate, cancellationToken);
            return Ok(result);
        }
    }
}
