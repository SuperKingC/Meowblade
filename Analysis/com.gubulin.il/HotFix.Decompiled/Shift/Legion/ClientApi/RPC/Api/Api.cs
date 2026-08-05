namespace Shift.Legion.ClientApi.RPC.Api;

public class Api
{
	protected RPCConnection RPCConnection;

	public virtual void InitRPCListeners(RPCConnection rpcConnection)
	{
		RPCConnection = rpcConnection;
	}
}
