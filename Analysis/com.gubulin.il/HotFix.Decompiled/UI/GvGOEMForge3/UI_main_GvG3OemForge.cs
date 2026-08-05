using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGOEMForge3;

public class UI_main_GvG3OemForge : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Action<UI_com_ProfileDisplayAmpLeft> _003C_003E9__20_3;

		public static GTweenCallback _003C_003E9__25_1;

		internal void _003CRender_003Eb__20_3(UI_com_ProfileDisplayAmpLeft displayUi)
		{
			displayUi.Style.SetSelectedIndex((((GComponent)displayUi.Medals).numChildren <= 0) ? 1 : 0);
		}

		internal void _003CSubmitMission_003Eb__25_1()
		{
			GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		}
	}

	public GGraph Mask;

	public UI_com_AmplifierOemForge PopUp;

	public GGraph MaskHelp;

	public UI_com_AmplifierOemForgeHelp n3;

	public Transition t0;

	public Transition ShowHelpTip;

	public const string URL = "ui://hotvoz3ppg605n";

	public static string Name = "UI_main_GvG3OemForge";

	private bool _enableClick;

	private OemMissionToProtocol _oemMission;

	private List<GameObject> _vfxList;

	private float _ampConsumeDiscountRate;

	private float _extraAmpForgeHighQualityRate;

	public static string GetURL()
	{
		return "ui://hotvoz3ppg605n";
	}

	public static UI_main_GvG3OemForge CreateInstance()
	{
		return (UI_main_GvG3OemForge)(object)UIPackage.CreateObject("GvGOEMForge3", "main_GvG3OemForge");
	}

	public static UI_main_GvG3OemForge CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3OemForge).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hotvoz3ppg605n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		PopUp = (UI_com_AmplifierOemForge)(object)((GComponent)this).GetChild("PopUp");
		MaskHelp = (GGraph)((GComponent)this).GetChild("MaskHelp");
		n3 = (UI_com_AmplifierOemForgeHelp)(object)((GComponent)this).GetChild("n3");
		t0 = ((GComponent)this).GetTransition("t0");
		ShowHelpTip = ((GComponent)this).GetTransition("ShowHelpTip");
	}

	public void BeforeDestroy()
	{
		ReleaseSfx();
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		_enableClick = true;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_oemMission = (parameters.TryGetValue("OemMission", out var value) ? (value as OemMissionToProtocol) : null);
		Render();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		((GObject)PopUp.ForgeBtn).onClick.Set(new EventCallback0(SubmitMission));
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		((GObject)PopUp.ExtraHighQualityRateBtn).onClick.Set(new EventCallback1(OnClickExtraForgeHighQualityRateBtn));
		((GObject)PopUp.HighQualityRateHelpBtn).onClick.Set(new EventCallback0(OnClickShowTip));
		((GObject)MaskHelp).onClick.Set(new EventCallback0(OnClickHideTip));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)PopUp.ForgeBtn).onClick.Clear();
		((GObject)Mask).onClick.Clear();
		((GObject)PopUp.ExtraHighQualityRateBtn).onClick.Clear();
		((GObject)PopUp.HighQualityRateHelpBtn).onClick.Clear();
		((GObject)MaskHelp).onClick.Clear();
	}

	private void End()
	{
		if (_enableClick)
		{
			GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		}
	}

	private void Render()
	{
		((GObject)PopUp.ExtraHighQualityRateBtn).visible = false;
		InitVfx();
		OemMissionAmplifier ampConfig = OemMissionAmplifierConfigHelper.GetOemMissionAmplifier(_oemMission.AmpIdx);
		((GObject)PopUp.AmpName).text = ampConfig.AmplifierModel.Name;
		RenderHelper_AmpAffectedRange.RenderAmplifierAffectedSoldier(PopUp.AffectedRange, ampConfig.AmpIdx);
		int quality = ampConfig.AmplifierModel.Quality;
		PopUp.Quatity.selectedIndex = quality;
		RenderBonus();
		RenderConsume(ampConfig.AmplifierFormulaModel.ReelItemId);
		RenderBuff(ampConfig.AmpIdx);
		PopUp.CurQuality.Quatity.selectedIndex = quality;
		PopUp.NextQuality.Quatity.selectedIndex = quality + 1;
		PopUp.ProfileDisplay.RenderPlayerProfileGvG3(new PlayerProfileParams<UI_com_ProfileDisplayAmpLeft>
		{
			CacheVersion = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}",
			UserId = _oemMission.GiverUserId,
			CampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId,
			OnProfileLoaded = delegate(UI_com_ProfileDisplayAmpLeft displayUi)
			{
				displayUi.Style.SetSelectedIndex((((GComponent)displayUi.Medals).numChildren <= 0) ? 1 : 0);
			}
		}, _oemMission.GiverUserId);
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(UpdateTimeRemain());
		OnClickHideTip();
		void RenderBonus()
		{
			if (ampConfig.Bonus != null)
			{
				KeyValuePair<string, int> baseBonus = ampConfig.Bonus.GetBaseBonus();
				PopUp.Extra.selectedIndex = (_oemMission.IsExtra ? 1 : 0);
				FGUIManager.Instance.SetItemIconAndFrame(PopUp.BonusIcon, baseBonus.Key, null, "", frameVisible: false);
				((GObject)PopUp.BonusCnt).text = baseBonus.Value.ToString();
				if (_oemMission.IsExtra)
				{
					KeyValuePair<string, int> extraBonus = ampConfig.Bonus.GetExtraBonus();
					((GObject)PopUp.ExtraBonusCnt).text = $"（+{extraBonus.Value}）";
				}
			}
		}
		void RenderBuff(int ampIdx)
		{
			Singleton<GvGAmplifierManager>.Instance.SyncAmplifierTalentData(delegate
			{
				_ampConsumeDiscountRate = Singleton<GvGAmplifierManager>.Instance.TalentData.AmpConsumeDiscountRate;
				_extraAmpForgeHighQualityRate = Singleton<GvGAmplifierManager>.Instance.TalentData.ExtraAmpForgeHighQualityRate;
				((GObject)PopUp.ExtraHighQualityRateBtn).visible = _extraAmpForgeHighQualityRate > 0f;
				((GObject)PopUp.HighQualityRate).text = $"{OemMissionAmplifierConfigHelper.GetAmpForgeHighQualityRate(ampIdx) + _extraAmpForgeHighQualityRate}%";
			});
		}
		void RenderConsume(string reelId)
		{
			int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(reelId, includingGSStock: true);
			int num = 1;
			bool flag = itemCount >= num;
			((GObject)PopUp.ForgeBtn).enabled = flag;
			PopUp.FormulaEnough.selectedIndex = (flag ? 1 : 0);
			((GObject)PopUp.FormulaNum).text = itemCount.ToString();
			((GObject)PopUp.ReqNum).text = $"/{num}";
			FGUIManager.Instance.SetItemIconAndFrame(PopUp.Icon, reelId, null, "", frameVisible: false);
			RenderHelper_AmpAffectedRange.RenderAmplifierAffectedSoldier(PopUp.AffectedRangeSmall, ampConfig.AmpIdx);
		}
	}

	private IEnumerator UpdateTimeRemain()
	{
		WaitForSeconds wait = new WaitForSeconds(1f);
		while (!((GObject)this).isDisposed)
		{
			int endTime = _oemMission.EndTimestamp - (int)GameController.Instance.GetServerTime();
			((GObject)PopUp.remainTime).text = UiHelper.ParseTime(endTime);
			yield return wait;
		}
	}

	private void OnClickExtraForgeHighQualityRateBtn(EventContext context)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		if (_enableClick)
		{
			PopUp.ExtraHighQualityRateBtn.SetPopupTips(string.Format("GvGExtraAmpForgeHighQualityRate".ToLanguage(), _extraAmpForgeHighQualityRate));
		}
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
		foreach (GameObject vfx in _vfxList)
		{
			if ((Object)(object)vfx != (Object)null)
			{
				SpawnManager.Instance.Destroy(vfx);
			}
		}
	}

	private void SubmitMission()
	{
		if (_enableClick)
		{
			Singleton<GvG3FlagshipReqManager>.Instance.SubmitOemMission(_oemMission.Muid, 4f, _oemMission.AmpIdx, ForgeFinish);
		}
		void ForgeFinish()
		{
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Expected O, but got Unknown
			Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse();
			((GObject)PopUp.ForgeBtn).enabled = false;
			PopUp.ForgeController.selectedIndex = 1;
			_enableClick = false;
			GTweener obj = ((GComponent)(object)this).SetTimeout(4f);
			object obj2 = _003C_003Ec._003C_003E9__25_1;
			if (obj2 == null)
			{
				GTweenCallback val = delegate
				{
					GameController.Contexts.Service<IUiService>().ClosePanel(Name);
				};
				_003C_003Ec._003C_003E9__25_1 = val;
				obj2 = (object)val;
			}
			obj.OnComplete((GTweenCallback)obj2);
		}
	}

	private void OnClickShowTip()
	{
		((GObject)n3).visible = true;
		((GObject)MaskHelp).visible = true;
		ShowHelpTip.Play();
	}

	private void OnClickHideTip()
	{
		((GObject)n3).visible = false;
		((GObject)MaskHelp).visible = false;
	}
}
