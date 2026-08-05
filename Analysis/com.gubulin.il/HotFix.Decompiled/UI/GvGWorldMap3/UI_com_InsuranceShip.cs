using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_InsuranceShip : GComponent
{
	public Controller Type;

	public GImage Background;

	public GImage n12;

	public GImage n3;

	public GImage n4;

	public GTextField n1;

	public GImage n2;

	public GTextField n6;

	public GTextField n11;

	public GButton Confirm;

	public UI_com_SelectedShip SetInsurance;

	public UI_MyTroopsSketchMap Legions;

	public const string URL = "ui://4eq8fgd2eo52b6sdi";

	public static string Name = "UI_com_InsuranceShip";

	public static string GetURL()
	{
		return "ui://4eq8fgd2eo52b6sdi";
	}

	public static UI_com_InsuranceShip CreateInstance()
	{
		return (UI_com_InsuranceShip)(object)UIPackage.CreateObject("GvGWorldMap3", "com_InsuranceShip");
	}

	public static UI_com_InsuranceShip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_InsuranceShip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2eo52b6sdi", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Background = (GImage)((GComponent)this).GetChild("Background");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://4eq8fgd2eo52b6sdi".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id2 = "ui://4eq8fgd2eo52b6sdi".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id2);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id3 = "ui://4eq8fgd2eo52b6sdi".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id3);
		Confirm = (GButton)((GComponent)this).GetChild("Confirm");
		SetInsurance = (UI_com_SelectedShip)(object)((GComponent)this).GetChild("SetInsurance");
		Legions = (UI_MyTroopsSketchMap)(object)((GComponent)this).GetChild("Legions");
	}
}
