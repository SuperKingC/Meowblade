using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_SpecialTalentsType8 : GComponent
{
	public Controller OuterTechIsActive;

	public GImage n7;

	public GImage n8;

	public GImage n9;

	public GTextField Tip;

	public GTextField n11;

	public GList Specials;

	public GImage OuterTechMark;

	public Transition Appear;

	public const string URL = "ui://4r1llhd8qiao12";

	public static string Name = "UI_com_SpecialTalentsType8";

	public static string GetURL()
	{
		return "ui://4r1llhd8qiao12";
	}

	public static UI_com_SpecialTalentsType8 CreateInstance()
	{
		return (UI_com_SpecialTalentsType8)(object)UIPackage.CreateObject("GvGTalent", "com_SpecialTalentsType8");
	}

	public static UI_com_SpecialTalentsType8 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SpecialTalentsType8).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8qiao12", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		OuterTechIsActive = ((GComponent)this).GetController("OuterTechIsActive");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://4r1llhd8qiao12".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
		Specials = (GList)((GComponent)this).GetChild("Specials");
		OuterTechMark = (GImage)((GComponent)this).GetChild("OuterTechMark");
		Appear = ((GComponent)this).GetTransition("Appear");
	}
}
