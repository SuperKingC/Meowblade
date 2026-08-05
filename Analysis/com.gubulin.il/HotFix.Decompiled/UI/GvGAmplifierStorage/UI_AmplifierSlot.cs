using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierStorage;

public class UI_AmplifierSlot : GComponent
{
	public GComponent AmplifierIcon;

	public GComponent AffectedRange;

	public GTextField Count;

	public const string URL = "ui://fwpu3639q8fuw";

	public static string Name = "UI_AmplifierSlot";

	public static string GetURL()
	{
		return "ui://fwpu3639q8fuw";
	}

	public static UI_AmplifierSlot CreateInstance()
	{
		return (UI_AmplifierSlot)(object)UIPackage.CreateObject("GvGAmplifierStorage", "AmplifierSlot");
	}

	public static UI_AmplifierSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AmplifierSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fwpu3639q8fuw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
