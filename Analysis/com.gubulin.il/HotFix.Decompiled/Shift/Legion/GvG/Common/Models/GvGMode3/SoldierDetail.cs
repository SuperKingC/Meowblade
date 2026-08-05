using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class SoldierDetail
{
	[ProtoMember(1)]
	public string SoldierId;

	[ProtoMember(2)]
	public int PortalId;

	[ProtoMember(3)]
	public int Num;

	[ProtoMember(4)]
	public int Level;

	[ProtoMember(5)]
	public int PotentialLevel;

	[ProtoMember(6)]
	public int EvoLevel;

	[ProtoMember(7)]
	public string CombatPower;

	[ProtoMember(20)]
	public int Atk;

	[ProtoMember(21)]
	public int Def;

	[ProtoMember(22)]
	public int Hp;

	[ProtoMember(23)]
	public string str_Hp;

	[ProtoMember(24)]
	public string str_CombatPower;

	[ProtoMember(90, TypeName = "Shift.Legion.ClientApi.Models.LegendItemBrief")]
	public List<LegendItemBrief> LegendItems;

	[ProtoMember(91, TypeName = "Shift.Legion.ClientApi.Models.ItemLevel")]
	public List<ItemLevel> Weapons;

	private string _icon;

	private int? _isBoss;

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
				Soldier soldier = GameManagers.Instance.SoldierManager.Get(SoldierId);
				int num = (PotentialLevel + 2) / 2;
				if (PotentialLevel >= 9)
				{
					num = 6;
				}
				string itemId = soldier.ItemId;
				if (string.IsNullOrEmpty(itemId))
				{
					itemId = GameManagers.Instance.SoldierManager.Get(soldier.Data.ParentSoldierId).ItemId;
				}
				_icon = $"ui://PublicResources/{itemId}_{num}";
				return _icon;
			}
			catch (Exception arg)
			{
				ILRuntimeDebug.LogError($"[SoldierDetail]: {SoldierId} get IsBoss {arg}");
				throw;
			}
		}
	}

	public bool IsBoss
	{
		get
		{
			try
			{
				int? isBoss = _isBoss;
				if (isBoss.HasValue)
				{
					return _isBoss.Value != 0;
				}
				Soldier soldier = GameManagers.Instance.SoldierManager.Get(SoldierId);
				_isBoss = ((soldier.Tags.Contains("IS_BOSS") || soldier.Tags.Contains("BOSS")) ? 1 : 0);
				return _isBoss.Value != 0;
			}
			catch (Exception arg)
			{
				ILRuntimeDebug.LogError($"[SoldierDetail]: {SoldierId} get IsBoss {arg}");
				throw;
			}
		}
	}
}
