using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoulKeyStore;

public class UI_currencyBtn : GComponent
{
	public GImage n4;

	public GButton addButton;

	public GLoader icon;

	public GGraph textSFXBack;

	public GTextField num;

	public const string URL = "ui://3nd2hqkivzbkl";

	public static string Name = "UI_currencyBtn";

	public static string GetURL()
	{
		return "ui://3nd2hqkivzbkl";
	}

	public static UI_currencyBtn CreateInstance()
	{
		return (UI_currencyBtn)(object)UIPackage.CreateObject("SoulKeyStore", "currencyBtn");
	}

	public static UI_currencyBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_currencyBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkivzbkl", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		addButton = (GButton)((GComponent)this).GetChild("addButton");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		textSFXBack = (GGraph)((GComponent)this).GetChild("textSFXBack");
		num = (GTextField)((GComponent)this).GetChild("num");
	}
}
