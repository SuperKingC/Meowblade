namespace Shift.Legion.ClientApi.RPC;

public class MsgIndexer
{
	public static MsgIndexer Instance = new MsgIndexer();

	private int _index;

	private MsgIndexer()
	{
		_index = -1;
	}

	public void Reset()
	{
		_index = -1;
	}

	public int GetNext()
	{
		return _index++;
	}
}
