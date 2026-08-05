using System.IO;

namespace Shift.Legion.ClientApi;

public static class MemoryStreamManager
{
	public static MemoryStream GetStream()
	{
		return new MemoryStream();
	}
}
