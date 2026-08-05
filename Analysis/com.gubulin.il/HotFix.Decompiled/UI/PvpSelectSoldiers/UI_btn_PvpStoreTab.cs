using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_btn_PvpStoreTab : GButton
{
	public Controller button;

	public GImage n0;

	public GImage n1;

	public GTextField Title;

	public GLoader icon;

	public GGroup n4;

	public const string URL = "ui://82mo10n5cccbjdq1";

	public static string Name = "UI_btn_PvpStoreTab";

	public static string GetURL()
	{
		return "ui://82mo10n5cccbjdq1";
	}

	public static UI_btn_PvpStoreTab CreateInstance()
	{
		return (UI_btn_PvpStoreTab)(object)UIPackage.CreateObject("PvpSelectSoldiers", "btn_PvpStoreTab");
	}

	public static UI_btn_PvpStoreTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_PvpStoreTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5cccbjdq1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://82mo10n5cccbjdq1".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n4 = (GGroup)((GComponent)this).GetChild("n4");
	}
}
