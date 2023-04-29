using Faluf.WASM.Core.Enums;

namespace Faluf.WASM.Core.DTOs.Outputs;

public sealed record ResponseDTO<T> where T : class
{
	public bool IsSuccess { get; set; }

	public string? ErrorMessage { get; set; }

	public string? ExceptionMessage { get; set; }

	public string? StackTrace { get; set; }

	public ErrorType? ErrorType { get; set; }

	public T? Content { get; set; }

	public int RecordCount { get; }

	public ResponseDTO(bool isSuccess, string? errorMessage, string? exceptionMessage, string? stackTrace, ErrorType? errorType, T? content, int recordCount = 0)
	{
		IsSuccess = isSuccess;
		ErrorMessage = errorMessage;
		ExceptionMessage = exceptionMessage;
		StackTrace = stackTrace;
		ErrorType = errorType;
		Content = content;
		RecordCount = recordCount;
	}
}