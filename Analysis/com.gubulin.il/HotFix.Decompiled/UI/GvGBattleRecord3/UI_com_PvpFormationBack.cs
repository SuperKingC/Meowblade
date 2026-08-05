using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_PvpFormationBack : GComponent
{
	public Controller Type;

	public GImage n12;

	public const string URL = "ui://b3fc6085stwvt";

	public static string Name = "UI_com_PvpFormationBack";

	public static string GetURL()
	{
		return "ui://b3fc6085stwvt";
	}

	public static UI_com_PvpFormationBack CreateInstance()
	{
		return (UI_com_PvpFormationBack)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_PvpFormationBack");
	}

	public static UI_com_PvpFormationBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PvpFormationBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwvt", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n12 = (GImage)((GComponent)this).GetChild("n12");
	}
}
