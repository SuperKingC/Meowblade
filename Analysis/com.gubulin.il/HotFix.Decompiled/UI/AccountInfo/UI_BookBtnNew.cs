using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_BookBtnNew : GButton
{
	public Controller button;

	public GImage n2;

	public GTextField n3;

	public const string URL = "ui://b9yxt7u0ucm86v";

	public static string Name = "UI_BookBtnNew";

	public static string GetURL()
	{
		return "ui://b9yxt7u0ucm86v";
	}

	public static UI_BookBtnNew CreateInstance()
	{
		return (UI_BookBtnNew)(object)UIPackage.CreateObject("AccountInfo", "BookBtnNew");
	}

	public static UI_BookBtnNew CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BookBtnNew).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0ucm86v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://b9yxt7u0ucm86v".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
	}
}
