using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_HelpDialog2 : GComponent
{
	public Controller Type;

	public GImage back;

	public GTextField n14;

	public GTextField n15;

	public GGroup n16;

	public GTextField n17;

	public GTextField n18;

	public GGroup n19;

	public UI_HelpDialogContent3 n20;

	public const string URL = "ui://avplaivdt47atof";

	public static string Name = "UI_HelpDialog2";

	public static string GetURL()
	{
		return "ui://avplaivdt47atof";
	}

	public static UI_HelpDialog2 CreateInstance()
	{
		return (UI_HelpDialog2)(object)UIPackage.CreateObject("Contract", "HelpDialog2");
	}

	public static UI_HelpDialog2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HelpDialog2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdt47atof", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		back = (GImage)((GComponent)this).GetChild("back");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id = "ui://avplaivdt47atof".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id);
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id2 = "ui://avplaivdt47atof".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id2);
		n16 = (GGroup)((GComponent)this).GetChild("n16");
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id3 = "ui://avplaivdt47atof".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id3);
		n18 = (GTextField)((GComponent)this).GetChild("n18");
		string id4 = "ui://avplaivdt47atof".Replace("ui://", "") + "-" + ((GObject)n18).id;
		((GObject)n18).text = LanguagesManager.GetDesc(id4);
		n19 = (GGroup)((GComponent)this).GetChild("n19");
		n20 = (UI_HelpDialogContent3)(object)((GComponent)this).GetChild("n20");
	}
}
