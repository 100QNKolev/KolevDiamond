using System.Net.Http.Headers;

namespace KolevDiamond.Web.Extensions
{
    public class JwtForwardingHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtForwardingHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var jwt = _httpContextAccessor.HttpContext?.User.FindFirst("jwt")?.Value;

            if (!string.IsNullOrEmpty(jwt))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
