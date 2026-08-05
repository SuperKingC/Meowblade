using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_MsgBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GTextField n5;

	public const string URL = "ui://hd2s9kukfu2637";

	public static string Name = "UI_MsgBtn";

	public static string GetURL()
	{
		return "ui://hd2s9kukfu2637";
	}

	public static UI_MsgBtn CreateInstance()
	{
		return (UI_MsgBtn)(object)UIPackage.CreateObject("GvGWorldMap2", "MsgBtn");
	}

	public static UI_MsgBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MsgBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukfu2637", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://hd2s9kukfu2637".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}
