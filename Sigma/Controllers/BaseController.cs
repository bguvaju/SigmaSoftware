using Application.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Sigma.Controllers
{
    public class BaseController : ControllerBase
    {
        protected object HttpResponse(int statusCode, string msg, object data)
       => StatusCode(statusCode, new
       {
           Code = statusCode,
           Message = msg,
           Data = data
       });
        protected object HttpResponse(int statusCode, string msg)
        => StatusCode(statusCode, new
        {
            Code = statusCode,
            Message = msg,
        });
        protected object ValidationResponse(List<string> errors)
        => StatusCode(StatusCodes.Status422UnprocessableEntity, new
        {
            Code = 422,
            Message = ResponseConstants.ValidationError,
            Errors = errors ?? new List<string>()
        });

        protected object HttpResponsePaged(int statusCode, string msg, int TotalCount
             , int CurrentPage, int PageSize, object data)
      => StatusCode(statusCode, new
      {
          Code = statusCode,
          Message = msg,
          Pagination = new
          {
              TotalCount,
              TotalPage = (int)Math.Ceiling((decimal)TotalCount / (PageSize == 0 ? 1 : PageSize)),
              CurrentPage,
              PageSize
          },
          Data = data
      });
        protected object ErrorResponse(int statusCode, string msg)
         => new
         {
             Code = statusCode,
             Message = msg,
             Errors = new string[] { msg }
         };
        protected object ErrorResponse(string msg)
         => BadRequest(new
         {
             Code = (int)HttpStatusCode.BadRequest,
             Message = msg,
             Errors = new string[] { msg }
         });
        
        protected string? GetPartnerScope()
        {
            string? scope = Request?.Headers["scope"];
            return (scope ?? "").ToUpper();
        }
        protected string GetBaseUrl()
        {
            var host = Request.Host.ToUriComponent();
            return $"{Request.Scheme}://{host}";
        }
    }
}
