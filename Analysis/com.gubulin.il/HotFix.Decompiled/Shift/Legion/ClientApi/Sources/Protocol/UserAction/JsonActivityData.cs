using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using ProtoBuf;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Sources.Protocol.UserAction;

[ProtoContract]
public class JsonActivityData
{
	public Dictionary<string, List<Product>> _PageContents;

	public ActivityConfig _ActivityConfig;

	[ProtoMember(1)]
	public string ActivityId { get; set; }

	[ProtoMember(2)]
	public string JsonContent { get; set; }

	[ProtoMember(3)]
	public string JsonActivityConfig { get; set; }

	[ProtoMember(4)]
	public int BeginTime { get; set; }

	[ProtoMember(5)]
	public int EndTime { get; set; }

	public Dictionary<string, List<Product>> PageContents
	{
		get
		{
			if (_PageContents == null && !string.IsNullOrEmpty(JsonContent))
			{
				_PageContents = JsonContent.ToObject<Dictionary<string, List<Product>>>();
			}
			return _PageContents;
		}
	}

	public ActivityConfig ActivityConfig
	{
		get
		{
			if (_ActivityConfig == null && !string.IsNullOrEmpty(JsonActivityConfig))
			{
				_ActivityConfig = JsonHelper.ToObject<ActivityConfig>(JsonActivityConfig);
			}
			return _ActivityConfig;
		}
	}
}
