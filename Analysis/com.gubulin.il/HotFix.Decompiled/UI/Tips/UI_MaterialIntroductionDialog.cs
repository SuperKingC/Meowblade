using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_MaterialIntroductionDialog : GComponent
{
	public GImage WindowBack;

	public GGraph interceptBack;

	public GImage windowBack;

	public GGraph introductionBack;

	public GLoader frame;

	public GLoader icon;

	public GTextField title;

	public GTextField introduction;

	public UI_RepairBtn checkBtn;

	public GTextField property0;

	public GTextField propertyText0;

	public GGroup Property0;

	public GTextField property1;

	public GTextField propertyText1;

	public GGroup Property1;

	public GTextField property2;

	public GTextField propertyText2;

	public GGroup Property2;

	public GGroup propertysGroup;

	public GImage n41;

	public GImage n42;

	public const string URL = "ui://47lbpgx9gp9d1d";

	public static string Name = "UI_MaterialIntroductionDialog";

	public static string GetURL()
	{
		return "ui://47lbpgx9gp9d1d";
	}

	public static UI_MaterialIntroductionDialog CreateInstance()
	{
		return (UI_MaterialIntroductionDialog)(object)UIPackage.CreateObject("Tips", "MaterialIntroductionDialog");
	}

	public static UI_MaterialIntroductionDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MaterialIntroductionDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9gp9d1d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Expected O, but got Unknown
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected O, but got Unknown
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		WindowBack = (GImage)((GComponent)this).GetChild("WindowBack");
		interceptBack = (GGraph)((GComponent)this).GetChild("interceptBack");
		windowBack = (GImage)((GComponent)this).GetChild("windowBack");
		introductionBack = (GGraph)((GComponent)this).GetChild("introductionBack");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://47lbpgx9gp9d1d".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		introduction = (GTextField)((GComponent)this).GetChild("introduction");
		string id2 = "ui://47lbpgx9gp9d1d".Replace("ui://", "") + "-" + ((GObject)introduction).id;
		((GObject)introduction).text = LanguagesManager.GetDesc(id2);
		checkBtn = (UI_RepairBtn)(object)((GComponent)this).GetChild("checkBtn");
		property0 = (GTextField)((GComponent)this).GetChild("property0");
		propertyText0 = (GTextField)((GComponent)this).GetChild("propertyText0");
		string id3 = "ui://47lbpgx9gp9d1d".Replace("ui://", "") + "-" + ((GObject)propertyText0).id;
		((GObject)propertyText0).text = LanguagesManager.GetDesc(id3);
		Property0 = (GGroup)((GComponent)this).GetChild("Property0");
		property1 = (GTextField)((GComponent)this).GetChild("property1");
		propertyText1 = (GTextField)((GComponent)this).GetChild("propertyText1");
		string id4 = "ui://47lbpgx9gp9d1d".Replace("ui://", "") + "-" + ((GObject)propertyText1).id;
		((GObject)propertyText1).text = LanguagesManager.GetDesc(id4);
		Property1 = (GGroup)((GComponent)this).GetChild("Property1");
		property2 = (GTextField)((GComponent)this).GetChild("property2");
		propertyText2 = (GTextField)((GComponent)this).GetChild("propertyText2");
		string id5 = "ui://47lbpgx9gp9d1d".Replace("ui://", "") + "-" + ((GObject)propertyText2).id;
		((GObject)propertyText2).text = LanguagesManager.GetDesc(id5);
		Property2 = (GGroup)((GComponent)this).GetChild("Property2");
		propertysGroup = (GGroup)((GComponent)this).GetChild("propertysGroup");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		n42 = (GImage)((GComponent)this).GetChild("n42");
	}
}
