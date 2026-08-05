using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UI.GvGShipPopup;
using UnityEngine;

namespace UI.GvGExpeditionHall;

public class UI_com_ShipEntry : GComponent
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct SpineConstants
	{
		public const string BUILDING_NAME = "yuanzhengdatingtx";

		public const string ANI_DAI_JI = "daiji";

		public const string ANI_DENG_DAI = "dengdai";

		public const string ANI_JIAN_ZAO_ZHONG = "jianzaozhong";

		public const string SKIN = "skin1";
	}

	public Controller State;

	public GImage n133;

	public GImage n137;

	public GImage n136;

	public GImage n139;

	public GImage n135;

	public GGraph SpineLoader;

	public GGraph BuildingSpine;

	public GImage n138;

	public GImage n121;

	public GTextField n117;

	public UI_com_BuildTimeInfo BuildTimeInfo;

	public GImage n134;

	public Transition t2;

	public Transition t3;

	public Transition t4;

	public Transition t5;

	public const string URL = "ui://k19peou7u2yw1a";

	public static string Name = "UI_com_ShipEntry";

	private List<GameObject> AnimObj_List;

	private SkeletonAnimation _buildAnimation;

	private ShipAnimCacheManager ShipAnimCacheManager;

	private int TargetBuildCompleteTime;

	private GvGMode3ShipModel CurShip;

	public static string GetURL()
	{
		return "ui://k19peou7u2yw1a";
	}

	public static UI_com_ShipEntry CreateInstance()
	{
		return (UI_com_ShipEntry)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_ShipEntry");
	}

	public static UI_com_ShipEntry CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipEntry).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7u2yw1a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n133 = (GImage)((GComponent)this).GetChild("n133");
		n137 = (GImage)((GComponent)this).GetChild("n137");
		n136 = (GImage)((GComponent)this).GetChild("n136");
		n139 = (GImage)((GComponent)this).GetChild("n139");
		n135 = (GImage)((GComponent)this).GetChild("n135");
		SpineLoader = (GGraph)((GComponent)this).GetChild("SpineLoader");
		BuildingSpine = (GGraph)((GComponent)this).GetChild("BuildingSpine");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		n121 = (GImage)((GComponent)this).GetChild("n121");
		n117 = (GTextField)((GComponent)this).GetChild("n117");
		string id = "ui://k19peou7u2yw1a".Replace("ui://", "") + "-" + ((GObject)n117).id;
		((GObject)n117).text = LanguagesManager.GetDesc(id);
		BuildTimeInfo = (UI_com_BuildTimeInfo)(object)((GComponent)this).GetChild("BuildTimeInfo");
		n134 = (GImage)((GComponent)this).GetChild("n134");
		t2 = ((GComponent)this).GetTransition("t2");
		t3 = ((GComponent)this).GetTransition("t3");
		t4 = ((GComponent)this).GetTransition("t4");
		t5 = ((GComponent)this).GetTransition("t5");
	}

	public void Init()
	{
		AnimObj_List = new List<GameObject>();
		ShipAnimCacheManager = new ShipAnimCacheManager();
		((GObject)this).touchable = false;
		Singleton<GvGMode3RoomManager>.Instance.TryConnectAndGetObserverRecord(null, delegate
		{
			Render();
			((GObject)this).touchable = true;
		}, delegate
		{
			Render();
			((GObject)this).touchable = true;
		}, delegate
		{
			ILRuntimeDebug.LogError("[UI_com_ShipEntry] ObserverRecord 无法从gs服和gvg服上获取");
		});
	}

	public void OnDestroy()
	{
		if (ShipAnimCacheManager != null)
		{
			ShipAnimCacheManager.ClearCache();
		}
		_buildAnimation = null;
		if (AnimObj_List != null)
		{
			foreach (GameObject animObj_ in AnimObj_List)
			{
				if ((Object)(object)animObj_ != (Object)null)
				{
					Object.Destroy((Object)(object)animObj_);
				}
			}
			AnimObj_List.Clear();
		}
		Singleton<GvGMode3RoomManager>.Instance.TryDelayDisconnectRoom();
	}

	public void RegisterUiEventListeners()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((GObject)this).onClick.Set(new EventCallback0(OnClickShipEntryBtn));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		((GObject)this).onClick.Clear();
		if (Timers.inst.Exists(new TimerCallback(UpdateCountDown)))
		{
			Timers.inst.Remove(new TimerCallback(UpdateCountDown));
		}
	}

	private void OnClickShipEntryBtn()
	{
		if (CurShip == null)
		{
			OnOpenBuildShipPanel();
			return;
		}
		eShipBuildState selectedIndex = (eShipBuildState)State.selectedIndex;
		if (selectedIndex == eShipBuildState.Normal)
		{
			OnOpenFirstShipIntroPanel();
		}
		else if (Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.HasEnterIZ)
		{
			"GvGFirstShipHasEnterIZTips".ToShowLanguageTip();
		}
		else if (selectedIndex == eShipBuildState.Building || selectedIndex == eShipBuildState.Rebuilding)
		{
			"GvGFirstShipBuildingTips".ToShowLanguageTip();
		}
	}

	private void OnOpenBuildShipPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_BuildShipPanel.Name, new Dictionary<string, object>
		{
			{
				"BuildableShipType",
				Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetBuildableShipType()
			},
			{
				"OnBuildStarted",
				new UICallbackParam<Action<UI_main_BuildConfirmPanel.BuildParam>>(delegate
				{
					Render();
				})
			}
		});
	}

	private void OnBuildFinished()
	{
		Render();
	}

	private void OnOpenAcceptShipPanel()
	{
		if (!GameController.Contexts.Service<IUiService>().HasShowingUi(UI_main_AcceptShipPanel.Name))
		{
			GvGShipDetailModel gvGShipDetailModel = new GvGShipDetailModel();
			gvGShipDetailModel.SetRecordData(CurShip);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_AcceptShipPanel.Name, new Dictionary<string, object>
			{
				{
					"Ships",
					new List<GvGShipDetailModel> { gvGShipDetailModel }
				},
				{
					"OnAccept",
					new UICallbackParam<Action<string>>(OnAcceptShipFinished)
				}
			});
		}
	}

	private void OnAcceptShipFinished(string shipId)
	{
		Render();
	}

	private void OnOpenFirstShipIntroPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_FirstShipIntroPanel.Name, new Dictionary<string, object>
		{
			{ "ShipId", CurShip.ShipId },
			{
				"OnDestroyShip",
				new UICallbackParam<Action<string>>(OnDestroyShip)
			}
		});
	}

	private void OnDestroyShip(string shipId)
	{
		ShipAnimCacheManager.ClearCache();
		Render();
	}

	public void Render()
	{
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected O, but got Unknown
		if (Singleton<GvGMode3RoomManager>.Instance.ObserverRecord == null || ShipAnimCacheManager == null)
		{
			return;
		}
		List<GvGMode3ShipModel> ships = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.Ships;
		if (ships == null || ships.Count == 0)
		{
			CurShip = null;
			State.selectedIndex = 4;
			UpdateBuildingSpine(BuildingSpine, "yuanzhengdatingtx", "skin1", "daiji", 1f, 1f);
			ClearShipSpine();
			return;
		}
		CurShip = ships[0];
		TargetBuildCompleteTime = CurShip.PermanentData.TargetBuildCompleteTime;
		bool flag = CurShip.PermanentData.ShipBuildState == 2 || CurShip.PermanentData.ShipBuildState == 3;
		bool flag2 = flag && TargetBuildCompleteTime > (int)GameController.Instance.GetServerTime();
		if ((flag && !flag2) || CurShip.PermanentData.ShipBuildState == 1)
		{
			State.selectedIndex = 1;
			if (!Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.HasEnterIZ)
			{
				OnOpenAcceptShipPanel();
			}
		}
		else
		{
			State.selectedIndex = CurShip.PermanentData.ShipBuildState;
		}
		if (flag2)
		{
			UpdateCountDown();
			if (!Timers.inst.Exists(new TimerCallback(UpdateCountDown)))
			{
				Timers.inst.Add(1f, 0, new TimerCallback(UpdateCountDown));
			}
		}
		else if (Timers.inst.Exists(new TimerCallback(UpdateCountDown)))
		{
			Timers.inst.Remove(new TimerCallback(UpdateCountDown));
		}
		string text = (flag2 ? "jianzaozhong" : "dengdai");
		UpdateShipSkin(CurShip, text);
		UpdateBuildingSpine(BuildingSpine, "yuanzhengdatingtx", "skin1", text, 1f, 1f);
	}

	private void UpdateCountDown(object param = null)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		int num = TargetBuildCompleteTime - (int)GameController.Instance.GetServerTime();
		if (num <= 0)
		{
			if (Timers.inst.Exists(new TimerCallback(UpdateCountDown)))
			{
				Timers.inst.Remove(new TimerCallback(UpdateCountDown));
			}
			((GObject)BuildTimeInfo.Info).text = UiHelper.ParseTime(0) ?? "";
			OnBuildFinished();
		}
		((GObject)BuildTimeInfo.Info).text = UiHelper.ParseTime(num) ?? "";
	}

	private void UpdateBuildingSpine(GGraph spineLoader, string spineName, string skin, string anim, float scale, float dir)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		if (((GObject)spineLoader).data == null)
		{
			GameObject val = UiHelper.LoadSpine_AB(spineName, 100f * scale, delegate(SkeletonAnimation animation)
			{
				SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, skin);
				animation.AnimationState.SetAnimation(0, anim, true);
				_buildAnimation = animation;
			});
			Vector3 localScale = val.transform.localScale;
			localScale.x *= dir;
			val.transform.localScale = localScale;
			GoWrapper val2 = new GoWrapper(val)
			{
				supportStencil = true
			};
			spineLoader.SetNativeObject((DisplayObject)(object)val2);
			((GObject)spineLoader).data = val2;
			AnimObj_List.Add(val);
		}
		else
		{
			SkeletonAnimation buildAnimation = _buildAnimation;
			if (buildAnimation != null)
			{
				buildAnimation.AnimationState.SetAnimation(0, anim, true);
			}
		}
	}

	private void UpdateShipSkin(GvGMode3ShipModel ship, string animationName)
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		int num = 0;
		if (ship.PermanentData.IsJoinIZ && Singleton<GvGMode3RoomManager>.Instance.IsConnecting)
		{
			num = ship.TemporaryData.ShipSkinId;
		}
		else
		{
			ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(ship.PermanentData.ShipRace);
			num = byShipRaceType.DefaultSkinId;
		}
		GameObject cache = ShipAnimCacheManager.GetCache("", num, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, animationName, true);
		}, isMask: false, isSimpleSpine: false, delegate(SkeletonAnimation animation)
		{
			animation.AnimationState.SetAnimation(0, animationName, true);
		});
		cache.transform.localScale = new Vector3(45f, 45f, 45f);
		cache.SetActive(true);
		if (((GObject)SpineLoader).data == null)
		{
			GoWrapper val = new GoWrapper(cache)
			{
				supportStencil = true
			};
			SpineLoader.SetNativeObject((DisplayObject)(object)val);
			((GObject)SpineLoader).data = val;
		}
		else
		{
			((GoWrapper)((GObject)SpineLoader).data).wrapTarget = cache;
		}
	}

	private void ClearShipSpine()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		if (((GObject)SpineLoader).data != null && !((Object)(object)((GoWrapper)((GObject)SpineLoader).data).wrapTarget == (Object)null))
		{
			((GoWrapper)((GObject)SpineLoader).data).wrapTarget.SetActive(false);
		}
	}
}
