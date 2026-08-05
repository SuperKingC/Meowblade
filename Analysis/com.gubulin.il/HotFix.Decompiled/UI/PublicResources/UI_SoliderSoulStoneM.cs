using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_SoliderSoulStoneM : GComponent
{
	public Controller SoulStoneIllume;

	public const string URL = "ui://kt6rg65obunltbc";

	public static string Name = "UI_SoliderSoulStoneM";

	public static string GetURL()
	{
		return "ui://kt6rg65obunltbc";
	}

	public static UI_SoliderSoulStoneM CreateInstance()
	{
		return (UI_SoliderSoulStoneM)(object)UIPackage.CreateObject("PublicResources", "SoliderSoulStoneM");
	}

	public static UI_SoliderSoulStoneM CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoliderSoulStoneM).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65obunltbc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		SoulStoneIllume = ((GComponent)this).GetController("SoulStoneIllume");
	}
}
