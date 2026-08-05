using System;
using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

public static class 火力支援Helper
{
	private static 火力支援Config _Config;

	public static 火力支援Config Config => _Config ?? (_Config = "GvGMode3_FireSupport".ToConfiguration<火力支援Config>());

	public static int CurTimeOfUsage => Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.火力支援TimeOfUsage;

	public static RealTime火力支援MaxTimeOfUsageModel MaxTimeOfUsageModel => Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.RealTime火力支援MaxTimeOfUsageModel;

	public static bool CanShowSkillBtnForIsland(int islandId)
	{
		IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(islandId);
		return (WorldMapConfigHelper.Configs.TryGetIsland(islandId).Props.GDEData.CanUseFireSupport && islandStateModel.CampId == Singleton<WorldStateManager>.Instance.Data.MyCampId && islandStateModel.GetNpcStatus() == eGvGMode3IslandNPCStatus.Rebellion && Singleton<WorldStateManager>.Instance.Data.MyShips.Any((ShipStateModel ship) => ship.StayIslandId == islandId && ship.State != eShipState.Lock && ship.State != eShipState.NotLaunched && ship.State != eShipState.DuringFlight && ship.State != eShipState.Rebuilding)) || IsSkillActiveForIsland(islandId);
	}

	public static bool IsSkillBtnGrayedForIsland(int islandId)
	{
		List<IslandBuff> list = Singleton<WorldStateManager>.Instance.TryGetIsland(islandId)?.DetailInfo?.Buff;
		if (list == null || list.Count == 0)
		{
			return false;
		}
		int campId = Singleton<WorldStateManager>.Instance.Data.MyCampId;
		HashSet<string> specialBuff = Config.SpecialSuppress;
		return list.Any((IslandBuff buff) => specialBuff.Contains(buff.Ability.AbilityId) && buff.AffectedCampId.Contains(campId));
	}

	public static bool IsSkillActiveForIsland(int islandId)
	{
		return Singleton<WorldStateManager>.Instance.TryGetIsland(islandId).Is火力支援Active;
	}

	public static void ShowTip_InsufficientTimeOfUsage()
	{
		"GvGFireSupportTip_InsufficientTimeOfUsage".ToShowLanguageTip();
	}

	public static void ShowTip_IslandHasSpecialSuppress()
	{
		"GvGFireSupportTip_IslandHasSpecialSuppress".ToShowLanguageTip();
	}

	public static void ShowTip_Success()
	{
		"GvGFireSupportTip_Success".ToShowLanguageTip();
	}

	public static void ShowTip_HasAlreadyActivated(int userId)
	{
		string arg = GvG3ProfileHelper.TryGetUserProfile(userId)?.Name ?? $"{userId}";
		HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("GvGFireSupportTip_HasAlreadyActivated".ToLanguage(), arg).ToTip();
	}

	public static bool CheckCanUseSkill(int islandId)
	{
		if (IsSkillBtnGrayedForIsland(islandId))
		{
			ShowTip_IslandHasSpecialSuppress();
			return false;
		}
		if (IsSkillActiveForIsland(islandId))
		{
			IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(islandId);
			int activateByUser = islandStateModel.Event_火力支援.ActivateByUser;
			ShowTip_HasAlreadyActivated(activateByUser);
			return false;
		}
		if (CurTimeOfUsage == 0)
		{
			ShowTip_InsufficientTimeOfUsage();
			return false;
		}
		return true;
	}

	public static void UseSkillForIsland(int islandId, Action<int> onFinished = null)
	{
		if (!CheckCanUseSkill(islandId))
		{
			return;
		}
		Singleton<WorldStateManager>.Instance.Acrivate火力支援ToIsland(islandId, delegate(int errorCode)
		{
			if (errorCode == 0)
			{
				ShowTip_Success();
			}
			onFinished?.Invoke(errorCode);
		});
	}
}
