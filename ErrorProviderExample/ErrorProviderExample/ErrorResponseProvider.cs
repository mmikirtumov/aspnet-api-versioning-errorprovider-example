using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace ErrorProviderExample
{
    /// <summary>
    /// You can use this class but put in Startup.cs the following code
    /// services.AddApiVersioning(v =>{
    ///     v.ErrorResponses = new ErrorResponseProvider();
    /// });
    /// </summary>
    public class ErrorResponseProvider : IErrorResponseProvider
    {
        public IActionResult CreateResponse(ErrorResponseContext context)
        {
            HttpException exception = GenerateHttpExceptionMessage(context.StatusCode);

            return new ObjectResult(exception) { StatusCode = context.StatusCode };
        }

        private class HttpException
        {
            public int ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
            public string AdditionalParams1 { get; set; }

            // put any count of parameters as you want
        }

        private static HttpException GenerateHttpExceptionMessage(int statusCode)
        {
            if (statusCode == 404)
            {
                return new HttpException()
                {
                    ErrorCode = 1,
                    ErrorMessage = "Error message for 404",
                    AdditionalParams1 = "Some additional params"
                };
            }

            if (statusCode == 400)
            {
                return new HttpException()
                {
                    ErrorCode = 2,
                    ErrorMessage = "Error message for 400",
                    AdditionalParams1 = "Some additional params"
                };
            }

            if (statusCode == 405)
            {
                return new HttpException()
                {
                    ErrorCode = 3,
                    ErrorMessage = "Error message for 405",
                    AdditionalParams1 = "Some additional params"
                };
            }

            //put any logic that you want

            return new HttpException()
            {
                ErrorCode = 4,
                ErrorMessage = "General Message",
                AdditionalParams1 = "General Additional params"
            };

        }
    }
}
