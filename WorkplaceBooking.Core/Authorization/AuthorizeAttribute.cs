using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using WorkplaceBooking.Core.Contracts.Entities;

namespace WorkplaceBooking.Core.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // декоратор [AllowAnonymous] позволит игнорировать авторизацию
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // TODO: refactoring? make it cleaner?
            try
            {
                // authorization
                var userContext = context.HttpContext.Items["User"];
                if (userContext == null)
                    throw new Exception("Unauthorized");
                var user = ((Task<User>)(userContext)).Result;
                if (user == null)
                    throw new Exception("Unauthorized");

                // декоратор [Admin] 
                var adminRequired = context.ActionDescriptor.EndpointMetadata.OfType<AdminAttribute>().Any();
                if (adminRequired && user.Role != Role.Admin)
                    throw new Exception("Permission Denied");
            }
            catch (Exception ex)
            {
                context.Result = new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
