using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_RightBottomContent : GComponent
{
	public GList targetList;

	public const string URL = "ui://zko5n3velkzgf";

	public static string Name = "UI_RightBottomContent";

	public static string GetURL()
	{
		return "ui://zko5n3velkzgf";
	}

	public static UI_RightBottomContent CreateInstance()
	{
		return (UI_RightBottomContent)(object)UIPackage.CreateObject("PrinceOfTheDevils", "RightBottomContent");
	}

	public static UI_RightBottomContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RightBottomContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3velkzgf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		targetList = (GList)((GComponent)this).GetChild("targetList");
	}
}
