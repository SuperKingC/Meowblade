using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UseItemResult;

public class UI_com_BonusItem : GComponent
{
	public Controller ShowSrcTalent;

	public GLoader icon;

	public GTextField num;

	public GTextField title;

	public GList TalentSrcList;

	public Transition ShowTalentSrcEffect;

	public const string URL = "ui://800w3r8rez1c7";

	public static string Name = "UI_com_BonusItem";

	public static string GetURL()
	{
		return "ui://800w3r8rez1c7";
	}

	public static UI_com_BonusItem CreateInstance()
	{
		return (UI_com_BonusItem)(object)UIPackage.CreateObject("UseItemResult", "com_BonusItem");
	}

	public static UI_com_BonusItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BonusItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rez1c7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ShowSrcTalent = ((GComponent)this).GetController("ShowSrcTalent");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://800w3r8rez1c7".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		title = (GTextField)((GComponent)this).GetChild("title");
		string id2 = "ui://800w3r8rez1c7".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id2);
		TalentSrcList = (GList)((GComponent)this).GetChild("TalentSrcList");
		ShowTalentSrcEffect = ((GComponent)this).GetTransition("ShowTalentSrcEffect");
	}
}
