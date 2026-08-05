using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_dec_TalentNoActive : GComponent
{
	public Controller OuterTechIsActive;

	public GImage n2;

	public GImage n1;

	public const string URL = "ui://4r1llhd8e8d45j";

	public static string Name = "UI_dec_TalentNoActive";

	public static string GetURL()
	{
		return "ui://4r1llhd8e8d45j";
	}

	public static UI_dec_TalentNoActive CreateInstance()
	{
		return (UI_dec_TalentNoActive)(object)UIPackage.CreateObject("GvGTalent", "dec_TalentNoActive");
	}

	public static UI_dec_TalentNoActive CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_TalentNoActive).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8e8d45j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		OuterTechIsActive = ((GComponent)this).GetController("OuterTechIsActive");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n1 = (GImage)((GComponent)this).GetChild("n1");
	}
}
