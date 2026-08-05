using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Models;
using Shift.Legion.GvG.Common;
using Shift.Legion.GvGServer.Models.WorldBossSocket;
using Spine.Unity;
using UnityEngine;

namespace UI.LordOfDreams;

public class UI_GvGAvatarWrapper : GComponent
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<UnitInfo_Protocol, int> _003C_003E9__11_0;

		public static Predicate<UnitInfo_Protocol> _003C_003E9__12_0;

		public static EventCallback0 _003C_003E9__12_2;

		public static Action<GameObject> _003C_003E9__19_0;

		internal int _003CInitPlayerAvatar_003Eb__11_0(UnitInfo_Protocol unit)
		{
			return unit.Total;
		}

		internal bool _003CInitBossAvatar_003Eb__12_0(UnitInfo_Protocol unit)
		{
			return unit.IsBossUnit;
		}

		internal void _003CInitBossAvatar_003Eb__12_2()
		{
			ILRuntimeDebug.LogError("123");
		}

		internal void _003COnStartFighting_003Eb__19_0(GameObject sfx)
		{
			sfx.AddComponent<HotFix_DestroySelf>().destroyTime = 1.2f;
		}
	}

	public Controller TypeController;

	public GLoader Avatar;

	public const string URL = "ui://0i520nzmy38io5c";

	public static string Name = "UI_GvGAvatarWrapper";

	private BroadcastGroupInitInfo GroupData;

	private bool IsBoss;

	private bool isInit = false;

	public static string GetURL()
	{
		return "ui://0i520nzmy38io5c";
	}

	public static UI_GvGAvatarWrapper CreateInstance()
	{
		return (UI_GvGAvatarWrapper)(object)UIPackage.CreateObject("LordOfDreams", "GvGAvatarWrapper");
	}

	public static UI_GvGAvatarWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGAvatarWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmy38io5c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		TypeController = ((GComponent)this).GetController("TypeController");
		Avatar = (GLoader)((GComponent)this).GetChild("Avatar");
	}

	public void Init(BroadcastGroupInitInfo group_data)
	{
		GroupData = group_data;
		IsBoss = GroupData.IsBoss;
		TypeController.selectedIndex = (IsBoss ? 1 : 0);
		if (IsBoss)
		{
			InitBossAvatar();
		}
		else
		{
			InitPlayerAvatar();
		}
	}

	private void InitPlayerAvatar()
	{
		UI_GvGPlayerAvatar uI_GvGPlayerAvatar = (UI_GvGPlayerAvatar)(object)Avatar.component;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, GroupData.UserId, uI_GvGPlayerAvatar.Avatar.HeadPortrait.icon, uI_GvGPlayerAvatar.PlayerInfo.PlayerName));
		int num = GroupData.UnitsInfo.Sum((UnitInfo_Protocol unit) => unit.Total);
		((GObject)uI_GvGPlayerAvatar.PlayerInfo.SoldierNum).text = $"{num}";
		((GObject)uI_GvGPlayerAvatar.FightingIcon).alpha = 0f;
		SharedMessenger.AddListener<int>("ON_LOD_CHANGE", OnLODChange_Player);
		SharedMessenger.AddListener<S2C_BroadcastBattleDamageInfo.Request>("ON_GVG_BROADCAST_DAMAGE", OnBroadcastDamage);
	}

	private void InitBossAvatar()
	{
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		UI_GvGBossAvatar avatar = (UI_GvGBossAvatar)(object)Avatar.component;
		SharedMessenger.AddListener<int>("ON_LOD_CHANGE", OnLODChange_Boss);
		UnitInfo_Protocol unitInfo_Protocol = GroupData.UnitsInfo.Find((UnitInfo_Protocol unit) => unit.IsBossUnit);
		string wBId = GvGWorldController.Instance.ProcessInfo.BossInfo.WBId;
		GvGWorldBossInfo wbInfo = GvGConfigHelper.GetGvGWorldBossInfoByWBId(wBId);
		GvGAvatarConfig config = wbInfo.avatar;
		UiHelper.LoadSoilderSpine_Addressable(avatar.SpineLoader, $"{wbInfo.SoldierId}_skin{wbInfo.level}", config.scale, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, $"skin{wbInfo.level}");
			animation.AnimationState.SetAnimation(0, "idle", true);
			((GObject)avatar.SpineLoader).x = config.x;
			((GObject)avatar.SpineLoader).y = config.y;
		});
		EventListener onClick = ((GObject)avatar).onClick;
		object obj = _003C_003Ec._003C_003E9__12_2;
		if (obj == null)
		{
			EventCallback0 val = delegate
			{
				ILRuntimeDebug.LogError("123");
			};
			_003C_003Ec._003C_003E9__12_2 = val;
			obj = (object)val;
		}
		onClick.Set((EventCallback0)obj);
	}

	public void Destroy()
	{
		if (IsBoss)
		{
			SharedMessenger.RemoveListener<int>("ON_LOD_CHANGE", OnLODChange_Boss);
			return;
		}
		SharedMessenger.RemoveListener<int>("ON_LOD_CHANGE", OnLODChange_Player);
		SharedMessenger.RemoveListener<S2C_BroadcastBattleDamageInfo.Request>("ON_GVG_BROADCAST_DAMAGE", OnBroadcastDamage);
	}

	public void OnSoldierNumChange(int num)
	{
		if (!IsBoss && !isInit)
		{
			isInit = true;
			UI_GvGPlayerAvatar uI_GvGPlayerAvatar = (UI_GvGPlayerAvatar)(object)Avatar.component;
			((GObject)uI_GvGPlayerAvatar.PlayerInfo.SoldierNum).text = $"{num}";
		}
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
		UI_GvGPlayerAvatar uI_GvGPlayerAvatar = (UI_GvGPlayerAvatar)(object)Avatar.component;
		uI_GvGPlayerAvatar.IsShowInfo.selectedIndex = ((lodIndex == 0) ? 1 : 0);
	}

	private void OnLODChange_Boss(int lodIndex)
	{
		UI_GvGPlayerAvatar uI_GvGPlayerAvatar = (UI_GvGPlayerAvatar)(object)Avatar.component;
		((GObject)uI_GvGPlayerAvatar).visible = lodIndex == 1;
	}

	public void OnStartFighting(bool playSfx)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		if (IsBoss)
		{
			return;
		}
		UI_GvGPlayerAvatar uI_GvGPlayerAvatar = (UI_GvGPlayerAvatar)(object)Avatar.component;
		((GObject)uI_GvGPlayerAvatar.FightingIcon).alpha = 1f;
		if (playSfx)
		{
			FGUIManager.Instance.AddTextSpecialEffects(uI_GvGPlayerAvatar.SfxLoader, "gvg_fx_attack", Vector3.one * 100f, "Default", 0.5f, delegate(GameObject sfx)
			{
				sfx.AddComponent<HotFix_DestroySelf>().destroyTime = 1.2f;
			});
		}
	}

	public void OnDying(Action onDead)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		if (IsBoss)
		{
			onDead?.Invoke();
			return;
		}
		UI_GvGPlayerAvatar uI_GvGPlayerAvatar = (UI_GvGPlayerAvatar)(object)Avatar.component;
		((GObject)uI_GvGPlayerAvatar.FightingIcon).alpha = 0f;
		((GObject)this).TweenFade(0f, 0.9f).OnComplete((GTweenCallback)delegate
		{
			onDead?.Invoke();
		});
	}
}
