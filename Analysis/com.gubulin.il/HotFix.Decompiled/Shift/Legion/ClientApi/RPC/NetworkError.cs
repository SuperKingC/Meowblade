using System;

namespace Shift.Legion.ClientApi.RPC;

public class NetworkError
{
	public NetworkErrorTypes Type;

	public Exception Exception;

	public NetworkError(NetworkErrorTypes type, Exception exception)
	{
		Type = type;
		Exception = exception;
	}
}
