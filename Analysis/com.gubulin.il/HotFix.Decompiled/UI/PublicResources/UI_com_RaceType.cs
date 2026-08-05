using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_RaceType : GComponent
{
	public Controller Type;

	public Controller IsAll;

	public GLoader RaceIcon;

	public GImage All;

	public const string URL = "ui://kt6rg65ob4vad";

	public static string Name = "UI_com_RaceType";

	public static string GetURL()
	{
		return "ui://kt6rg65ob4vad";
	}

	public static UI_com_RaceType CreateInstance()
	{
		return (UI_com_RaceType)(object)UIPackage.CreateObject("PublicResources", "com_RaceType");
	}

	public static UI_com_RaceType CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RaceType).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ob4vad", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		IsAll = ((GComponent)this).GetController("IsAll");
		RaceIcon = (GLoader)((GComponent)this).GetChild("RaceIcon");
		All = (GImage)((GComponent)this).GetChild("All");
	}
}
