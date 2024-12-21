using Application.Common;
using Application.Entities;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CandidateService.Interface
{
    public interface ICandidateService
    {
        Task<ServiceResData<Candidate>> UpsertCandidate(UpsertCandidate candidate, CancellationToken cancellationToken);
    }
}
