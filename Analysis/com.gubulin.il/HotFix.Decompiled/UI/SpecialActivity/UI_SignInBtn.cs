using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_SignInBtn : GButton
{
	public Controller button;

	public GImage back;

	public GTextField title;

	public const string URL = "ui://kozswd8hndjak";

	public static string Name = "UI_SignInBtn";

	public static string GetURL()
	{
		return "ui://kozswd8hndjak";
	}

	public static UI_SignInBtn CreateInstance()
	{
		return (UI_SignInBtn)(object)UIPackage.CreateObject("SpecialActivity", "SignInBtn");
	}

	public static UI_SignInBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SignInBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hndjak", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://kozswd8hndjak".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
