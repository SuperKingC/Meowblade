using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_IslandPlayers : GButton
{
	public Controller button;

	public GImage n4;

	public GImage n5;

	public const string URL = "ui://4eq8fgd2h4tpe2";

	public static string Name = "UI_btn_IslandPlayers";

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpe2";
	}

	public static UI_btn_IslandPlayers CreateInstance()
	{
		return (UI_btn_IslandPlayers)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_IslandPlayers");
	}

	public static UI_btn_IslandPlayers CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_IslandPlayers).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpe2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
