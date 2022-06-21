using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Moq;
using Pizza.API.Filters;
using System.Reflection;
using System.Security.Claims;
using Xunit;

namespace Pizza.API.Test.Filters
{
    public class HttpGlobalExceptionFilterShould
    {
        private readonly HttpGlobalExceptionFilter filter;
        public HttpGlobalExceptionFilterShould()
        {
            var logger = new Mock<ILogger<HttpGlobalExceptionFilter>>();
            filter = new HttpGlobalExceptionFilter(logger.Object);
        }
        [Fact]
        public void VerifyOnArgumentExceptionReturns400WithNullStackTrace()
        {
            Exception exception;
            try
            {
                throw new ArgumentException("Test Argument Exception")
                {
                    Source = "VerifyOnArgumentExceptionReturns400WithNullStackTrace"
                };
            }
            catch (Exception e)
            {
                exception = e;
            }
            Xunit.Assert.True(!string.IsNullOrEmpty(exception.StackTrace));
            var httpResponseStatusCode = 0;
            var httpResponse = new Mock<HttpResponse>();
            httpResponse.SetupSet((c) => c.StatusCode = It.IsAny<int>()).Callback<int>(x => httpResponseStatusCode = x);
            var exceptionContext = CreateExceptionContext(httpResponse.Object, exception);
            Xunit.Assert.False(exceptionContext.ExceptionHandled);
            filter.OnException(exceptionContext);
            Xunit.Assert.False(exceptionContext.ExceptionHandled);
        }

        private static ExceptionContext CreateExceptionContext(HttpResponse httpResponse, Exception ex)
        {
            var actionContext = GetActionContext("controller name", httpResponse);
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = ex
            };
            return exceptionContext;
        }

        private static ActionContext GetActionContext(string controllerName, HttpResponse httpResponse, ClaimsPrincipal user = default)
        {
            var request = new Mock<HttpRequest>();
            request.SetupGet(r => r.Scheme).Returns("https");
            request.SetupGet(r => r.Path).Returns("/home");
            request.SetupGet(r => r.Host).Returns(new HostString("10.155.81.80"));

            var itemDist = new Dictionary<object, object>();
            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(r => r.Request).Returns(request.Object);
            httpContext.SetupGet(c => c.Items).Returns(() => itemDist);
            httpContext.SetupGet(c => c.Response).Returns(() => httpResponse);
            httpContext.SetupGet(c => c.User).Returns(user);

            return new ActionContext
            {
                HttpContext = httpContext.Object,
                RouteData = new Microsoft.AspNetCore.Routing.RouteData { Values = { ["data"] = "Fake data" } },
                ActionDescriptor = new ControllerActionDescriptor
                {
                    ActionName = "GET",
                    ControllerName = controllerName,
                    ControllerTypeInfo = new Mock<TypeInfo>().Object,
                    MethodInfo = new Mock<MethodInfo>().Object,
                }
            };
        }


    }
}
