using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_GoToIsland : GComponent
{
	public UI_GoToIslandBtn Travel;

	public GTextField Time;

	public const string URL = "ui://k2sprg26in7b2r";

	public static string Name = "UI_GoToIsland";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b2r";
	}

	public static UI_GoToIsland CreateInstance()
	{
		return (UI_GoToIsland)(object)UIPackage.CreateObject("IslandComeAgain", "GoToIsland");
	}

	public static UI_GoToIsland CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GoToIsland).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b2r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Travel = (UI_GoToIslandBtn)(object)((GComponent)this).GetChild("Travel");
		Time = (GTextField)((GComponent)this).GetChild("Time");
	}
}
