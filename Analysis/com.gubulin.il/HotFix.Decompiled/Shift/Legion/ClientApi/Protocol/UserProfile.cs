using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Medal;
using ILRuntime_LitJson;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class UserProfile
{
	[ProtoMember(1)]
	public string Name;

	[ProtoMember(2)]
	public string AvatarFrame;

	[ProtoMember(3)]
	public int AvatarFrameExpiredTime;

	[ProtoMember(4)]
	public string Title;

	[ProtoMember(5)]
	public int TitleExpiredTime;

	[ProtoMember(6)]
	public string Nameplate;

	[ProtoMember(7)]
	public int NameplateExpiredTime;

	[ProtoMember(8)]
	public List<int> Friends;

	[JsonIgnore]
	[ProtoIgnore]
	private List<GvGMedalRecord> _mergedMedalRecords;

	[ProtoMember(9)]
	public string Medals { get; set; } = string.Empty;

	[JsonIgnore]
	[ProtoIgnore]
	public List<GvGMedalRecord> MergedMedalRecords => GetMergedRecords();

	private List<GvGMedalRecord> GetMergedRecords()
	{
		if (_mergedMedalRecords != null)
		{
			return _mergedMedalRecords;
		}
		_mergedMedalRecords = new List<GvGMedalRecord>();
		if (string.IsNullOrWhiteSpace(Medals) || Medals == "null")
		{
			return _mergedMedalRecords;
		}
		List<GvGMedalRecord> list = JsonHelper.ToObject<List<GvGMedalRecord>>(Medals);
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (GvGMedalRecord item in list)
		{
			if (item != null)
			{
				if (dictionary.ContainsKey(item.MedalId))
				{
					dictionary[item.MedalId] += item.Level;
				}
				else
				{
					dictionary[item.MedalId] = item.Level;
				}
			}
		}
		foreach (KeyValuePair<string, int> item2 in dictionary)
		{
			_mergedMedalRecords.Add(new GvGMedalRecord
			{
				MedalId = item2.Key,
				Level = item2.Value
			});
		}
		_mergedMedalRecords.Sort(MedalSort);
		return _mergedMedalRecords;
	}

	private static int MedalSort(GvGMedalRecord a, GvGMedalRecord b)
	{
		int num = b.Config.Rarity - a.Config.Rarity;
		if (num != 0)
		{
			return num;
		}
		return a.Config.Index - b.Config.Index;
	}
}
