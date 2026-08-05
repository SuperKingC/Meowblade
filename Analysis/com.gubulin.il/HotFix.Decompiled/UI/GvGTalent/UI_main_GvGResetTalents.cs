using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGTalent.OuterTechStatic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UnityEngine;

namespace UI.GvGTalent;

public class UI_main_GvGResetTalents : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_ResetTalentsDialog Dialog;

	public Transition t0;

	public const string URL = "ui://4r1llhd8xohkf";

	public static string Name = "UI_main_GvGResetTalents";

	private bool _resetItemIsEnough;

	private bool _魔的第八天TimeIsEnough;

	private readonly Lazy<魔的第八天TalentEffect> _魔的第八天Lazy = new Lazy<魔的第八天TalentEffect>(() => new 魔的第八天TalentEffect());

	private 十六加八TalentEffect _十六加八TalentEffect;

	private long TalentsCost;

	private bool CanReset => (!UseOuterTechReset) ? _resetItemIsEnough : (_魔的第八天TimeIsEnough && Is魔的第八天CountDownOver());

	private bool UseOuterTechReset => Dialog.Page.selectedIndex == 1;

	private 魔的第八天TalentEffect 魔的第八天 => _魔的第八天Lazy.Value;

	public static string GetURL()
	{
		return "ui://4r1llhd8xohkf";
	}

	public static UI_main_GvGResetTalents CreateInstance()
	{
		return (UI_main_GvGResetTalents)(object)UIPackage.CreateObject("GvGTalent", "main_GvGResetTalents");
	}

	public static UI_main_GvGResetTalents CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvGResetTalents).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8xohkf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_ResetTalentsDialog)(object)((GComponent)this).GetChild("Dialog");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		_十六加八TalentEffect = null;
	}

	public void Init(Dictionary<string, object> parameters)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetActivateTalentStat
		{
			Req = new C2S_GetActivateTalentStat.Request()
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetActivateTalentStat.Response response = (C2S_GetActivateTalentStat.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				End();
			}
			TalentsCost = response.RealPointConsumed;
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
			_十六加八TalentEffect = (parameters.TryGetValue("OuterTechI67301Data", out var value) ? ((十六加八TalentEffect)value) : null);
			RenderMainUi();
		});
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((GObject)Dialog.Cancel).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Add(new EventCallback0(ResetTalents));
		Dialog.Page.onChanged.Set(new EventCallback0(SetStatusOnPageChanged));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Dialog.Cancel).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Remove(new EventCallback0(ResetTalents));
		Dialog.Page.onChanged.Clear();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderMainUi()
	{
		int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount("I32018", includingGSStock: true);
		bool flag = itemCount > 0;
		bool flag2 = "I67501".IsActive() && flag;
		Dialog.OuterTechIsActive.SetSelectedIndex(flag2 ? 1 : 0);
		Dialog.Page.SetSelectedIndex((!flag) ? 1 : 0);
		Display重置券Page();
		Display魔的第八天Page();
		DisplayReturnResource();
		SetStatusOnPageChanged();
	}

	private void Display重置券Page()
	{
		int num = 1;
		int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount("I32018", includingGSStock: true);
		Dialog.Icon.url = UiHelper.GetIcon("I32018").ToPublicResourceIcon();
		((GObject)Dialog.Num).text = $"{itemCount}/{num}";
		_resetItemIsEnough = itemCount >= num;
	}

	private void Display魔的第八天Page()
	{
		string text = Item.Name(GameManagers.Instance, "I32017");
		((GObject)Dialog.ReturnPercent).text = "GvG3OuterTechI67301ReturnPercent".ToLanguage().Format(new object[2] { text, 魔的第八天.魔的第八天ReturnPercentStr });
		_魔的第八天TimeIsEnough = 魔的第八天.LimitTime > 0;
		string arg = (_魔的第八天TimeIsEnough ? "#aef224" : "#ff1a1a");
		((GObject)Dialog.OuterTechTimes).text = $"[color={arg}]{魔的第八天.LimitTime}/[/color]{魔的第八天.魔的第八天TotalTimes}";
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(UpdateCountDown());
	}

	private static bool Is魔的第八天CountDownOver()
	{
		long serverTime = GameController.Instance.GetServerTime();
		long unlockTime = 魔的第八天TalentEffect.GetUnlockTime();
		return serverTime >= unlockTime;
	}

	private void DisplayReturnResource()
	{
		Dialog.ReturnIcon.url = UiHelper.GetIcon("I32017").ToPublicResourceIcon();
	}

	private void SetStatusOnPageChanged()
	{
		if (_十六加八TalentEffect != null)
		{
			Dialog.Status.selectedIndex = ((!CanReset) ? 1 : 0);
			float num = 魔的第八天.魔的第八天ReturnPercentValue / 100f;
			((GObject)Dialog.ReturnNum).text = Mathf.CeilToInt((float)TalentsCost * (UseOuterTechReset ? num : 1f)).ToString();
		}
	}

	private void ResetTalents()
	{
		Singleton<GvGTalentsManager>.Instance.ResetTalents(UseOuterTechReset, OnResetFinished);
		void OnResetFinished()
		{
			SharedMessenger.Broadcast("ON__GVG3_TALENTS_RESET");
			End();
		}
	}

	private IEnumerator UpdateCountDown()
	{
		long unlockTime = 魔的第八天TalentEffect.GetUnlockTime();
		WaitForSeconds wait = new WaitForSeconds(1f);
		while (!((GObject)this).isDisposed)
		{
			long now = GameController.Instance.GetServerTime();
			long countDown = (long)Mathf.Max((float)(unlockTime - now), 0f);
			Dialog.ShowCountDown.SetSelectedIndex((countDown > 0) ? 1 : 0);
			((GObject)Dialog.OuterTechCountDown).text = UiHelper.ParseTime((int)countDown);
			if (countDown <= 0)
			{
				break;
			}
			yield return wait;
		}
	}
}
