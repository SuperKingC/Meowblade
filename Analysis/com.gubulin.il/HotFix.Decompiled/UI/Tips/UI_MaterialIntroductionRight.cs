using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_MaterialIntroductionRight : GComponent
{
	public Controller PageController;

	public GTextField title;

	public GTextField introduction;

	public GGraph line;

	public GTextField Property;

	public GTextField Access;

	public const string URL = "ui://47lbpgx9mol01u";

	public static string Name = "UI_MaterialIntroductionRight";

	public static string GetURL()
	{
		return "ui://47lbpgx9mol01u";
	}

	public static UI_MaterialIntroductionRight CreateInstance()
	{
		return (UI_MaterialIntroductionRight)(object)UIPackage.CreateObject("Tips", "MaterialIntroductionRight");
	}

	public static UI_MaterialIntroductionRight CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MaterialIntroductionRight).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9mol01u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		title = (GTextField)((GComponent)this).GetChild("title");
		introduction = (GTextField)((GComponent)this).GetChild("introduction");
		line = (GGraph)((GComponent)this).GetChild("line");
		Property = (GTextField)((GComponent)this).GetChild("Property");
		Access = (GTextField)((GComponent)this).GetChild("Access");
	}
}
