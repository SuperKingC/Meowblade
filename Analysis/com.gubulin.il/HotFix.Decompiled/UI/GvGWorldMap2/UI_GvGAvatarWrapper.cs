using System;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using GvG2;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.GvGMode2Island;
using Shift.Legion.GvGServer.Models.WorldBossSocket;
using UnityEngine;

namespace UI.GvGWorldMap2;

public class UI_GvGAvatarWrapper : GComponent
{
	public GLoader Avatar;

	public const string URL = "ui://hd2s9kukxwnq44";

	public static string Name = "UI_GvGAvatarWrapper";

	private EntityInfo GroupData;

	private bool isInit = false;

	public static string GetURL()
	{
		return "ui://hd2s9kukxwnq44";
	}

	public static UI_GvGAvatarWrapper CreateInstance()
	{
		return (UI_GvGAvatarWrapper)(object)UIPackage.CreateObject("GvGWorldMap2", "GvGAvatarWrapper");
	}

	public static UI_GvGAvatarWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGAvatarWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukxwnq44", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Avatar = (GLoader)((GComponent)this).GetChild("Avatar");
	}

	public void Init(EntityInfo group_data)
	{
		GroupData = group_data;
		InitPlayerAvatar();
	}

	private void InitPlayerAvatar()
	{
		UI_GvGPlayerAvatar avatar = (UI_GvGPlayerAvatar)(object)Avatar.component;
		int num = GroupData.UnitsInfo.Sum((UnitInfo_Protocol unit) => unit.Total);
		((GObject)avatar.PlayerInfo.SoldierNum).text = $"{num}";
		avatar.PlayerInfo.CampId.selectedIndex = GroupData.CampId;
		avatar.Avatar.CampId.selectedIndex = GroupData.CampId;
		AvatarHelper.GetUserAvatarSprite($"{GroupData.CampId}", GroupData.UserId, delegate(Sprite sprite)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			avatar.Avatar.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
		});
		ProfileHelper.GetUserProfile($"{GroupData.CampId}", GroupData.UserId, delegate(UserProfile profile)
		{
			((GObject)avatar.PlayerInfo.PlayerName).text = profile.Name;
		});
		SharedMessenger.AddListener<int>("ON_LOD_CHANGE", OnLODChange_Player);
		SharedMessenger.AddListener<S2C_BroadcastBattleDamageInfo.Request>("ON_GVG_BROADCAST_DAMAGE", OnBroadcastDamage);
	}

	public void Destroy()
	{
		SharedMessenger.RemoveListener<int>("ON_LOD_CHANGE", OnLODChange_Player);
		SharedMessenger.RemoveListener<S2C_BroadcastBattleDamageInfo.Request>("ON_GVG_BROADCAST_DAMAGE", OnBroadcastDamage);
	}

	public void OnSoldierNumChange(int num)
	{
		UI_GvGPlayerAvatar uI_GvGPlayerAvatar = (UI_GvGPlayerAvatar)(object)Avatar.component;
		((GObject)uI_GvGPlayerAvatar.PlayerInfo.SoldierNum).text = $"{num}";
	}

	private void OnBroadcastDamage(S2C_BroadcastBattleDamageInfo.Request req)
	{
		if (req.DamageInfos_Dict.TryGetValue(GroupData.EntityId, out var value))
		{
			UI_GvGPlayerAvatar uI_GvGPlayerAvatar = (UI_GvGPlayerAvatar)(object)Avatar.component;
			((GObject)uI_GvGPlayerAvatar.PlayerInfo.SoldierNum).text = $"{value.SoldierRemaining}";
		}
	}

	public void OnLODChange_Player(int lodIndex)
	{
		if (!((GObject)this).isDisposed)
		{
			UI_GvGPlayerAvatar uI_GvGPlayerAvatar = (UI_GvGPlayerAvatar)(object)Avatar.component;
			uI_GvGPlayerAvatar.IsShowInfo.selectedIndex = ((lodIndex == 0) ? 1 : 0);
		}
	}

	public void SetState(eGvGMode2State state)
	{
		UI_GvGPlayerAvatar uI_GvGPlayerAvatar = (UI_GvGPlayerAvatar)(object)Avatar.component;
		uI_GvGPlayerAvatar.State.selectedIndex = (int)state;
	}

	public void OnDying(Action onDead)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		UI_GvGPlayerAvatar uI_GvGPlayerAvatar = (UI_GvGPlayerAvatar)(object)Avatar.component;
		((GObject)uI_GvGPlayerAvatar.FightingIcon).alpha = 0f;
		((GObject)this).TweenFade(0f, 0.9f).OnComplete((GTweenCallback)delegate
		{
			onDead?.Invoke();
		});
	}

	public void SetHoldingScorePerSecond(int holdingScorePerSecond)
	{
		UI_GvGPlayerAvatar uI_GvGPlayerAvatar = (UI_GvGPlayerAvatar)(object)Avatar.component;
		((GObject)uI_GvGPlayerAvatar.Holding.Tip).text = $"+{holdingScorePerSecond}%";
	}

	public void SetToBeMeVfx()
	{
		UI_GvGPlayerAvatar uI_GvGPlayerAvatar = (UI_GvGPlayerAvatar)(object)Avatar.component;
		uI_GvGPlayerAvatar.PlayerType.selectedIndex = 1;
	}

	public void SetToBeTargetVfx()
	{
		UI_GvGPlayerAvatar uI_GvGPlayerAvatar = (UI_GvGPlayerAvatar)(object)Avatar.component;
		uI_GvGPlayerAvatar.PlayerType.selectedIndex = 2;
	}

	public void SetToBeGeneral()
	{
		UI_GvGPlayerAvatar uI_GvGPlayerAvatar = (UI_GvGPlayerAvatar)(object)Avatar.component;
		uI_GvGPlayerAvatar.PlayerType.selectedIndex = 0;
	}
}
