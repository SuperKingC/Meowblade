using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_HelpDialogContent3 : GComponent
{
	public GTextField n21;

	public GTextField n23;

	public GTextField n27;

	public GTextField n28;

	public GTextField n29;

	public GTextField n30;

	public GGroup n31;

	public GTextField n32;

	public GTextField n33;

	public const string URL = "ui://avplaivdg30ltoj";

	public static string Name = "UI_HelpDialogContent3";

	public static string GetURL()
	{
		return "ui://avplaivdg30ltoj";
	}

	public static UI_HelpDialogContent3 CreateInstance()
	{
		return (UI_HelpDialogContent3)(object)UIPackage.CreateObject("Contract", "HelpDialogContent3");
	}

	public static UI_HelpDialogContent3 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HelpDialogContent3).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdg30ltoj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected O, but got Unknown
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Expected O, but got Unknown
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id = "ui://avplaivdg30ltoj".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id);
		n23 = (GTextField)((GComponent)this).GetChild("n23");
		string id2 = "ui://avplaivdg30ltoj".Replace("ui://", "") + "-" + ((GObject)n23).id;
		((GObject)n23).text = LanguagesManager.GetDesc(id2);
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		string id3 = "ui://avplaivdg30ltoj".Replace("ui://", "") + "-" + ((GObject)n27).id;
		((GObject)n27).text = LanguagesManager.GetDesc(id3);
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id4 = "ui://avplaivdg30ltoj".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id4);
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id5 = "ui://avplaivdg30ltoj".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id5);
		n30 = (GTextField)((GComponent)this).GetChild("n30");
		string id6 = "ui://avplaivdg30ltoj".Replace("ui://", "") + "-" + ((GObject)n30).id;
		((GObject)n30).text = LanguagesManager.GetDesc(id6);
		n31 = (GGroup)((GComponent)this).GetChild("n31");
		n32 = (GTextField)((GComponent)this).GetChild("n32");
		string id7 = "ui://avplaivdg30ltoj".Replace("ui://", "") + "-" + ((GObject)n32).id;
		((GObject)n32).text = LanguagesManager.GetDesc(id7);
		n33 = (GTextField)((GComponent)this).GetChild("n33");
		string id8 = "ui://avplaivdg30ltoj".Replace("ui://", "") + "-" + ((GObject)n33).id;
		((GObject)n33).text = LanguagesManager.GetDesc(id8);
	}
}
