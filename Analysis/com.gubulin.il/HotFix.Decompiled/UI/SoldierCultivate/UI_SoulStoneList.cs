using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoulStoneList : GComponent
{
	public Controller Status;

	public GImage back;

	public GList soulStoneSelectList;

	public GTextField title;

	public GGraph line;

	public GTextField title2nd;

	public GButton aimSoulStone;

	public GTextField soulStoneNum;

	public UI_compoundSoulStoneBtn CompoundBtn;

	public UI_ConfirmForSoulStoneSelect ConfirmBtn;

	public const string URL = "ui://7dantnbibunlt8b";

	public static string Name = "UI_SoulStoneList";

	public static string GetURL()
	{
		return "ui://7dantnbibunlt8b";
	}

	public static UI_SoulStoneList CreateInstance()
	{
		return (UI_SoulStoneList)(object)UIPackage.CreateObject("SoldierCultivate", "SoulStoneList");
	}

	public static UI_SoulStoneList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoulStoneList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbibunlt8b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		back = (GImage)((GComponent)this).GetChild("back");
		soulStoneSelectList = (GList)((GComponent)this).GetChild("soulStoneSelectList");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://7dantnbibunlt8b".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		line = (GGraph)((GComponent)this).GetChild("line");
		title2nd = (GTextField)((GComponent)this).GetChild("title2nd");
		string id2 = "ui://7dantnbibunlt8b".Replace("ui://", "") + "-" + ((GObject)title2nd).id;
		((GObject)title2nd).text = LanguagesManager.GetDesc(id2);
		aimSoulStone = (GButton)((GComponent)this).GetChild("aimSoulStone");
		soulStoneNum = (GTextField)((GComponent)this).GetChild("soulStoneNum");
		string id3 = "ui://7dantnbibunlt8b".Replace("ui://", "") + "-" + ((GObject)soulStoneNum).id;
		((GObject)soulStoneNum).text = LanguagesManager.GetDesc(id3);
		CompoundBtn = (UI_compoundSoulStoneBtn)(object)((GComponent)this).GetChild("CompoundBtn");
		ConfirmBtn = (UI_ConfirmForSoulStoneSelect)(object)((GComponent)this).GetChild("ConfirmBtn");
	}
}
