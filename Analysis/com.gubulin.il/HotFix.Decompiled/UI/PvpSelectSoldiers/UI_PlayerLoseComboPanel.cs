using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PlayerLoseComboPanel : GComponent
{
	public Controller Status;

	public GImage n2;

	public GList list;

	public UI_btn_PlayerLoseInFinalResult StatusComboBtn;

	public GImage n4;

	public const string URL = "ui://82mo10n5hmsjjdtf";

	public static string Name = "UI_PlayerLoseComboPanel";

	public static string GetURL()
	{
		return "ui://82mo10n5hmsjjdtf";
	}

	public static UI_PlayerLoseComboPanel CreateInstance()
	{
		return (UI_PlayerLoseComboPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PlayerLoseComboPanel");
	}

	public static UI_PlayerLoseComboPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PlayerLoseComboPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5hmsjjdtf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		list = (GList)((GComponent)this).GetChild("list");
		StatusComboBtn = (UI_btn_PlayerLoseInFinalResult)(object)((GComponent)this).GetChild("StatusComboBtn");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
