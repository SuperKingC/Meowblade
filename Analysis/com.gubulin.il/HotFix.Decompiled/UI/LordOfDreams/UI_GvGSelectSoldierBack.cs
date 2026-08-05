using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_GvGSelectSoldierBack : GComponent
{
	public GImage Back;

	public const string URL = "ui://0i520nzmb529o7x";

	public static string Name = "UI_GvGSelectSoldierBack";

	public static string GetURL()
	{
		return "ui://0i520nzmb529o7x";
	}

	public static UI_GvGSelectSoldierBack CreateInstance()
	{
		return (UI_GvGSelectSoldierBack)(object)UIPackage.CreateObject("LordOfDreams", "GvGSelectSoldierBack");
	}

	public static UI_GvGSelectSoldierBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGSelectSoldierBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmb529o7x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Back = (GImage)((GComponent)this).GetChild("Back");
	}
}
