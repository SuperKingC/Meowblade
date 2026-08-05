using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_com_Instruction : GComponent
{
	public GImage n5;

	public GTextField n0;

	public GImage n1;

	public GTextField n2;

	public GImage n3;

	public GTextField n4;

	public GTextField n8;

	public const string URL = "ui://rx5ntv98win2g";

	public static string Name = "UI_com_Instruction";

	public static string GetURL()
	{
		return "ui://rx5ntv98win2g";
	}

	public static UI_com_Instruction CreateInstance()
	{
		return (UI_com_Instruction)(object)UIPackage.CreateObject("ReturningRewards", "com_Instruction");
	}

	public static UI_com_Instruction CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Instruction).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98win2g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id = "ui://rx5ntv98win2g".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id);
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id2 = "ui://rx5ntv98win2g".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id2);
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id3 = "ui://rx5ntv98win2g".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id3);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id4 = "ui://rx5ntv98win2g".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id4);
	}
}
