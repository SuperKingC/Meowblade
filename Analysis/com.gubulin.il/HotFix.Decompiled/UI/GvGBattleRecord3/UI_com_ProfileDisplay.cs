using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_ProfileDisplay : GComponent
{
	public Controller IsMe;

	public GComponent ProfileDisplay;

	public UI_com_Component3 n0;

	public const string URL = "ui://b3fc6085igs2fi";

	public static string Name = "UI_com_ProfileDisplay";

	public static string GetURL()
	{
		return "ui://b3fc6085igs2fi";
	}

	public static UI_com_ProfileDisplay CreateInstance()
	{
		return (UI_com_ProfileDisplay)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_ProfileDisplay");
	}

	public static UI_com_ProfileDisplay CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ProfileDisplay).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085igs2fi", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsMe = ((GComponent)this).GetController("IsMe");
		ProfileDisplay = (GComponent)((GComponent)this).GetChild("ProfileDisplay");
		n0 = (UI_com_Component3)(object)((GComponent)this).GetChild("n0");
	}
}
