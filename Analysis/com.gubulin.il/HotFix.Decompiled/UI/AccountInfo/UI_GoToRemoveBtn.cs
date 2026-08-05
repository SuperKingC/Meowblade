using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_GoToRemoveBtn : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n2;

	public GImage n3;

	public GTextField countdown;

	public const string URL = "ui://b9yxt7u0p2md5b";

	public static string Name = "UI_GoToRemoveBtn";

	public static string GetURL()
	{
		return "ui://b9yxt7u0p2md5b";
	}

	public static UI_GoToRemoveBtn CreateInstance()
	{
		return (UI_GoToRemoveBtn)(object)UIPackage.CreateObject("AccountInfo", "GoToRemoveBtn");
	}

	public static UI_GoToRemoveBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GoToRemoveBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0p2md5b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		countdown = (GTextField)((GComponent)this).GetChild("countdown");
		string id = "ui://b9yxt7u0p2md5b".Replace("ui://", "") + "-" + ((GObject)countdown).id;
		((GObject)countdown).text = LanguagesManager.GetDesc(id);
	}
}
