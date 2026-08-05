using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoulStoneForSelectBtn : GButton
{
	public Controller button;

	public Controller Status;

	public GButton iconBtn;

	public GImage n8;

	public GImage n6;

	public GTextField n7;

	public const string URL = "ui://7dantnbibunlt89";

	public static string Name = "UI_SoulStoneForSelectBtn";

	public static string GetURL()
	{
		return "ui://7dantnbibunlt89";
	}

	public static UI_SoulStoneForSelectBtn CreateInstance()
	{
		return (UI_SoulStoneForSelectBtn)(object)UIPackage.CreateObject("SoldierCultivate", "SoulStoneForSelectBtn");
	}

	public static UI_SoulStoneForSelectBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoulStoneForSelectBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbibunlt89", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		iconBtn = (GButton)((GComponent)this).GetChild("iconBtn");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://7dantnbibunlt89".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
	}
}
