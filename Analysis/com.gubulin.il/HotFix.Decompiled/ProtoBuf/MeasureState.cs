using System;
using System.Runtime.InteropServices;

namespace ProtoBuf;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct MeasureState<T> : IDisposable
{
	public long Length
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public void Dispose()
	{
		throw new NotImplementedException();
	}
}
