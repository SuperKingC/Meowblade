using System;
using System.Collections;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using UnityEngine;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_WaitNight : GComponent, IFairyComponent
{
	public Controller Type;

	public GImage n0;

	public GImage n5;

	public GImage n6;

	public GTextField n1;

	public GTextField n2;

	public GTextField Countdown;

	public UI_btn_Continue ContinueProgress;

	public GImage n7;

	public GTextField n8;

	public Transition t0;

	public const string URL = "ui://249h3k3dc4i72m";

	public static string Name = "UI_com_WaitNight";

	private Coroutine _updateCountdown;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	private int CurrentTimestamp => (int)GameController.Instance.GetServerTime();

	private bool Activated => Singleton<GvG3FlagShipMissionsManager>.Instance.IsWaitEternalNight && !((GObject)this).isDisposed;

	private bool WaitOpenEternalNight => !Singleton<GvG3FlagShipMissionsManager>.Instance.EternalNightOpen && Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNight && !Singleton<GvG3FlagShipMissionsManager>.Instance.HasSettlement;

	public static string GetURL()
	{
		return "ui://249h3k3dc4i72m";
	}

	public static UI_com_WaitNight CreateInstance()
	{
		return (UI_com_WaitNight)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_WaitNight");
	}

	public static UI_com_WaitNight CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_WaitNight).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dc4i72m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://249h3k3dc4i72m".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id2 = "ui://249h3k3dc4i72m".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id2);
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		ContinueProgress = (UI_btn_Continue)(object)((GComponent)this).GetChild("ContinueProgress");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id3 = "ui://249h3k3dc4i72m".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id3);
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void Destroy()
	{
		if (_updateCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
		}
	}

	public void Init()
	{
	}

	public void RegisterUiEvent()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.OnCampProgressChange = (Action)Delegate.Combine(instance.OnCampProgressChange, new Action(UpdateWaitOpenEternalNightUi));
		((GObject)ContinueProgress).onClick.Set(new EventCallback0(OpenEternalNight));
	}

	public void UnregisterUiEvent()
	{
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.OnCampProgressChange = (Action)Delegate.Remove(instance.OnCampProgressChange, new Action(UpdateWaitOpenEternalNightUi));
		((GObject)ContinueProgress).onClick.Clear();
	}

	public void Render()
	{
		if (Activated)
		{
			if (_updateCountdown != null)
			{
				FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
			}
			_updateCountdown = FGUIManager.Instance.OpenIEnumerator(RefreshCountdown());
			UpdateWaitOpenEternalNightUi();
		}
		IEnumerator RefreshCountdown()
		{
			while (!((GObject)this).isDisposed)
			{
				int startTimestamp = Singleton<WorldStateManager>.Instance.Data.FinalProgressBegin;
				((GObject)Countdown).text = UiHelper.ParseTimeShort(startTimestamp - CurrentTimestamp);
				yield return _perSecond;
			}
		}
	}

	private void UpdateWaitOpenEternalNightUi()
	{
		Type.selectedIndex = (WaitOpenEternalNight ? 1 : 0);
	}

	private void OpenEternalNight()
	{
		Singleton<GvG3FlagShipMissionsManager>.Instance.TryPlayEternalNightUiTransitions(inform: true);
	}
}
