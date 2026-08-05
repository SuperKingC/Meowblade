using System;
using System.IO;
using Shift.Legion.ClientApi.Protocol;

namespace Shift.Legion.ClientApi.RPC;

public class GamePacket : PacketFormat
{
	public const int Factor = 1000;

	private Header _header;

	private object _body;

	private int _headerSize = -1;

	private int _bodySize = -1;

	public Header Header
	{
		get
		{
			return _header;
		}
		set
		{
			_header = value;
		}
	}

	public object Body
	{
		get
		{
			return _body;
		}
		set
		{
			_body = value;
		}
	}

	public GamePacket()
		: this(null, null)
	{
	}

	public GamePacket(Header h, object b)
	{
		_header = h;
		_body = b;
	}

	public override int Decode(byte[] bytes, int offset, int available)
	{
		int num = 0;
		if (_headerSize < 0)
		{
			if (available < 2)
			{
				return num;
			}
			_headerSize = (bytes[offset] << 8) + bytes[offset + 1];
			available -= 2;
			num += 2;
			offset += 2;
		}
		if (_header == null)
		{
			if (available < _headerSize)
			{
				return num;
			}
			byte[] array = new byte[_headerSize];
			Array.Copy(bytes, offset, array, 0, _headerSize);
			_header = array.Deserialize<Header>();
			_bodySize = _header.Size;
			if (_header == null)
			{
				throw new Exception("failed to parse packet header");
			}
			available -= _headerSize;
			num += _headerSize;
			offset += _headerSize;
		}
		if (_body == null)
		{
			if (available < _bodySize)
			{
				return num;
			}
			byte[] array2 = new byte[_bodySize];
			Array.Copy(bytes, offset, array2, 0, _bodySize);
			_body = array2;
			num += _bodySize;
		}
		return num;
	}

	public override byte[] Encode()
	{
		if (!(_body is IPacketBody))
		{
			return null;
		}
		byte[] array = _body.Serialize();
		_header.Size = array.Length;
		using MemoryStream memoryStream = MemoryStreamManager.GetStream();
		memoryStream.Position = 2L;
		byte[] array2 = _header.Serialize();
		int num = array2.Length;
		memoryStream.Write(array2, 0, num);
		memoryStream.Write(array, 0, array.Length);
		memoryStream.Position = 0L;
		memoryStream.WriteByte((byte)((num >> 8) & 0xFF));
		memoryStream.WriteByte((byte)(num & 0xFF));
		array = null;
		return memoryStream.GetBytes();
	}

	public override bool IsLoaded()
	{
		return _header != null && _body != null;
	}
}
