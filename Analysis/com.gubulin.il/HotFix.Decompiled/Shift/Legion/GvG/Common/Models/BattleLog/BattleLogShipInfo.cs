using System;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Shift.Legion.Shift.Legion.Client.Sources.Extensions;
using ILRuntime_LitJson;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace Shift.Legion.GvG.Common.Models.BattleLog;

public class BattleLogShipInfo
{
	public int UserId;

	public string GroupId;

	public int ShipRace;

	public int CampId;

	public int DeadCnt;

	public bool IsInsuranceClone;

	[JsonIgnore]
	private string _myShipName;

	[JsonIgnore]
	private string _npcName;

	[JsonIgnore]
	private string _npcIcon;

	[JsonIgnore]
	private string _shipId;

	[JsonIgnore]
	public int UiShipRace => (ShipRace != 99) ? ShipRace : 0;

	[JsonIgnore]
	public bool IsNpc => UserId == -1;

	[JsonIgnore]
	public string MyShipName => _myShipName ?? (_myShipName = ((UserId != GameController.Contexts.gameState.user.value.UserId) ? string.Empty : (IsInsuranceClone ? GvG3InsuranceHelper.GetInsuranceShipName() : Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipName(GroupId))));

	[JsonIgnore]
	public string ShipId => _shipId ?? (_shipId = ((UserId != -1) ? GroupId : GroupId.Split(new string[1] { "###" }, StringSplitOptions.None)[0]));

	public string NpcName(string islandName = "")
	{
		if (_npcName != null)
		{
			return _npcName;
		}
		if (UserId != -1)
		{
			_npcName = string.Empty;
		}
		else
		{
			string[] array = GroupId.Split(new string[1] { "###" }, StringSplitOptions.None);
			_npcName = ((!string.IsNullOrEmpty(array[2])) ? GameManagers.Instance.SoldierManager.Get(array[2]).Name : string.Format("GvGDefendersName".ToLanguage(), new object[1] { islandName }));
		}
		return _npcName;
	}

	public string NpcIcon()
	{
		if (_npcIcon != null)
		{
			return _npcIcon;
		}
		if (UserId != -1)
		{
			_npcIcon = string.Empty;
			return _npcIcon;
		}
		string[] array = GroupId.Split(new string[1] { "###" }, StringSplitOptions.None);
		string text = array[2];
		if (string.IsNullOrEmpty(text))
		{
			_npcIcon = array[1].ToPublicResourceIcon();
			return _npcIcon;
		}
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(text);
		_npcIcon = soldier.GetGvG3SoldierIconUrl();
		return _npcIcon;
	}
}
