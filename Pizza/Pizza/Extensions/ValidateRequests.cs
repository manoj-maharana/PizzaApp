namespace Pizza.API.Extensions
{
    public static class ValidateRequests
    {
        public static void ValidatePizzaRequest(Pizza.API.Models.Pizza request)
        {
            if (request == null) throw new ArgumentException(nameof(request));
            if (string.IsNullOrWhiteSpace(request.Name)) throw new ArgumentException(request.Name);

        }
    }
}
