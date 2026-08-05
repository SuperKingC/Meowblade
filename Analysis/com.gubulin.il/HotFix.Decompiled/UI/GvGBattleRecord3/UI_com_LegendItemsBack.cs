using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_LegendItemsBack : GComponent
{
	public Controller Type;

	public GImage n0;

	public GImage n1;

	public const string URL = "ui://b3fc6085stwvx";

	public static string Name = "UI_com_LegendItemsBack";

	public static string GetURL()
	{
		return "ui://b3fc6085stwvx";
	}

	public static UI_com_LegendItemsBack CreateInstance()
	{
		return (UI_com_LegendItemsBack)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_LegendItemsBack");
	}

	public static UI_com_LegendItemsBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LegendItemsBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwvx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
	}
}
