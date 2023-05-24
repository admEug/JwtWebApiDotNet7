using System.Security.Claims;

namespace JwtWebApiDotNet7.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetMyName()
        {
            var result = string.Empty;
            if(_httpContextAccessor.HttpContext is not null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }

		public List<string> GetMyRoles()
		{
			var result = new List<string>();

			if (_httpContextAccessor.HttpContext is not null)
			{
                var roleClaims = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.Role);
				result = roleClaims?.Select(c => c.Value).ToList();
			}

			return result;
		}
	}
}
