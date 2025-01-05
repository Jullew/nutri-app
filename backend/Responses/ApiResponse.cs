using System.Collections.Generic;

namespace NutriApp.Responses
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public required string Message { get; set; }
        public required object Data { get; set; }
        public Dictionary<string, string> Errors { get; set; } = new();

        public static ApiResponse SuccessResponse(string message, object? data = null)
        {
            return new ApiResponse { Success = true, Message = message, Data = data ?? new { } };
        }

        public static ApiResponse ErrorResponse(string message, Dictionary<string, string>? fieldErrors = null, string? generalError = null)
        {
            var errors = fieldErrors ?? new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(generalError))
                errors["non_field_errors"] = generalError;

            return new ApiResponse { Success = false, Message = message, Errors = errors, Data = null };
        }
    }
}
