using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_scoreBar : GButton
{
	public Controller button;

	public Controller Type;

	public GImage Back0;

	public GImage Back1;

	public const string URL = "ui://f4wr270rx83v6d";

	public static string Name = "UI_scoreBar";

	public static string GetURL()
	{
		return "ui://f4wr270rx83v6d";
	}

	public static UI_scoreBar CreateInstance()
	{
		return (UI_scoreBar)(object)UIPackage.CreateObject("InstanceZones", "scoreBar");
	}

	public static UI_scoreBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_scoreBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rx83v6d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		Back0 = (GImage)((GComponent)this).GetChild("Back0");
		Back1 = (GImage)((GComponent)this).GetChild("Back1");
	}
}
