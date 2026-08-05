using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.Helpers;
using Spine.Unity;
using UnityEngine;

namespace UI.GvGShipPopup;

public class UI_main_RebuildShipPanel : GComponent, IUiController
{
	private class ClearActions
	{
		public readonly List<Action> ActionList = new List<Action>(3);

		public int FinishCount;

		private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(0.03f);

		public bool NeedToClear => ActionList.Count > 0;

		public void ExecuteActions(Action onFinished = null)
		{
			FGUIManager.Instance.OpenIEnumerator(Execute());
			IEnumerator Execute()
			{
				if (ActionList.Count > 0)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
					foreach (Action action2 in ActionList)
					{
						action2?.Invoke();
						yield return _waitForSeconds;
					}
					while (FinishCount < ActionList.Count)
					{
						yield return _waitForSeconds;
					}
					onFinished?.Invoke();
					"GvG3_RebuildShip_Already_Clear_Tip".ToShowLanguageTip();
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				}
			}
		}
	}

	public GGraph back;

	public UI_com_RebuildShip Dialog;

	public Transition Popup;

	public const string URL = "ui://pwrbvhpvpglz65";

	public static string Name = "UI_main_RebuildShipPanel";

	private Dictionary<int, int> BuildableShipType;

	private UICallbackParam<Action<UI_main_BuildConfirmPanel.BuildParam>> OnBuildStartedCallback;

	private UICallbackParam<Action> OnClearShipDataCallback;

	private ShipAnimCacheManager _shipAnimCacheManager;

	private GoWrapper _newShipGoWrapper;

	private GoWrapper _oldShipGoWrapper;

	private string ShipId;

	private int CurShipRace;

	private const string GvG3RebuildShipRequirementsTip = "GvG3_RebuildShip_Requirements_Tip";

	private eRace SelectedNewShipRace
	{
		get
		{
			if (Dialog.RaceList.selectedIndex == -1)
			{
				return eRace.Invalid;
			}
			UI_RaceTypeBig2 uI_RaceTypeBig = (UI_RaceTypeBig2)(object)((GComponent)Dialog.RaceList).GetChildAt(Dialog.RaceList.selectedIndex);
			return uI_RaceTypeBig.icon.url.IconUrlToRace();
		}
	}

	public static string GetURL()
	{
		return "ui://pwrbvhpvpglz65";
	}

	public static UI_main_RebuildShipPanel CreateInstance()
	{
		return (UI_main_RebuildShipPanel)(object)UIPackage.CreateObject("GvGShipPopup", "main_RebuildShipPanel");
	}

	public static UI_main_RebuildShipPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_RebuildShipPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvpglz65", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_RebuildShip)(object)((GComponent)this).GetChild("Dialog");
		Popup = ((GComponent)this).GetTransition("Popup");
	}

	private bool CheckShipTypeAvailable(int type)
	{
		int value;
		return BuildableShipType.TryGetValue(type, out value) && value > 0 && type != CurShipRace;
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		ShipId = (parameters.TryGetValue("ShipId", out var value) ? ((string)value) : "");
		CurShipRace = (parameters.TryGetValue("ShipRace", out var value2) ? ((int)value2) : (-1));
		BuildableShipType = (parameters.TryGetValue("BuildableShipType", out var value3) ? ((Dictionary<int, int>)value3) : null);
		OnBuildStartedCallback = (parameters.TryGetValue("OnBuildStarted", out var value4) ? ((UICallbackParam<Action<UI_main_BuildConfirmPanel.BuildParam>>)value4) : null);
		OnClearShipDataCallback = (parameters.TryGetValue("OnClearShipData", out var value5) ? ((UICallbackParam<Action>)value5) : null);
		_shipAnimCacheManager = new ShipAnimCacheManager();
		_newShipGoWrapper = new GoWrapper();
		Dialog.NewSpineLoader.SetNativeObject((DisplayObject)(object)_newShipGoWrapper);
		_oldShipGoWrapper = new GoWrapper();
		Dialog.OldSpineLoader.SetNativeObject((DisplayObject)(object)_oldShipGoWrapper);
		List<int> list = new List<int>(5);
		Dialog.RaceList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RaceTabRenderer((UI_RaceTypeBig2)(object)o);
		};
		Dialog.RaceList.numItems = Dialog.RaceList.numItems;
		CheckForAnyRace();
		UpdateShipSkin(CurShipRace, _oldShipGoWrapper, "OldShip");
		((GObject)Dialog.OldRaceName.Title).text = ShipConfigHelper.GetByShipRaceType(CurShipRace).DefaultName;
		Dialog.OldRace.url = ((eRace)CurShipRace).ToRaceIconUrl();
		SetCurrentSelectRace();
	}

	private void CheckForAnyRace()
	{
		if ("I67506".IsActive())
		{
			return;
		}
		for (int num = ((GComponent)Dialog.RaceList).numChildren - 1; num >= 0; num--)
		{
			UI_RaceTypeBig2 uI_RaceTypeBig = (UI_RaceTypeBig2)(object)((GComponent)Dialog.RaceList).GetChildAt(num);
			if (eRace.全种族 == uI_RaceTypeBig.icon.url.IconUrlToRace())
			{
				((GComponent)Dialog.RaceList).RemoveChildAt(num);
				break;
			}
		}
	}

	private void RaceTabRenderer(UI_RaceTypeBig2 item)
	{
		int type = (int)item.icon.url.IconUrlToRace();
		bool flag = !CheckShipTypeAvailable(type);
		item.IsNotAvailable.SetSelectedIndex(flag ? 1 : 0);
		((GObject)item).touchable = !flag;
	}

	private void SetCurrentSelectRace()
	{
		int num = 0;
		GObject[] children = ((GComponent)Dialog.RaceList).GetChildren();
		foreach (GObject val in children)
		{
			UI_RaceTypeBig2 uI_RaceTypeBig = (UI_RaceTypeBig2)(object)val;
			int type = (int)uI_RaceTypeBig.icon.url.IconUrlToRace();
			if (CheckShipTypeAvailable(type))
			{
				Dialog.RaceList.selectedIndex = num;
				OnChangeTab();
				break;
			}
			num++;
		}
	}

	private void UpdateShipSkin(int type, GoWrapper goWrapper, string instanceId)
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(type);
		if ((Object)(object)goWrapper.wrapTarget != (Object)null)
		{
			goWrapper.wrapTarget.SetActive(false);
		}
		goWrapper.wrapTarget = _shipAnimCacheManager.GetCache(instanceId, byShipRaceType.DefaultSkinId, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "tuzhi", true);
		}, isMask: false, isSimpleSpine: false, delegate(SkeletonAnimation animation)
		{
			animation.AnimationState.SetAnimation(0, "tuzhi", true);
		});
		goWrapper.wrapTarget.SetActive(true);
		goWrapper.wrapTarget.transform.localScale = new Vector3(60f, 60f, 60f);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GObject)Dialog.ConfirmBuildBtn).onClick.Set(new EventCallback1(OnConfirmBuild));
		((GObject)Dialog.CloseBtn).onClick.Set(new EventCallback0(End));
		Dialog.RaceList.onClickItem.Set(new EventCallback0(OnChangeTab));
		((GObject)back).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Dialog.ConfirmBuildBtn).onClick.Clear();
		((GObject)Dialog.CloseBtn).onClick.Clear();
		Dialog.RaceList.onClickItem.Clear();
		((GObject)back).onClick.Clear();
	}

	private void OnConfirmBuild(EventContext context)
	{
		ClearActions clearData = null;
		GvGAmplifierManager.ShipAmplifiersData shipAmplifiers;
		Singleton<GvGAmplifierManager>.Instance.GetShipAmplifiers(ShipId, delegate(GvGAmplifierManager.ShipAmplifiersData amplifiersData)
		{
			shipAmplifiers = amplifiersData;
			if (NeedToClearData())
			{
				ClearShipUserData();
			}
			else
			{
				RebuildConfirm();
			}
		});
		void ClearShipUserData()
		{
			"GvG3_RebuildShip_Requirements_Tip".ToLanguage().ToConfirmPopup(ExecuteClear, null, (AlignType)0);
		}
		void ExecuteClear()
		{
			clearData?.ExecuteActions(OnClearShipDataCallback?.Callback);
		}
		bool NeedToClearData()
		{
			clearData = new ClearActions();
			GvGMode3ShipTemporaryData temporaryData = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipData(ShipId).TemporaryData;
			if (temporaryData == null)
			{
				return false;
			}
			if ((temporaryData.Group != null && temporaryData.Group.Any()) || (temporaryData.BackupGroup != null && temporaryData.BackupGroup.Any()))
			{
				clearData.ActionList.Add(delegate
				{
					OfflineShipSoldier(ShipId, delegate
					{
						clearData.FinishCount++;
					});
				});
			}
			if (temporaryData.WorkersOnboardCount > 0)
			{
				clearData.ActionList.Add(delegate
				{
					OfflineShipWorker(ShipId, delegate
					{
						clearData.FinishCount++;
					});
				});
			}
			if (shipAmplifiers.ShipsAmplifiers != null && shipAmplifiers.ShipsAmplifiers.Count > 0)
			{
				Dictionary<int, int> clearAmplifiers = new Dictionary<int, int>();
				foreach (KeyValuePair<int, int> shipsAmplifier in shipAmplifiers.ShipsAmplifiers)
				{
					clearAmplifiers.Add(shipsAmplifier.Key, -shipsAmplifier.Value);
				}
				clearData.ActionList.Add(delegate
				{
					Singleton<GvGAmplifierManager>.Instance.ChangeShipAmplifiers(ShipId, clearAmplifiers, delegate
					{
						clearData.FinishCount++;
					});
				});
			}
			return clearData.NeedToClear;
		}
		void RebuildConfirm()
		{
			int selectedNewShipRace = (int)SelectedNewShipRace;
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_BuildConfirmPanel.Name, new Dictionary<string, object>
			{
				{
					"BuildType",
					eShipBuildType.Rebuilding
				},
				{ "ShipType", selectedNewShipRace },
				{
					"OnConfirm",
					new UICallbackParam<Action<UI_main_BuildConfirmPanel.BuildParam>>(OnConfirmRebuild)
				}
			});
		}
	}

	private void OnConfirmRebuild(UI_main_BuildConfirmPanel.BuildParam buildParam)
	{
		Singleton<GvGMode3RoomManager>.Instance.RebuildShip(ShipId, buildParam.ShipRace, buildParam.CurWorkerCount, buildParam.FastBuild, delegate
		{
			OnBuildStartedCallback?.Callback?.Invoke(buildParam);
			End();
		});
	}

	private void OnChangeTab()
	{
		eRace selectedNewShipRace = SelectedNewShipRace;
		int num = (int)selectedNewShipRace;
		BuildableShipType.TryGetValue(num, out var value);
		Dialog.IsNotAvailable.selectedIndex = ((value == 0) ? 1 : 0);
		if (selectedNewShipRace == eRace.Invalid)
		{
			((DisplayObject)_newShipGoWrapper).visible = false;
			return;
		}
		((DisplayObject)_newShipGoWrapper).visible = true;
		((GObject)Dialog.NewRaceName.Title).text = ShipConfigHelper.GetByShipRaceType(num).DefaultName;
		Dialog.NewRace.url = selectedNewShipRace.ToRaceIconUrl();
		UpdateShipSkin(num, _newShipGoWrapper, num.ToString());
	}

	public void OfflineShipSoldier(string shipId, Action<bool> onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_OfflineShipSoldier
		{
			Req = new C2S_OfflineShipSoldier.Request
			{
				ShipId = shipId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_OfflineShipSoldier.Response response = (C2S_OfflineShipSoldier.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished?.Invoke(obj: false);
			}
			else
			{
				onFinished?.Invoke(obj: true);
			}
		});
	}

	public void OfflineShipWorker(string shipId, Action<bool> onFinished = null)
	{
		ILRequestHelper<GvGMode3ChangeShipConfigResponse>.Request((EventContext)null, (Func<Task<GvGMode3ChangeShipConfigResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3ChangeShipConfig(shipId, 1, JsonHelper.ToJson(new GvGMode3ChangeShipConfigAction_ChangeWorker
		{
			WorkerCount = 0
		}))), (Action<GvGMode3ChangeShipConfigResponse>)delegate(GvGMode3ChangeShipConfigResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished?.Invoke(obj: false);
			}
			else
			{
				Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipData(shipId).TemporaryData.WorkersOnboardCount = 0;
				SharedMessenger.Broadcast("ON_GVG3_ShipWorkersModified");
				GvGMode3ObserverRecord gvGMode3ObserverRecord = GameManagers.Instance.UserArchiveManager.LoadGvGMode3Record();
				GvGMode3ShipModel gvGMode3ShipModel = gvGMode3ObserverRecord.Ships.Find((GvGMode3ShipModel ship) => ship.ShipId == shipId);
				gvGMode3ShipModel.PermanentData.ManPower = 0;
				GameManagers.Instance.UserArchiveManager.SaveGvGMode3Record(gvGMode3ObserverRecord);
				ShipStateModel shipStateModel = Singleton<WorldStateManager>.Instance.TryGetMyShip(shipId);
				if (shipStateModel != null)
				{
					Singleton<WorldStateManager>.Instance.TryGetShip(shipStateModel.EntityId).SyncInfoOnRebuildActionFinished();
				}
				onFinished?.Invoke(obj: true);
			}
		});
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
		_shipAnimCacheManager?.ClearCache();
	}

	public void Destroy()
	{
	}
}
