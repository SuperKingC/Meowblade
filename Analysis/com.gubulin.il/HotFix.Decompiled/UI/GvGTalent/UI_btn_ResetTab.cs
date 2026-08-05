using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_btn_ResetTab : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n3;

	public GImage n8;

	public GTextField n4;

	public GTextField n5;

	public GGroup n9;

	public GTextField n10;

	public GTextField n11;

	public GGroup n14;

	public const string URL = "ui://4r1llhd8pugq5n";

	public static string Name = "UI_btn_ResetTab";

	public static string GetURL()
	{
		return "ui://4r1llhd8pugq5n";
	}

	public static UI_btn_ResetTab CreateInstance()
	{
		return (UI_btn_ResetTab)(object)UIPackage.CreateObject("GvGTalent", "btn_ResetTab");
	}

	public static UI_btn_ResetTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ResetTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8pugq5n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://4r1llhd8pugq5n".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id2 = "ui://4r1llhd8pugq5n".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id2);
		n9 = (GGroup)((GComponent)this).GetChild("n9");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id3 = "ui://4r1llhd8pugq5n".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id3);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id4 = "ui://4r1llhd8pugq5n".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id4);
		n14 = (GGroup)((GComponent)this).GetChild("n14");
	}
}
