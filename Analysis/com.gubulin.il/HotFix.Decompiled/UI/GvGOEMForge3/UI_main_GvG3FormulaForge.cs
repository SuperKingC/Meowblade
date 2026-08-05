using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UI.GvGOEMBonus3;
using UI.PublicResources;
using UI.Tips;
using UnityEngine;

namespace UI.GvGOEMForge3;

public class UI_main_GvG3FormulaForge : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_FormulaOemForge PopUp;

	public GGraph MaskHelp;

	public UI_com_FormulaOemForgeHelp HelpDialog;

	public Transition t0;

	public Transition showHelp;

	public const string URL = "ui://hotvoz3pt0zv61";

	public static string Name = "UI_main_GvG3FormulaForge";

	public const string MuidParam = "Muid";

	public const string ReloadCallback = "ReloadAction";

	private List<GameObject> _vfxList;

	private bool _enableClick;

	private int _muid;

	private Action _loadCallback;

	public static string GetURL()
	{
		return "ui://hotvoz3pt0zv61";
	}

	public static UI_main_GvG3FormulaForge CreateInstance()
	{
		return (UI_main_GvG3FormulaForge)(object)UIPackage.CreateObject("GvGOEMForge3", "main_GvG3FormulaForge");
	}

	public static UI_main_GvG3FormulaForge CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3FormulaForge).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hotvoz3pt0zv61", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PopUp = (UI_com_FormulaOemForge)(object)((GComponent)this).GetChild("PopUp");
		MaskHelp = (GGraph)((GComponent)this).GetChild("MaskHelp");
		HelpDialog = (UI_com_FormulaOemForgeHelp)(object)((GComponent)this).GetChild("HelpDialog");
		t0 = ((GComponent)this).GetTransition("t0");
		showHelp = ((GComponent)this).GetTransition("showHelp");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		((GObject)PopUp.HighQualityRateHelpBtn).onClick.Set(new EventCallback0(ShowHelpDialog));
		((GObject)MaskHelp).onClick.Set(new EventCallback0(HideHelpDialog));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)PopUp.HighQualityRateHelpBtn).onClick.Clear();
		((GObject)MaskHelp).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_muid = (int)parameters["Muid"];
		if (parameters.TryGetValue("ReloadAction", out var value))
		{
			_loadCallback = (Action)value;
		}
		_enableClick = true;
		HideHelpDialog();
		ReLoadData();
	}

	private void ReLoadData()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_RefreshFormulaOEMMissios
		{
			Req = new C2S_RefreshFormulaOEMMissios.Request
			{
				MUIDs = new List<int> { _muid }
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_RefreshFormulaOEMMissios.Response response = (C2S_RefreshFormulaOEMMissios.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				InitWithData(response.Details[0], _muid);
			}
		});
	}

	private void InitWithData(FormulaOEMMissionsDetail detail, int muid)
	{
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		((GObject)PopUp.useCount).text = $"{detail.TotalCount - detail.FinishCount}/{detail.TotalCount}";
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(UpdateRemainTime(detail.CloseTimestamp));
		OemMissionAmplifier oemMissionAmplifier = OemMissionAmplifierConfigHelper.GetOemMissionAmplifier(detail.AmpIdx);
		InitVfx();
		((GObject)PopUp.AmpName).text = oemMissionAmplifier.AmplifierModel.Name;
		RenderHelper_AmpAffectedRange.RenderAmplifierAffectedSoldier(PopUp.AffectedRange, oemMissionAmplifier.AmpIdx);
		int quality = oemMissionAmplifier.AmplifierModel.Quality;
		PopUp.Quatity.selectedIndex = quality;
		float ampForgeHighQualityRate = OemMissionAmplifierConfigHelper.GetAmpForgeHighQualityRate(oemMissionAmplifier.AmpIdx);
		string text = $"{detail.CriRate + ampForgeHighQualityRate:0.#}%";
		int criRateLevel = GetCriRateLevel(detail.CriRate);
		((GObject)PopUp.BonusCnt).text = text;
		PopUp.RateLevel.SetSelectedIndex(criRateLevel);
		((GObject)HelpDialog.BonusCnt).text = text;
		HelpDialog.RateLevel.SetSelectedIndex(criRateLevel);
		PopUp.ProfileDisplay.RenderPlayerProfileGvG3(new PlayerProfileParams<UI_com_ProfileDisplayAmpLeft>
		{
			CacheVersion = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}",
			UserId = detail.UserId,
			CampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId,
			OnProfileLoaded = delegate(UI_com_ProfileDisplayAmpLeft displayUi)
			{
				displayUi.Style.SetSelectedIndex((((GComponent)displayUi.Medals).numChildren <= 0) ? 1 : 0);
			}
		}, detail.UserId);
		List<KeyValuePair<string, int>> consumes = new List<KeyValuePair<string, int>>(oemMissionAmplifier.AmplifierFormulaModel.Input_Dict);
		bool isInvalid = false;
		PopUp.ConsumeList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			UI_com_FormulaConsumeItem uI_com_FormulaConsumeItem = (UI_com_FormulaConsumeItem)(object)item;
			KeyValuePair<string, int> keyValuePair = consumes[index];
			FGUIManager.Instance.SetItemIconAndFrame(uI_com_FormulaConsumeItem.Icon, keyValuePair.Key, null, "", frameVisible: false);
			string key = keyValuePair.Key;
			int value = keyValuePair.Value;
			uI_com_FormulaConsumeItem.Icon.InitMaterialIntroductionBtn(key);
			int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(key, includingGSStock: true);
			if (itemCount < value)
			{
				isInvalid = true;
				uI_com_FormulaConsumeItem.color.selectedIndex = 1;
			}
			else
			{
				uI_com_FormulaConsumeItem.color.selectedIndex = 0;
			}
			((GObject)uI_com_FormulaConsumeItem.Num).text = itemCount.ShortNumberFormat() + "/" + value.ShortNumberFormat();
		};
		PopUp.ConsumeList.numItems = consumes.Count;
		PopUp.CanForge.SetSelectedIndex((!isInvalid) ? 1 : 0);
		PopUp.hasTalent.SetSelectedIndex(detail.HasTitanTalent ? 1 : 0);
		HelpDialog.hasTalent.SetSelectedIndex(detail.HasTitanTalent ? 1 : 0);
		((GObject)PopUp.ForgeBtn).onClick.Set((EventCallback0)delegate
		{
			if (!isInvalid)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
				SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_SubmitFormulaOEMMission
				{
					Req = new C2S_SubmitFormulaOEMMission.Request
					{
						MUID = muid
					}
				}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
				{
					//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
					//IL_00f3: Expected O, but got Unknown
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
					C2S_SubmitFormulaOEMMission.Response res = (C2S_SubmitFormulaOEMMission.Response)contextResponse.Resp;
					if (res.ErrorCode != 0)
					{
						ILRequestHelper.ShowErrorCode(res.ErrorCode);
						ReLoadData();
					}
					else
					{
						GvG3FlagshipReqManager.SetGsStock(res.TakerStorehouseChanged);
						Singleton<GvGAmplifierManager>.Instance.SyncAmplifierStorageWithCurValueChanges(res.AmplifierStorageCurValueChanges);
						Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse();
						((GObject)PopUp.ForgeBtn).enabled = false;
						PopUp.ForgeController.selectedIndex = 1;
						_enableClick = false;
						((GComponent)(object)this).SetTimeout(4f).OnComplete((GTweenCallback)delegate
						{
							GameController.Contexts.Service<IUiService>().ClosePanel(Name);
							GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3FormulaOemBonus.Name, new Dictionary<string, object> { { "Result", res } });
							_loadCallback?.Invoke();
						});
					}
				});
			}
		});
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
		ReleaseSfx();
	}

	public void Destroy()
	{
	}

	private void InitVfx()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		_vfxList = new List<GameObject>();
		_vfxList.Add(FGUIManager.Instance.AddTextSpecialEffects(PopUp.ui_amplifier_forge_gun, "ui_amplifier_forge_gun", new Vector3(100f, 100f, 100f)));
		GameObject val = FGUIManager.Instance.AddTextSpecialEffects(PopUp.ui_amplifier_forge_gun2, "ui_amplifier_forge_gun", new Vector3(100f, 100f, 100f));
		if ((Object)(object)val != (Object)null)
		{
			val.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
		}
		_vfxList.Add(val);
		_vfxList.Add(FGUIManager.Instance.AddTextSpecialEffects(PopUp.ui_amplifier_forge_icon, "ui_amplifier_forge_icon", new Vector3(100f, 100f, 100f)));
	}

	private void ReleaseSfx()
	{
		if (_vfxList == null || _vfxList.Count == 0)
		{
			return;
		}
		foreach (GameObject vfx in _vfxList)
		{
			if ((Object)(object)vfx != (Object)null)
			{
				SpawnManager.Instance.Destroy(vfx);
			}
		}
	}

	private void End()
	{
		if (_enableClick)
		{
			GameController.Contexts.Service<IUiService>().ClosePanel(Name);
			_loadCallback?.Invoke();
		}
	}

	private void ShowHelpDialog()
	{
		((GObject)HelpDialog).visible = true;
		((GObject)MaskHelp).visible = true;
		showHelp.Play();
	}

	private void HideHelpDialog()
	{
		((GObject)HelpDialog).visible = false;
		((GObject)MaskHelp).visible = false;
	}

	private IEnumerator UpdateRemainTime(int closeTimeStamp)
	{
		WaitForSeconds wait = new WaitForSeconds(1f);
		while (!((GObject)this).isDisposed)
		{
			int remainTime = (int)(closeTimeStamp - GameController.Instance.GetServerTime());
			((GObject)PopUp.remainTime).text = UiHelper.ParseTime(remainTime);
			yield return wait;
		}
	}

	public static int GetCriRateLevel(float rate)
	{
		int num = (int)(rate * 10f);
		return Mathf.Clamp(num / 25, 0, 4);
	}
}
