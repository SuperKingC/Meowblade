using System;
using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Archive;

[ProtoContract]
public class DownloadArchiveResponse : IPacketBody
{
	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Protocol.Archive.UserData")]
	public List<UserData> Data;

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.Archive.UserData")]
	public List<UserData> CommonSettings;

	[ProtoMember(3)]
	public string EnvStr { get; set; }

	public int PacketId => PacketIds.USER_ACTION_DOWNLOAD_ARCHIVE_REQUEST;

	public void UsedOnlyForAOTCodeGeneration()
	{
		new List<UserData>();
		throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
	}
}
