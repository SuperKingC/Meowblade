using System;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using GvG3;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.GvGMode3Island;
using UnityEngine;

namespace UI.GvGOnIsland3;

public class UI_com_GvGAvatarWrapper : GComponent
{
	public GLoader Avatar;

	public const string URL = "ui://ebc4ciwrjkzvq2j";

	public static string Name = "UI_com_GvGAvatarWrapper";

	private EntityInfo GroupData;

	public static string GetURL()
	{
		return "ui://ebc4ciwrjkzvq2j";
	}

	public static UI_com_GvGAvatarWrapper CreateInstance()
	{
		return (UI_com_GvGAvatarWrapper)(object)UIPackage.CreateObject("GvGOnIsland3", "com_GvGAvatarWrapper");
	}

	public static UI_com_GvGAvatarWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GvGAvatarWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrjkzvq2j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Avatar = (GLoader)((GComponent)this).GetChild("Avatar");
	}

	public void Init(EntityInfo group_data, int islandId)
	{
		GroupData = group_data;
		if (group_data.UserId > 0)
		{
			InitPlayerAvatar();
		}
		else
		{
			InitNPCAvatar(islandId);
		}
		RegisterEvents();
	}

	private void InitPlayerAvatar()
	{
		UI_com_GvGPlayerAvatar avatar = (UI_com_GvGPlayerAvatar)(object)Avatar.component;
		int num = GroupData.UnitsInfo.Sum((UnitInfo_Protocol unit) => unit.Total);
		((GObject)avatar.PlayerInfo.SoldierNum).text = $"{num}";
		avatar.PlayerInfo.CampId.selectedIndex = GroupData.CampId;
		avatar.Avatar.CampId.selectedIndex = GroupData.CampId;
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{GroupData.CampId}", GroupData.UserId, delegate(UserProfile profile)
		{
			if (!((GObject)avatar).isDisposed && !((GObject)avatar.PlayerInfo).isDisposed && !((GObject)avatar.PlayerInfo.PlayerName).isDisposed)
			{
				((GObject)avatar.PlayerInfo.PlayerName).text = profile.Name;
			}
		}, delegate(Sprite sprite)
		{
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Expected O, but got Unknown
			if (!((GObject)avatar).isDisposed && !((GObject)avatar.Avatar).isDisposed && !((GObject)avatar.Avatar.HeadPortrait).isDisposed)
			{
				avatar.Avatar.HeadPortrait.Type.SetSelectedIndex(0);
				avatar.Avatar.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
			}
		}));
	}

	private void InitNPCAvatar(int islandId)
	{
		UI_com_GvGPlayerAvatar uI_com_GvGPlayerAvatar = (UI_com_GvGPlayerAvatar)(object)Avatar.component;
		int num = GroupData.UnitsInfo.Sum((UnitInfo_Protocol unit) => unit.Total);
		((GObject)uI_com_GvGPlayerAvatar.PlayerInfo.SoldierNum).text = $"{num}";
		uI_com_GvGPlayerAvatar.PlayerInfo.CampId.selectedIndex = GroupData.CampId;
		uI_com_GvGPlayerAvatar.Avatar.CampId.selectedIndex = GroupData.CampId;
		uI_com_GvGPlayerAvatar.Avatar.HeadPortrait.Type.SetSelectedIndex(1);
		uI_com_GvGPlayerAvatar.Avatar.HeadPortrait.icon.url = "ui://PublicResources/" + GroupData.Icon;
		((GObject)uI_com_GvGPlayerAvatar.PlayerInfo.PlayerName).text = string.Format("GvGDefendersName".ToLanguage(), new object[1] { WorldMapConfigHelper.Configs.TryGetIsland(islandId).Name });
		OnRenderBuffType();
	}

	public void Destroy()
	{
		UnregisterEvents();
	}

	public void StopShowAnimation()
	{
		UI_com_GvGPlayerAvatar uI_com_GvGPlayerAvatar = (UI_com_GvGPlayerAvatar)(object)Avatar.component;
		uI_com_GvGPlayerAvatar.ShipMoveIn.Stop(true, false);
	}

	private void RegisterEvents()
	{
		SharedMessenger.AddListener<int>("ON_LOD_CHANGE", OnLODChange_Player);
		GvG3IslandController instance = GvG3IslandController.Instance;
		instance.OnChangeEvent_火力支援 = (Action)Delegate.Combine(instance.OnChangeEvent_火力支援, new Action(OnRenderBuffType));
		GameManagers.Instance.Messenger.AddListener<bool>("GVG3_BRAWL_FIGHT_SET_PASUE", SetPause);
	}

	private void UnregisterEvents()
	{
		SharedMessenger.RemoveListener<int>("ON_LOD_CHANGE", OnLODChange_Player);
		GvG3IslandController instance = GvG3IslandController.Instance;
		instance.OnChangeEvent_火力支援 = (Action)Delegate.Remove(instance.OnChangeEvent_火力支援, new Action(OnRenderBuffType));
		GameManagers.Instance.Messenger.RemoveListener<bool>("GVG3_BRAWL_FIGHT_SET_PASUE", SetPause);
	}

	private void OnRenderBuffType()
	{
		int selectedIndex = 0;
		GvG3IslandController instance = GvG3IslandController.Instance;
		if (GroupData.GvGRole == 6 && instance.Is火力支援Active)
		{
			selectedIndex = 1;
		}
		UI_com_GvGPlayerAvatar uI_com_GvGPlayerAvatar = (UI_com_GvGPlayerAvatar)(object)Avatar.component;
		uI_com_GvGPlayerAvatar.PlayerInfo.BuffType.selectedIndex = selectedIndex;
	}

	public void OnSoldierNumChange(int num)
	{
		UI_com_GvGPlayerAvatar uI_com_GvGPlayerAvatar = (UI_com_GvGPlayerAvatar)(object)Avatar.component;
		((GObject)uI_com_GvGPlayerAvatar.PlayerInfo.SoldierNum).text = $"{num}";
	}

	public void OnLODChange_Player(int lodIndex)
	{
		if (!((GObject)this).isDisposed)
		{
			UI_com_GvGPlayerAvatar uI_com_GvGPlayerAvatar = (UI_com_GvGPlayerAvatar)(object)Avatar.component;
			if (!((GObject)uI_com_GvGPlayerAvatar).isDisposed && !((GObject)uI_com_GvGPlayerAvatar).displayObject.isDisposed)
			{
				uI_com_GvGPlayerAvatar.IsShowInfo.selectedIndex = ((lodIndex == 0) ? 1 : 0);
			}
		}
	}

	public void SetState(eGvGMode3FightingState state)
	{
		UI_com_GvGPlayerAvatar uI_com_GvGPlayerAvatar = (UI_com_GvGPlayerAvatar)(object)Avatar.component;
		uI_com_GvGPlayerAvatar.State.selectedIndex = (int)state;
	}

	private void SetPause(bool isPause)
	{
		UI_com_GvGPlayerAvatar uI_com_GvGPlayerAvatar = (UI_com_GvGPlayerAvatar)(object)Avatar.component;
		uI_com_GvGPlayerAvatar.FightingIcon.timeScale = ((!isPause) ? 1 : 0);
	}

	public void UndoFadeOut()
	{
		UI_com_GvGPlayerAvatar uI_com_GvGPlayerAvatar = (UI_com_GvGPlayerAvatar)(object)Avatar.component;
		((GObject)uI_com_GvGPlayerAvatar.FightingIcon).alpha = 1f;
		((GObject)this).alpha = 1f;
	}

	public void FadeOut(Action onFinished)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		UI_com_GvGPlayerAvatar uI_com_GvGPlayerAvatar = (UI_com_GvGPlayerAvatar)(object)Avatar.component;
		((GObject)uI_com_GvGPlayerAvatar.FightingIcon).alpha = 0f;
		((GObject)this).TweenFade(0f, 0.9f).OnComplete((GTweenCallback)delegate
		{
			onFinished?.Invoke();
		});
	}

	public void SetHoldingScorePerSecond(int holdingScorePerSecond)
	{
		UI_com_GvGPlayerAvatar uI_com_GvGPlayerAvatar = (UI_com_GvGPlayerAvatar)(object)Avatar.component;
		((GObject)uI_com_GvGPlayerAvatar.Holding.Tip).text = $"+{holdingScorePerSecond}";
	}

	public void SetToBeMeVfx()
	{
		UI_com_GvGPlayerAvatar uI_com_GvGPlayerAvatar = (UI_com_GvGPlayerAvatar)(object)Avatar.component;
		uI_com_GvGPlayerAvatar.PlayerType.selectedIndex = 1;
	}

	public void SetToBeTargetVfx()
	{
		UI_com_GvGPlayerAvatar uI_com_GvGPlayerAvatar = (UI_com_GvGPlayerAvatar)(object)Avatar.component;
		uI_com_GvGPlayerAvatar.PlayerType.selectedIndex = 2;
	}

	public void SetToBeGeneral()
	{
		UI_com_GvGPlayerAvatar uI_com_GvGPlayerAvatar = (UI_com_GvGPlayerAvatar)(object)Avatar.component;
		uI_com_GvGPlayerAvatar.PlayerType.selectedIndex = 0;
	}

	public void SetRebornProgress(float percent)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		UI_com_GvGPlayerAvatar uI_com_GvGPlayerAvatar = (UI_com_GvGPlayerAvatar)(object)Avatar.component;
		percent = Mathf.Clamp01(percent);
		percent = 1f - percent;
		((GObject)uI_com_GvGPlayerAvatar.HoldingBrawlFight.ProgressBar).scale = new Vector2(percent, 1f);
	}
}
