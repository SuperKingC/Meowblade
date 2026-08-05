using FairyGUI;
using FairyGUI.Utils;

namespace UI.Guide;

public class UI_tips : GComponent
{
	public UI_skip2 skip;

	public GImage n25;

	public GRichTextField content;

	public GImage n27;

	public GGroup mainGroup;

	public Transition popup;

	public const string URL = "ui://5vxjvcrbg6t9u";

	public static string Name = "UI_tips";

	public static string GetURL()
	{
		return "ui://5vxjvcrbg6t9u";
	}

	public static UI_tips CreateInstance()
	{
		return (UI_tips)(object)UIPackage.CreateObject("Guide", "tips");
	}

	public static UI_tips CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_tips).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5vxjvcrbg6t9u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		skip = (UI_skip2)(object)((GComponent)this).GetChild("skip");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		content = (GRichTextField)((GComponent)this).GetChild("content");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		mainGroup = (GGroup)((GComponent)this).GetChild("mainGroup");
		popup = ((GComponent)this).GetTransition("popup");
	}
}
