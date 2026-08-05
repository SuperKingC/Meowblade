using System.Collections.Generic;
using ILRuntime_LitJson;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.C2S;

public class C2S_GetEarlyWarningInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public List<string> ShipIds;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public string JsonDangerLevelOfIsland;

		private List<List<int>> _dangerLevelOfIsland;

		[JsonIgnore]
		private Dictionary<int, int> _islandLevelLut;

		[JsonIgnore]
		public List<List<int>> DangerLevelOfIsland
		{
			get
			{
				if (_dangerLevelOfIsland == null && !string.IsNullOrEmpty(JsonDangerLevelOfIsland))
				{
					return JsonHelper.ToObject<List<List<int>>>(JsonDangerLevelOfIsland);
				}
				return _dangerLevelOfIsland;
			}
			set
			{
				_dangerLevelOfIsland = value;
				JsonDangerLevelOfIsland = JsonHelper.ToJson(_dangerLevelOfIsland);
			}
		}

		public static Response EmptyData => new Response
		{
			_islandLevelLut = new Dictionary<int, int>(),
			_dangerLevelOfIsland = new List<List<int>>()
		};

		public void Unpack()
		{
			_islandLevelLut = new Dictionary<int, int>();
			int num = 1;
			foreach (List<int> item in DangerLevelOfIsland)
			{
				foreach (int item2 in item)
				{
					_islandLevelLut[item2] = num;
				}
				num++;
			}
		}

		public int GetDangerLevel(int islandId)
		{
			if (_islandLevelLut.ContainsKey(islandId))
			{
				return _islandLevelLut[islandId];
			}
			return -1;
		}
	}

	public C2S_GetEarlyWarningInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetEarlyWarningInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
