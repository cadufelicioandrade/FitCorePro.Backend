namespace FitCorePro.Nutrition.Planning.Application.UseCases.Request
{
    public class ApiMessagemResponse
    {
        public ApiMessagemResponse(string message)
        {
            Message = message;
        }

        public string Message { get; } = String.Empty;
    }
}
