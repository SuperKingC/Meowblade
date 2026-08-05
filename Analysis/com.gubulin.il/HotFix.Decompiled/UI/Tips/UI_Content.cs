using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_Content : GComponent
{
	public GLoader icon;

	public UI_MaterialIntroductionRight RightContent;

	public GGraph SfxBack;

	public GTextField stockNum;

	public const string URL = "ui://47lbpgx9h7os24";

	public static string Name = "UI_Content";

	public static string GetURL()
	{
		return "ui://47lbpgx9h7os24";
	}

	public static UI_Content CreateInstance()
	{
		return (UI_Content)(object)UIPackage.CreateObject("Tips", "Content");
	}

	public static UI_Content CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Content).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9h7os24", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		RightContent = (UI_MaterialIntroductionRight)(object)((GComponent)this).GetChild("RightContent");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		stockNum = (GTextField)((GComponent)this).GetChild("stockNum");
	}
}
