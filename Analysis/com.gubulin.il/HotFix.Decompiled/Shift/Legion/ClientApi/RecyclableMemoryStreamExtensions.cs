using System.IO;

namespace Shift.Legion.ClientApi;

public static class RecyclableMemoryStreamExtensions
{
	public static void CopyToMemoryStream(this byte[] bytes, MemoryStream stream, int offset, int length)
	{
		stream.Write(bytes, offset, length);
		stream.Seek(0L, SeekOrigin.Begin);
	}

	public static byte[] GetBytes(this MemoryStream stream)
	{
		stream.Seek(0L, SeekOrigin.Begin);
		byte[] array = new byte[stream.Length];
		int num = 0;
		int num2;
		while ((num2 = stream.ReadByte()) >= 0)
		{
			array[num] = (byte)num2;
			num++;
		}
		return array;
	}
}
