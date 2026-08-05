using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_Com_NeutralLevelCardPanel : GComponent
{
	public GGraph Mask;

	public UI_Com_NeutralLevelCard Dialog;

	public const string URL = "ui://f4wr270rgq2l82";

	public static string Name = "UI_Com_NeutralLevelCardPanel";

	public static string GetURL()
	{
		return "ui://f4wr270rgq2l82";
	}

	public static UI_Com_NeutralLevelCardPanel CreateInstance()
	{
		return (UI_Com_NeutralLevelCardPanel)(object)UIPackage.CreateObject("InstanceZones", "Com_NeutralLevelCardPanel");
	}

	public static UI_Com_NeutralLevelCardPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Com_NeutralLevelCardPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rgq2l82", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_Com_NeutralLevelCard)(object)((GComponent)this).GetChild("Dialog");
	}
}
