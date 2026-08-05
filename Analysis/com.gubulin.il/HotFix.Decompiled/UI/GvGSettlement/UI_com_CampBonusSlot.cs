using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_com_CampBonusSlot : GComponent
{
	public Controller IsClaimed;

	public GLoader Icon;

	public GImage n138;

	public GImage n139;

	public GTextField Num;

	public const string URL = "ui://91jxdrkanc8fs";

	public static string Name = "UI_com_CampBonusSlot";

	public static string GetURL()
	{
		return "ui://91jxdrkanc8fs";
	}

	public static UI_com_CampBonusSlot CreateInstance()
	{
		return (UI_com_CampBonusSlot)(object)UIPackage.CreateObject("GvGSettlement", "com_CampBonusSlot");
	}

	public static UI_com_CampBonusSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampBonusSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkanc8fs", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		IsClaimed = ((GComponent)this).GetController("IsClaimed");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		n139 = (GImage)((GComponent)this).GetChild("n139");
		Num = (GTextField)((GComponent)this).GetChild("Num");
	}
}
