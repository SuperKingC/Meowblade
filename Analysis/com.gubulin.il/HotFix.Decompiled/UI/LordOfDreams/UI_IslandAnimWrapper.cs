using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_IslandAnimWrapper : GComponent
{
	public UI_IslandScreenAdaptWrapper IslandScreenAdaptWrapper;

	public const string URL = "ui://0i520nzmzsih2b";

	public static string Name = "UI_IslandAnimWrapper";

	public static string GetURL()
	{
		return "ui://0i520nzmzsih2b";
	}

	public static UI_IslandAnimWrapper CreateInstance()
	{
		return (UI_IslandAnimWrapper)(object)UIPackage.CreateObject("LordOfDreams", "IslandAnimWrapper");
	}

	public static UI_IslandAnimWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IslandAnimWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmzsih2b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		IslandScreenAdaptWrapper = (UI_IslandScreenAdaptWrapper)(object)((GComponent)this).GetChild("IslandScreenAdaptWrapper");
	}
}
