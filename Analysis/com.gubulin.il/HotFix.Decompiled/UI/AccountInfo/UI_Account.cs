using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_Account : GButton
{
	public Controller button;

	public GImage n3;

	public GRichTextField title;

	public const string URL = "ui://b9yxt7u0f4szr";

	public static string Name = "UI_Account";

	public static string GetURL()
	{
		return "ui://b9yxt7u0f4szr";
	}

	public static UI_Account CreateInstance()
	{
		return (UI_Account)(object)UIPackage.CreateObject("AccountInfo", "Account");
	}

	public static UI_Account CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Account).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0f4szr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://b9yxt7u0f4szr".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
