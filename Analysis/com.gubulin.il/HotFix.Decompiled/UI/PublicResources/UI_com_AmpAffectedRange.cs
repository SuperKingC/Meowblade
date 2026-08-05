using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_AmpAffectedRange : GComponent
{
	public Controller IsShowRace;

	public UI_com_RaceType RaceType;

	public UI_com_SimpleSquareSoldier AffectedSoldier;

	public const string URL = "ui://kt6rg65olakgv4cb";

	public static string Name = "UI_com_AmpAffectedRange";

	public static string GetURL()
	{
		return "ui://kt6rg65olakgv4cb";
	}

	public static UI_com_AmpAffectedRange CreateInstance()
	{
		return (UI_com_AmpAffectedRange)(object)UIPackage.CreateObject("PublicResources", "com_AmpAffectedRange");
	}

	public static UI_com_AmpAffectedRange CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AmpAffectedRange).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65olakgv4cb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		IsShowRace = ((GComponent)this).GetController("IsShowRace");
		RaceType = (UI_com_RaceType)(object)((GComponent)this).GetChild("RaceType");
		AffectedSoldier = (UI_com_SimpleSquareSoldier)(object)((GComponent)this).GetChild("AffectedSoldier");
	}
}
