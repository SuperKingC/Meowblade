using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using ProtoBuf;
using UnityEngine;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class IEvent_PlayerCommand
{
	[ProtoMember(1)]
	public int UserId;

	[ProtoMember(2)]
	public int CampId;

	[ProtoMember(3)]
	public int ExpireTimestamp;

	[ProtoMember(4)]
	public string Msg;

	[ProtoMember(6)]
	public float ContributionPointAdd;

	[ProtoIgnore]
	private string _contributionPointAddPercentage;

	[ProtoIgnore]
	private int _ContribLevel = -1;

	[ProtoIgnore]
	public int MUID { get; set; }

	[ProtoIgnore]
	public eIslandEvent EventType { get; set; }

	[ProtoIgnore]
	public string ContributionPointAddPercentage
	{
		get
		{
			if (string.IsNullOrEmpty(_contributionPointAddPercentage))
			{
				_contributionPointAddPercentage = Mathf.RoundToInt(ContributionPointAdd * 100f).ToString();
			}
			return _contributionPointAddPercentage;
		}
	}

	[ProtoIgnore]
	public int ContribLevel
	{
		get
		{
			if (_ContribLevel == -1)
			{
				List<float> playerCommandContribLevel = WorldMapConfigHelper.Configs.PlayerCommandContribLevel;
				for (int i = 0; i < playerCommandContribLevel.Count; i++)
				{
					if (Mathf.Abs(playerCommandContribLevel[i] - ContributionPointAdd) < float.Epsilon)
					{
						_ContribLevel = i;
						break;
					}
				}
			}
			return _ContribLevel;
		}
	}

	public int RemainingTime(int timestamp)
	{
		return Math.Max(0, ExpireTimestamp - timestamp);
	}

	public bool StillValid(int timestamp)
	{
		return ExpireTimestamp < 0 || ExpireTimestamp > timestamp;
	}
}
