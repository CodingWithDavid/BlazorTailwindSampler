

namespace BlazorTailwindSampler.Shared
{
    public record APIResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
        public int NewValue { get; set; }

        public APIResponse(bool success, string message, string data, int newValue)
        {
            Success = success;
            Message = message;
            Data = JsonHelper.Serialize(data);
            NewValue = newValue;
        }
    }
}
