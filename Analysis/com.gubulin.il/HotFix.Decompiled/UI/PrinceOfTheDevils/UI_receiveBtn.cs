using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_receiveBtn : GButton
{
	public Controller button;

	public GImage n6;

	public GTextField title;

	public const string URL = "ui://zko5n3velkzgh";

	public static string Name = "UI_receiveBtn";

	public static string GetURL()
	{
		return "ui://zko5n3velkzgh";
	}

	public static UI_receiveBtn CreateInstance()
	{
		return (UI_receiveBtn)(object)UIPackage.CreateObject("PrinceOfTheDevils", "receiveBtn");
	}

	public static UI_receiveBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_receiveBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3velkzgh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://zko5n3velkzgh".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
