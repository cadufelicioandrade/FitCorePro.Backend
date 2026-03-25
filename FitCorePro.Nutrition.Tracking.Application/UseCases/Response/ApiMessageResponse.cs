namespace FitCorePro.Nutrition.Tracking.Application.UseCases.Response
{
    public class ApiMessageResponse
    {
        public ApiMessageResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }

    }
}
