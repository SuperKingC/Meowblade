using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_StoreItem_Blackbg : GComponent
{
	public Controller Type;

	public GImage n8;

	public GImage n9;

	public GImage n10;

	public GImage n11;

	public const string URL = "ui://fvc33k3ggyk31p";

	public static string Name = "UI_com_StoreItem_Blackbg";

	public static string GetURL()
	{
		return "ui://fvc33k3ggyk31p";
	}

	public static UI_com_StoreItem_Blackbg CreateInstance()
	{
		return (UI_com_StoreItem_Blackbg)(object)UIPackage.CreateObject("GVGStore", "com_StoreItem_Blackbg");
	}

	public static UI_com_StoreItem_Blackbg CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_StoreItem_Blackbg).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3ggyk31p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
	}
}
