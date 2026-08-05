using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_GetRankBtn : GButton
{
	public Controller button;

	public UI_RetreatBtn ConfirmBtn;

	public GGraph n6;

	public GTextInput level;

	public GTextField n8;

	public GTextInput size;

	public GTextField n10;

	public const string URL = "ui://82mo10n5mwy46g";

	public static string Name = "UI_GetRankBtn";

	public static string GetURL()
	{
		return "ui://82mo10n5mwy46g";
	}

	public static UI_GetRankBtn CreateInstance()
	{
		return (UI_GetRankBtn)(object)UIPackage.CreateObject("PvpSelectSoldiers", "GetRankBtn");
	}

	public static UI_GetRankBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GetRankBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5mwy46g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		ConfirmBtn = (UI_RetreatBtn)(object)((GComponent)this).GetChild("ConfirmBtn");
		n6 = (GGraph)((GComponent)this).GetChild("n6");
		level = (GTextInput)((GComponent)this).GetChild("level");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		size = (GTextInput)((GComponent)this).GetChild("size");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id = "ui://82mo10n5mwy46g".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id);
	}
}
