using System;
using HotFix.Sources.Shift.Legion.Shift.Legion.Client.Sources.Extensions;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

[ProtoContract]
public class UnitInfo_Protocol
{
	[ProtoMember(1)]
	public string SoldierId;

	[ProtoMember(4)]
	public bool IsBossUnit;

	[ProtoMember(5)]
	public float BossSize;

	[ProtoMember(6)]
	public int PotentialLevel;

	[ProtoMember(7)]
	public int PerTeamMemberCnt;

	[ProtoMember(8)]
	public int Total;

	[ProtoMember(9)]
	public int InitTotal;

	[ProtoMember(10)]
	public int CombatPower;

	[ProtoMember(11)]
	public int PosId;

	[ProtoIgnore]
	private string _icon;

	[ProtoIgnore]
	public int TeamsCombatPower => Mathf.RoundToInt((float)(CombatPower * PerTeamMemberCnt));

	[ProtoIgnore]
	public bool SoldierNumNotEnough => Total < PerTeamMemberCnt;

	[ProtoIgnore]
	public string Icon
	{
		get
		{
			try
			{
				if (!string.IsNullOrEmpty(_icon))
				{
					return _icon;
				}
				_icon = GameManagers.Instance.SoldierManager.Get(SoldierId)?.GetGvG3SoldierIconUrl();
				return _icon;
			}
			catch (Exception arg)
			{
				ILRuntimeDebug.LogError($"[SoldierDetail]: {SoldierId} get IsBoss {arg}");
				throw;
			}
		}
	}
}
