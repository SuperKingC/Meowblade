using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGIslandBuff;

public class UI_btn_IslandName : GButton
{
	public Controller button;

	public GTextField IslandName;

	public const string URL = "ui://zh7jgfijc7zhs5u";

	public static string Name = "UI_btn_IslandName";

	public static string GetURL()
	{
		return "ui://zh7jgfijc7zhs5u";
	}

	public static UI_btn_IslandName CreateInstance()
	{
		return (UI_btn_IslandName)(object)UIPackage.CreateObject("GvGIslandBuff", "btn_IslandName");
	}

	public static UI_btn_IslandName CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_IslandName).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijc7zhs5u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		IslandName = (GTextField)((GComponent)this).GetChild("IslandName");
	}
}
