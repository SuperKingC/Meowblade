using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_ProfileDisplayChatLeft : GComponent
{
	public GList Medals;

	public UI_com_ShipAvatar Avatar;

	public GTextField PlayerName;

	public const string URL = "ui://kt6rg65oigs2v4nv";

	public static string Name = "UI_com_ProfileDisplayChatLeft";

	public static string GetURL()
	{
		return "ui://kt6rg65oigs2v4nv";
	}

	public static UI_com_ProfileDisplayChatLeft CreateInstance()
	{
		return (UI_com_ProfileDisplayChatLeft)(object)UIPackage.CreateObject("PublicResources", "com_ProfileDisplayChatLeft");
	}

	public static UI_com_ProfileDisplayChatLeft CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ProfileDisplayChatLeft).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oigs2v4nv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Medals = (GList)((GComponent)this).GetChild("Medals");
		Avatar = (UI_com_ShipAvatar)(object)((GComponent)this).GetChild("Avatar");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
	}
}
