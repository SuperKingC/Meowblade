using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_BetSelectTipDialog : GComponent
{
	public GImage n40;

	public GLoader Icon;

	public GList BetSelectList;

	public const string URL = "ui://82mo10n5rnlpjdtv";

	public static string Name = "UI_BetSelectTipDialog";

	public static string GetURL()
	{
		return "ui://82mo10n5rnlpjdtv";
	}

	public static UI_BetSelectTipDialog CreateInstance()
	{
		return (UI_BetSelectTipDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "BetSelectTipDialog");
	}

	public static UI_BetSelectTipDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BetSelectTipDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5rnlpjdtv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n40 = (GImage)((GComponent)this).GetChild("n40");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		BetSelectList = (GList)((GComponent)this).GetChild("BetSelectList");
	}
}
