using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_BonusWrapper : GButton
{
	public Controller button;

	public Controller HasBonus;

	public Controller IsFinal;

	public Controller WidthType;

	public Controller IsExtra;

	public GImage back;

	public GList RItems;

	public GTextField n6;

	public GTextField n7;

	public GGroup n8;

	public UI_tbn_ExclamationMarkBtn Buff;

	public GImage n10;

	public GGroup n12;

	public const string URL = "ui://hozu168rk7me4w";

	public static string Name = "UI_btn_BonusWrapper";

	public static string GetURL()
	{
		return "ui://hozu168rk7me4w";
	}

	public static UI_btn_BonusWrapper CreateInstance()
	{
		return (UI_btn_BonusWrapper)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_BonusWrapper");
	}

	public static UI_btn_BonusWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BonusWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rk7me4w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		HasBonus = ((GComponent)this).GetController("HasBonus");
		IsFinal = ((GComponent)this).GetController("IsFinal");
		WidthType = ((GComponent)this).GetController("WidthType");
		IsExtra = ((GComponent)this).GetController("IsExtra");
		back = (GImage)((GComponent)this).GetChild("back");
		RItems = (GList)((GComponent)this).GetChild("RItems");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://hozu168rk7me4w".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id2 = "ui://hozu168rk7me4w".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id2);
		n8 = (GGroup)((GComponent)this).GetChild("n8");
		Buff = (UI_tbn_ExclamationMarkBtn)(object)((GComponent)this).GetChild("Buff");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n12 = (GGroup)((GComponent)this).GetChild("n12");
	}
}
