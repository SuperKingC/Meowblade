using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_OuterTechDormantDialog : GComponent
{
	public GImage n0;

	public GImage n1;

	public GImage n4;

	public GTextField n3;

	public GButton Confirm;

	public GButton Cancel;

	public const string URL = "ui://4r1llhd8tp8c67";

	public static string Name = "UI_com_OuterTechDormantDialog";

	public static string GetURL()
	{
		return "ui://4r1llhd8tp8c67";
	}

	public static UI_com_OuterTechDormantDialog CreateInstance()
	{
		return (UI_com_OuterTechDormantDialog)(object)UIPackage.CreateObject("GvGTalent", "com_OuterTechDormantDialog");
	}

	public static UI_com_OuterTechDormantDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OuterTechDormantDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8tp8c67", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://4r1llhd8tp8c67".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		Confirm = (GButton)((GComponent)this).GetChild("Confirm");
		Cancel = (GButton)((GComponent)this).GetChild("Cancel");
	}
}
