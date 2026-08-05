using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_SignInDayLoader : GButton
{
	public Controller button;

	public Controller pageController;

	public GGraph n4;

	public UI_SignInDayBtn mainBtn;

	public const string URL = "ui://29q48tv6gawyw";

	public static string Name = "UI_SignInDayLoader";

	public static string GetURL()
	{
		return "ui://29q48tv6gawyw";
	}

	public static UI_SignInDayLoader CreateInstance()
	{
		return (UI_SignInDayLoader)(object)UIPackage.CreateObject("GameActivity", "SignInDayLoader");
	}

	public static UI_SignInDayLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SignInDayLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6gawyw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		pageController = ((GComponent)this).GetController("pageController");
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		mainBtn = (UI_SignInDayBtn)(object)((GComponent)this).GetChild("mainBtn");
	}
}
