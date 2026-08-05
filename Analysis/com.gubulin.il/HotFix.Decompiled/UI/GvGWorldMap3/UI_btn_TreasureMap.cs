using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using UI.GvGRandomEvent3;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_btn_TreasureMap : GButton, IFairyComponent
{
	public Controller button;

	public GImage n8;

	public GImage n9;

	public GImage n10;

	public GLoader Icon;

	public GMovieClip n11;

	public GTextField Countdown;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2dc6m8f";

	public static string Name = "UI_btn_TreasureMap";

	private Coroutine _updateCountdown;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	private TreasureMapInfo _info;

	private bool _needPopUp;

	private bool _initialized;

	private int CurrentTimestamp => (int)GameController.Instance.GetServerTime();

	public static string GetURL()
	{
		return "ui://4eq8fgd2dc6m8f";
	}

	public static UI_btn_TreasureMap CreateInstance()
	{
		return (UI_btn_TreasureMap)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_TreasureMap");
	}

	public static UI_btn_TreasureMap CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_TreasureMap).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2dc6m8f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n11 = (GMovieClip)((GComponent)this).GetChild("n11");
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void Destroy()
	{
		_info = null;
		if (_updateCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
		}
	}

	public void Init()
	{
		Render(Singleton<WorldStateManager>.Instance.Data.SelfTreasureMapInfo);
		_initialized = true;
	}

	public void RegisterUiEvent()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((GObject)this).onClick.Set(new EventCallback0(OnClick));
		WorldStateManager instance = Singleton<WorldStateManager>.Instance;
		instance.OnTreasureMapInfoChange = (Action<TreasureMapInfo>)Delegate.Combine(instance.OnTreasureMapInfoChange, new Action<TreasureMapInfo>(Render));
	}

	public void UnregisterUiEvent()
	{
		((GObject)this).onClick.Clear();
		WorldStateManager instance = Singleton<WorldStateManager>.Instance;
		instance.OnTreasureMapInfoChange = (Action<TreasureMapInfo>)Delegate.Remove(instance.OnTreasureMapInfoChange, new Action<TreasureMapInfo>(Render));
	}

	public void ChangeAlphaOnFilterVisibleChange(bool display)
	{
		((GObject)this).alpha = (display ? 1f : 0f);
		((GObject)this).enabled = display;
	}

	private void Render(TreasureMapInfo mapInfo)
	{
		if (mapInfo == null || mapInfo.TreasureMap_MUID < 0)
		{
			((GObject)this).visible = false;
			return;
		}
		_info = mapInfo;
		_needPopUp = _initialized && !((GObject)this).visible;
		PopUpTreasureMap();
		((GObject)this).visible = true;
		if (_updateCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
		}
		if (_info.TreasureMap_Timestamp_ms > 0)
		{
			_updateCountdown = FGUIManager.Instance.OpenIEnumerator(RefreshCountdown((int)(_info.TreasureMap_Timestamp_ms / 1000)));
		}
		IEnumerator RefreshCountdown(int timestamp)
		{
			while (!((GObject)this).isDisposed)
			{
				((GObject)Countdown).text = UiHelper.ParseTimeShort(timestamp - CurrentTimestamp);
				yield return _perSecond;
			}
		}
	}

	private void PopUpTreasureMap()
	{
		if (_needPopUp)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_TreasureMap.Name, new Dictionary<string, object> { { "TreasureMapInfo", _info } });
			_needPopUp = false;
		}
	}

	private void OnClick()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_TreasureMap.Name, new Dictionary<string, object> { { "TreasureMapInfo", _info } });
	}
}
