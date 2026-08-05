using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_rotateLightBtn : GButton
{
	public Controller button;

	public GImage n7;

	public GImage n8;

	public GImage n9;

	public GImage n10;

	public const string URL = "ui://kt6rg65oqtmo40";

	public static string Name = "UI_rotateLightBtn";

	public static string GetURL()
	{
		return "ui://kt6rg65oqtmo40";
	}

	public static UI_rotateLightBtn CreateInstance()
	{
		return (UI_rotateLightBtn)(object)UIPackage.CreateObject("PublicResources", "rotateLightBtn");
	}

	public static UI_rotateLightBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_rotateLightBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oqtmo40", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
