using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_RechargeTip : GComponent
{
	public Controller hasOuterTech2;

	public GImage n2;

	public GTextField n0;

	public const string URL = "ui://4r1llhd8ubyv5w";

	public static string Name = "UI_com_RechargeTip";

	public static string GetURL()
	{
		return "ui://4r1llhd8ubyv5w";
	}

	public static UI_com_RechargeTip CreateInstance()
	{
		return (UI_com_RechargeTip)(object)UIPackage.CreateObject("GvGTalent", "com_RechargeTip");
	}

	public static UI_com_RechargeTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RechargeTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8ubyv5w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		hasOuterTech2 = ((GComponent)this).GetController("hasOuterTech2");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n0 = (GTextField)((GComponent)this).GetChild("n0");
	}
}
