using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_SoliderSoulStoneLevel : GComponent
{
	public Controller SoulStoneLevel;

	public UI_SoliderSoulStoneC LevelC;

	public UI_SoliderSoulStoneB LevelB;

	public UI_SoliderSoulStoneA LevelA;

	public UI_SoliderSoulStoneS LevelS;

	public UI_SoliderSoulStoneM LevelM;

	public const string URL = "ui://kt6rg65obunltb4";

	public static string Name = "UI_SoliderSoulStoneLevel";

	public static string GetURL()
	{
		return "ui://kt6rg65obunltb4";
	}

	public static UI_SoliderSoulStoneLevel CreateInstance()
	{
		return (UI_SoliderSoulStoneLevel)(object)UIPackage.CreateObject("PublicResources", "SoliderSoulStoneLevel");
	}

	public static UI_SoliderSoulStoneLevel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoliderSoulStoneLevel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65obunltb4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		SoulStoneLevel = ((GComponent)this).GetController("SoulStoneLevel");
		LevelC = (UI_SoliderSoulStoneC)(object)((GComponent)this).GetChild("LevelC");
		LevelB = (UI_SoliderSoulStoneB)(object)((GComponent)this).GetChild("LevelB");
		LevelA = (UI_SoliderSoulStoneA)(object)((GComponent)this).GetChild("LevelA");
		LevelS = (UI_SoliderSoulStoneS)(object)((GComponent)this).GetChild("LevelS");
		LevelM = (UI_SoliderSoulStoneM)(object)((GComponent)this).GetChild("LevelM");
	}
}
