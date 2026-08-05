namespace Shift.Legion.ClientApi.RPC;

public class MethodDescriptor
{
	private RPCContextDelegate _listener;

	public string Name { get; }

	public uint Id { get; set; }

	public MethodDescriptor(string n, uint i)
	{
		Name = n;
		Id = i;
	}

	public void RegisterListener(RPCContextDelegate d)
	{
		_listener = d;
	}

	public void NotifyListener(RPCContext context)
	{
		_listener?.Invoke(context);
	}

	public bool HasListener()
	{
		return _listener != null;
	}
}
