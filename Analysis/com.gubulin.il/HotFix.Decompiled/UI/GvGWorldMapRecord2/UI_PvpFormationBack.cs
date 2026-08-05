using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMapRecord2;

public class UI_PvpFormationBack : GComponent
{
	public Controller Type;

	public GImage n12;

	public const string URL = "ui://5xc1njmujjrn2d";

	public static string Name = "UI_PvpFormationBack";

	public static string GetURL()
	{
		return "ui://5xc1njmujjrn2d";
	}

	public static UI_PvpFormationBack CreateInstance()
	{
		return (UI_PvpFormationBack)(object)UIPackage.CreateObject("GvGWorldMapRecord2", "PvpFormationBack");
	}

	public static UI_PvpFormationBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpFormationBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5xc1njmujjrn2d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
