using System;
using System.Threading;
using System.Threading.Tasks;

public static class TaskTimeoutExtensions
{
	public static async Task<TResult> WaitAsync<TResult>(this Task<TResult> task, TimeSpan timeout)
	{
		using CancellationTokenSource timeoutCancellationTokenSource = new CancellationTokenSource();
		Task delayTask = Task.Delay(timeout, timeoutCancellationTokenSource.Token);
		if (await Task.WhenAny(new Task[2] { task, delayTask }) == task)
		{
			timeoutCancellationTokenSource.Cancel();
			return await task;
		}
		throw new TimeoutException("任务超时");
	}
}
