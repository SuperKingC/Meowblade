using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_btn_ConfirmClaimAll : GButton
{
	public GImage n17;

	public GImage n18;

	public const string URL = "ui://b3fc6085dzdc3e";

	public static string Name = "UI_btn_ConfirmClaimAll";

	public static string GetURL()
	{
		return "ui://b3fc6085dzdc3e";
	}

	public static UI_btn_ConfirmClaimAll CreateInstance()
	{
		return (UI_btn_ConfirmClaimAll)(object)UIPackage.CreateObject("GvGBattleRecord3", "btn_ConfirmClaimAll");
	}

	public static UI_btn_ConfirmClaimAll CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ConfirmClaimAll).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085dzdc3e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
	}
}
