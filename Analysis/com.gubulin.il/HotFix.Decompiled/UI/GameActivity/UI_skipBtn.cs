using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_skipBtn : GButton
{
	public Controller button;

	public GGraph n6;

	public GImage bg;

	public GTextField n7;

	public GImage n5;

	public const string URL = "ui://29q48tv6janlf6f";

	public static string Name = "UI_skipBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6janlf6f";
	}

	public static UI_skipBtn CreateInstance()
	{
		return (UI_skipBtn)(object)UIPackage.CreateObject("GameActivity", "skipBtn");
	}

	public static UI_skipBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_skipBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6janlf6f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n6 = (GGraph)((GComponent)this).GetChild("n6");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://29q48tv6janlf6f".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
