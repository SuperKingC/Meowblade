using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_btn_speed : GButton
{
	public Controller button;

	public GGraph n120;

	public GImage n118;

	public GTextField playSpeedText;

	public const string URL = "ui://ebc4ciwrndngq6y";

	public static string Name = "UI_btn_speed";

	public static string GetURL()
	{
		return "ui://ebc4ciwrndngq6y";
	}

	public static UI_btn_speed CreateInstance()
	{
		return (UI_btn_speed)(object)UIPackage.CreateObject("GvGOnIsland3", "btn_speed");
	}

	public static UI_btn_speed CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_speed).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrndngq6y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n120 = (GGraph)((GComponent)this).GetChild("n120");
		n118 = (GImage)((GComponent)this).GetChild("n118");
		playSpeedText = (GTextField)((GComponent)this).GetChild("playSpeedText");
		string id = "ui://ebc4ciwrndngq6y".Replace("ui://", "") + "-" + ((GObject)playSpeedText).id;
		((GObject)playSpeedText).text = LanguagesManager.GetDesc(id);
	}
}
