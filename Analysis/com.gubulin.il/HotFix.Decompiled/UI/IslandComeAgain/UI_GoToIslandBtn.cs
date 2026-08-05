using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_GoToIslandBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GTextField Text;

	public const string URL = "ui://k2sprg26in7b2s";

	public static string Name = "UI_GoToIslandBtn";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b2s";
	}

	public static UI_GoToIslandBtn CreateInstance()
	{
		return (UI_GoToIslandBtn)(object)UIPackage.CreateObject("IslandComeAgain", "GoToIslandBtn");
	}

	public static UI_GoToIslandBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GoToIslandBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b2s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Text = (GTextField)((GComponent)this).GetChild("Text");
		string id = "ui://k2sprg26in7b2s".Replace("ui://", "") + "-" + ((GObject)Text).id;
		((GObject)Text).text = LanguagesManager.GetDesc(id);
	}
}
