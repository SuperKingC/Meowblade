using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_btn_BetSelect : GButton
{
	public Controller Status;

	public GImage n42;

	public GImage n44;

	public GImage n45;

	public GTextField title;

	public GImage n47;

	public const string URL = "ui://82mo10n5rnlpjdtr";

	public static string Name = "UI_btn_BetSelect";

	public static string GetURL()
	{
		return "ui://82mo10n5rnlpjdtr";
	}

	public static UI_btn_BetSelect CreateInstance()
	{
		return (UI_btn_BetSelect)(object)UIPackage.CreateObject("PvpSelectSoldiers", "btn_BetSelect");
	}

	public static UI_btn_BetSelect CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BetSelect).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5rnlpjdtr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		title = (GTextField)((GComponent)this).GetChild("title");
		n47 = (GImage)((GComponent)this).GetChild("n47");
	}
}
