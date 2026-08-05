using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_noticeTip : GComponent
{
	public GRichTextField tip;

	public const string URL = "ui://yb3s7uv7bw1c2a";

	public static string Name = "UI_noticeTip";

	public static string GetURL()
	{
		return "ui://yb3s7uv7bw1c2a";
	}

	public static UI_noticeTip CreateInstance()
	{
		return (UI_noticeTip)(object)UIPackage.CreateObject("LoginAndName", "noticeTip");
	}

	public static UI_noticeTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_noticeTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7bw1c2a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		tip = (GRichTextField)((GComponent)this).GetChild("tip");
	}
}
