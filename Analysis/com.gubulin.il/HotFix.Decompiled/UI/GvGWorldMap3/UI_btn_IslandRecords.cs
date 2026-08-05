using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_IslandRecords : GButton
{
	public Controller button;

	public GImage n4;

	public GImage n5;

	public const string URL = "ui://4eq8fgd2h4tpe1";

	public static string Name = "UI_btn_IslandRecords";

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpe1";
	}

	public static UI_btn_IslandRecords CreateInstance()
	{
		return (UI_btn_IslandRecords)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_IslandRecords");
	}

	public static UI_btn_IslandRecords CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_IslandRecords).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpe1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
