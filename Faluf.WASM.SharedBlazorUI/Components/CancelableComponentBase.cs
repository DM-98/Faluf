using Faluf.WASM.Core.DTOs.Outputs;
using Microsoft.AspNetCore.Components;

namespace Faluf.WASM.SharedBlazorUI.Components;

public abstract class CancelableComponentBase : ComponentBase, IDisposable
{
	protected CancellationToken CancellationToken => cancellationSource.Token;

	protected string? ErrorMessage { get; set; }

	private readonly CancellationTokenSource cancellationSource = new();

	public void Dispose()
	{
		cancellationSource.Cancel();
		cancellationSource.Dispose();

		GC.SuppressFinalize(this);
	}

	protected void DisplayError<T>(ResponseDTO<T> result) where T : class
	{
		ErrorMessage = result.ErrorMessage + $" (#{(result.ErrorType.HasValue ? (int)result.ErrorType : 0)})";

#if DEBUG
		if (result.ExceptionMessage?.Length > 0)
		{
			ErrorMessage += " | " + result.ExceptionMessage;
		}
		
		if (result.StackTrace?.Length > 0)
		{
			ErrorMessage += " | " + result.StackTrace;
		}
		
		if (result.ErrorType.HasValue)
		{
			ErrorMessage += " | " + result.ErrorType.ToString();
		}
#endif
	}
}