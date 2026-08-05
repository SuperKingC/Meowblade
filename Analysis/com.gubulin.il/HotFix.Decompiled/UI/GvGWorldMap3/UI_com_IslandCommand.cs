using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_IslandCommand : GComponent
{
	public GImage n0;

	public UI_com_CommandMessage Message;

	public GComponent ProfileDisplay;

	public const string URL = "ui://4eq8fgd2jxsodq";

	public static string Name = "UI_com_IslandCommand";

	public static string GetURL()
	{
		return "ui://4eq8fgd2jxsodq";
	}

	public static UI_com_IslandCommand CreateInstance()
	{
		return (UI_com_IslandCommand)(object)UIPackage.CreateObject("GvGWorldMap3", "com_IslandCommand");
	}

	public static UI_com_IslandCommand CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandCommand).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2jxsodq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		Message = (UI_com_CommandMessage)(object)((GComponent)this).GetChild("Message");
		ProfileDisplay = (GComponent)((GComponent)this).GetChild("ProfileDisplay");
	}
}
