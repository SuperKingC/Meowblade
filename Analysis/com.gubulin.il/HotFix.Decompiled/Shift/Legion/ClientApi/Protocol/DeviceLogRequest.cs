using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class DeviceLogRequest : IPacketBody
{
	[ProtoMember(1)]
	public string DeviceIdentifier;

	[ProtoMember(2)]
	public int Event;

	[ProtoMember(3)]
	public string _pbContent;

	private Dictionary<string, string> _content;

	public Dictionary<string, string> Content
	{
		get
		{
			if (_pbContent == null)
			{
				return null;
			}
			return _content ?? (_content = JsonHelper.ToObject<Dictionary<string, string>>(_pbContent));
		}
		set
		{
			_content = value;
			_pbContent = JsonHelper.ToJson(value);
		}
	}

	public int PacketId => PacketIds.DEVICE_LOG_REQUEST;
}
