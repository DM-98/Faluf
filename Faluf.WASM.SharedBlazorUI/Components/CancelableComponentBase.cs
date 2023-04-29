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
		ErrorMessage += result.ExceptionMessage?.Any() ?? false ? " | " + result.ExceptionMessage : string.Empty;
		ErrorMessage += result.StackTrace?.Any() ?? false ? " | " + result.StackTrace : string.Empty;
		ErrorMessage += result.ErrorType.HasValue ? " | " + result.ErrorType.ToString() : string.Empty;
#endif
	}
}