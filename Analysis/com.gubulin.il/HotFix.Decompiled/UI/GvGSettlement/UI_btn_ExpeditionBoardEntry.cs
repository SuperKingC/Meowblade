using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_btn_ExpeditionBoardEntry : GButton
{
	public Controller button;

	public GImage n190;

	public GImage Notice;

	public const string URL = "ui://91jxdrkanc8f10";

	public static string Name = "UI_btn_ExpeditionBoardEntry";

	public static string GetURL()
	{
		return "ui://91jxdrkanc8f10";
	}

	public static UI_btn_ExpeditionBoardEntry CreateInstance()
	{
		return (UI_btn_ExpeditionBoardEntry)(object)UIPackage.CreateObject("GvGSettlement", "btn_ExpeditionBoardEntry");
	}

	public static UI_btn_ExpeditionBoardEntry CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ExpeditionBoardEntry).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkanc8f10", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n190 = (GImage)((GComponent)this).GetChild("n190");
		Notice = (GImage)((GComponent)this).GetChild("Notice");
	}
}
