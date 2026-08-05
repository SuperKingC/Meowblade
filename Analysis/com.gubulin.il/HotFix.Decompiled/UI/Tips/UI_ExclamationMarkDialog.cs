using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_ExclamationMarkDialog : GComponent
{
	public GImage back;

	public GRichTextField title;

	public GTextField content1;

	public GTextField content2;

	public const string URL = "ui://47lbpgx9fq9e37";

	public static string Name = "UI_ExclamationMarkDialog";

	public static string GetURL()
	{
		return "ui://47lbpgx9fq9e37";
	}

	public static UI_ExclamationMarkDialog CreateInstance()
	{
		return (UI_ExclamationMarkDialog)(object)UIPackage.CreateObject("Tips", "ExclamationMarkDialog");
	}

	public static UI_ExclamationMarkDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExclamationMarkDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9fq9e37", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		content1 = (GTextField)((GComponent)this).GetChild("content1");
		content2 = (GTextField)((GComponent)this).GetChild("content2");
	}
}
