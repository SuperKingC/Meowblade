using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetStorehouse : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string NonStr;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.RItemInt")]
		public List<RItemInt> RItems;

		public Dictionary<string, int> Items
		{
			get
			{
				return ToDict(RItems);
			}
			set
			{
				RItems = ToRItemList(value);
			}
		}

		public Dictionary<string, int> ToDict(List<RItemInt> list)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			if (list != null)
			{
				foreach (RItemInt item in list)
				{
					dictionary.Add($"I{item.ItemId}", item.cnt);
				}
			}
			return dictionary;
		}

		public List<RItemInt> ToRItemList(Dictionary<string, int> dict)
		{
			List<RItemInt> list = new List<RItemInt>();
			if (dict != null)
			{
				foreach (KeyValuePair<string, int> item in dict)
				{
					list.Add(new RItemInt
					{
						ItemId = int.Parse(item.Key.Remove(0, 1)),
						cnt = item.Value
					});
				}
			}
			return list;
		}
	}

	public C2S_GetStorehouse()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetStorehouse;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
