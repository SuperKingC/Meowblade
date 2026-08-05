using HotFix;
using ObjectPool;
using Shift.Legion.ClientApi.Protocol;

namespace Shift.Legion.ClientApi.RPC;

public class RPCContext : IPooled
{
	public Header Header { get; set; }

	public byte[] Payload { get; set; }

	public RPCContextDelegate Callback { get; set; }

	public bool ResponseReceived { get; set; }

	public IPacketBody Request { get; set; }

	public int PacketId { get; set; }

	public int Context { get; set; }

	public int opUniqueId { get; set; }

	public bool Active { get; set; }

	public void OnInstantiate()
	{
	}

	public void OnUnSpawn()
	{
		Header = null;
		Payload = null;
		Callback = null;
		ResponseReceived = false;
		Request = null;
		PacketId = 0;
		Context = 0;
	}

	public void UnSpawn()
	{
		ObjectPool<RPCContext>.UnSpawn(this);
	}
}
