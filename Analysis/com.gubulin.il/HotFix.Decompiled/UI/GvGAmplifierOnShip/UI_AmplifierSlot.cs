using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_AmplifierSlot : GButton
{
	public Controller IsNewSelected;

	public GImage n156;

	public GComponent AmplifierIcon;

	public GComponent AffectedRange;

	public GRichTextField Count;

	public const string URL = "ui://pwlamcyxgp16g";

	public static string Name = "UI_AmplifierSlot";

	public static string GetURL()
	{
		return "ui://pwlamcyxgp16g";
	}

	public static UI_AmplifierSlot CreateInstance()
	{
		return (UI_AmplifierSlot)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "AmplifierSlot");
	}

	public static UI_AmplifierSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AmplifierSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxgp16g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsNewSelected = ((GComponent)this).GetController("IsNewSelected");
		n156 = (GImage)((GComponent)this).GetChild("n156");
		AmplifierIcon = (GComponent)((GComponent)this).GetChild("AmplifierIcon");
		AffectedRange = (GComponent)((GComponent)this).GetChild("AffectedRange");
		Count = (GRichTextField)((GComponent)this).GetChild("Count");
	}
}
