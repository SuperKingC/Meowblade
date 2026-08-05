using System;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UI.StellarKeyStore;

namespace UI.GvG3StoreEntrance;

public class UI_btn_StellarKeyEntry : GButton, EntryBtn
{
	public GImage n118;

	public GImage n119;

	public UI_dec_Particleeffect n120;

	public GImage n117;

	public UI_dec_Particleeffect2 n121;

	public GImage RedDot;

	public GImage NewIcon;

	public const string URL = "ui://6ccguk4fewb9m";

	public static string Name = "UI_btn_StellarKeyEntry";

	public static string GetURL()
	{
		return "ui://6ccguk4fewb9m";
	}

	public static UI_btn_StellarKeyEntry CreateInstance()
	{
		return (UI_btn_StellarKeyEntry)(object)UIPackage.CreateObject("GvG3StoreEntrance", "btn_StellarKeyEntry");
	}

	public static UI_btn_StellarKeyEntry CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_StellarKeyEntry).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://6ccguk4fewb9m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n118 = (GImage)((GComponent)this).GetChild("n118");
		n119 = (GImage)((GComponent)this).GetChild("n119");
		n120 = (UI_dec_Particleeffect)(object)((GComponent)this).GetChild("n120");
		n117 = (GImage)((GComponent)this).GetChild("n117");
		n121 = (UI_dec_Particleeffect2)(object)((GComponent)this).GetChild("n121");
		RedDot = (GImage)((GComponent)this).GetChild("RedDot");
		NewIcon = (GImage)((GComponent)this).GetChild("NewIcon");
	}

	public void Init()
	{
		UpdateNotice();
		GvG3StoreManager instance = Singleton<GvG3StoreManager>.Instance;
		instance.OnChangeGvGStoreNotice = (Action)Delegate.Combine(instance.OnChangeGvGStoreNotice, new Action(UpdateNotice));
	}

	public void Destroy()
	{
		GvG3StoreManager instance = Singleton<GvG3StoreManager>.Instance;
		instance.OnChangeGvGStoreNotice = (Action)Delegate.Remove(instance.OnChangeGvGStoreNotice, new Action(UpdateNotice));
	}

	private void UpdateNotice()
	{
		((GObject)NewIcon).visible = Singleton<GvG3StoreManager>.Instance.HasStellarKeyStoreNotice;
	}

	public void OnClick()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_StellarKeyStorePanel.Name, null);
	}
}
