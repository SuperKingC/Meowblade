using System;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_TaitanActivated : GButton
{
	public Controller button;

	public GLoader n0;

	public GTextField n1;

	public GImage n3;

	public GImage n2;

	public const string URL = "ui://tt2iq07oj1h84m";

	public static string Name = "UI_btn_TaitanActivated";

	private Action<bool> _onSelectedChanged;

	public bool HasTitan => ((GButton)this).selected;

	public static string GetURL()
	{
		return "ui://tt2iq07oj1h84m";
	}

	public static UI_btn_TaitanActivated CreateInstance()
	{
		return (UI_btn_TaitanActivated)(object)UIPackage.CreateObject("GvGExchange3", "btn_TaitanActivated");
	}

	public static UI_btn_TaitanActivated CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_TaitanActivated).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oj1h84m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GLoader)((GComponent)this).GetChild("n0");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://tt2iq07oj1h84m".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n2 = (GImage)((GComponent)this).GetChild("n2");
	}

	public void Init(Action<bool> action)
	{
		_onSelectedChanged = action;
	}

	public void RegisterEvent()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((GButton)this).onChanged.Set(new EventCallback0(OnSelectedChanged));
	}

	public void UnregisterEvent()
	{
		((GButton)this).onChanged.Clear();
	}

	public void Destroy()
	{
		_onSelectedChanged = null;
	}

	private void OnSelectedChanged()
	{
		_onSelectedChanged?.Invoke(HasTitan);
	}
}
