using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_com_Amplifier : GComponent
{
	public GComponent AmplifierIcon;

	public GComponent AffectedRange;

	public GTextField Count;

	public const string URL = "ui://p4ocf6q09ewll";

	public static string Name = "UI_com_Amplifier";

	public static string GetURL()
	{
		return "ui://p4ocf6q09ewll";
	}

	public static UI_com_Amplifier CreateInstance()
	{
		return (UI_com_Amplifier)(object)UIPackage.CreateObject("GvGRandomEvent3", "com_Amplifier");
	}

	public static UI_com_Amplifier CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Amplifier).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q09ewll", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		AmplifierIcon = (GComponent)((GComponent)this).GetChild("AmplifierIcon");
		AffectedRange = (GComponent)((GComponent)this).GetChild("AffectedRange");
		Count = (GTextField)((GComponent)this).GetChild("Count");
	}
}
