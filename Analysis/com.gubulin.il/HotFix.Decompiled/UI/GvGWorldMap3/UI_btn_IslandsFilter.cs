using System;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Manager;
using Shift.Legion.Common.Helpers;

namespace UI.GvGWorldMap3;

public class UI_btn_IslandsFilter : GButton
{
	public Controller button;

	public Controller State;

	public GImage n3;

	public GImage n4;

	public GImage n5;

	public const string URL = "ui://4eq8fgd2kivrsbv";

	public static string Name = "UI_btn_IslandsFilter";

	private EventCallback0 _clickCallback;

	public static string GetURL()
	{
		return "ui://4eq8fgd2kivrsbv";
	}

	public static UI_btn_IslandsFilter CreateInstance()
	{
		return (UI_btn_IslandsFilter)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_IslandsFilter");
	}

	public static UI_btn_IslandsFilter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_IslandsFilter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2kivrsbv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}

	public void RegisterEvents(EventCallback0 clickCallback)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		_clickCallback = clickCallback;
		((GObject)this).onClick.Set(new EventCallback0(OnClick));
		GvGIslandFilterManager instance = Singleton<GvGIslandFilterManager>.Instance;
		instance.OnIslandFilterChange = (Action)Delegate.Combine(instance.OnIslandFilterChange, new Action(Render));
	}

	public void UnregisterEvents()
	{
		((GObject)this).onClick.Clear();
		_clickCallback = null;
		GvGIslandFilterManager instance = Singleton<GvGIslandFilterManager>.Instance;
		instance.OnIslandFilterChange = (Action)Delegate.Remove(instance.OnIslandFilterChange, new Action(Render));
	}

	public void Render()
	{
		string curSelectedFilterId = Singleton<GvGIslandFilterManager>.Instance.CurSelectedFilterId;
		int selectedIndex = ((!string.IsNullOrEmpty(curSelectedFilterId)) ? 1 : 0);
		State.SetSelectedIndex(selectedIndex);
	}

	private void OnClick()
	{
		EventCallback0 clickCallback = _clickCallback;
		if (clickCallback != null)
		{
			clickCallback.Invoke();
		}
	}
}
