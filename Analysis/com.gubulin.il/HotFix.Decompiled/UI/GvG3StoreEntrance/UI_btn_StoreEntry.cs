using System;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UI.GVGStore;

namespace UI.GvG3StoreEntrance;

public class UI_btn_StoreEntry : GButton, EntryBtn
{
	public GImage n120;

	public GImage n116;

	public UI_dec_Particleeffect n119;

	public GImage n117;

	public UI_dec_Particleeffect2 n124;

	public GImage Notice;

	public GImage n126;

	public const string URL = "ui://6ccguk4firuh0";

	public static string Name = "UI_btn_StoreEntry";

	public static string GetURL()
	{
		return "ui://6ccguk4firuh0";
	}

	public static UI_btn_StoreEntry CreateInstance()
	{
		return (UI_btn_StoreEntry)(object)UIPackage.CreateObject("GvG3StoreEntrance", "btn_StoreEntry");
	}

	public static UI_btn_StoreEntry CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_StoreEntry).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://6ccguk4firuh0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n120 = (GImage)((GComponent)this).GetChild("n120");
		n116 = (GImage)((GComponent)this).GetChild("n116");
		n119 = (UI_dec_Particleeffect)(object)((GComponent)this).GetChild("n119");
		n117 = (GImage)((GComponent)this).GetChild("n117");
		n124 = (UI_dec_Particleeffect2)(object)((GComponent)this).GetChild("n124");
		Notice = (GImage)((GComponent)this).GetChild("Notice");
		n126 = (GImage)((GComponent)this).GetChild("n126");
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
		((GObject)Notice).visible = Singleton<GvG3StoreManager>.Instance.HasGvGStoreNotice;
	}

	public void OnClick()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GVGStorePanel.Name, null);
	}
}
