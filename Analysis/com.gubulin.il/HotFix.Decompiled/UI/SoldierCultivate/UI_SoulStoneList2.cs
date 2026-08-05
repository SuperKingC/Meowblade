using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoulStoneList2 : GComponent
{
	public Controller NumStatus;

	public GImage back;

	public GList soulStoneSelectList;

	public GImage tip;

	public UI_ConfirmForSoulStoneSelect ConfirmBtn;

	public const string URL = "ui://7dantnbiwqizt9o";

	public static string Name = "UI_SoulStoneList2";

	public void SetButtonTitle()
	{
		((GObject)ConfirmBtn.title).text = LanguagesManager.GetDesc("SoldierCultivate-SoulStoneList2-ConfirmBtn-title");
	}

	public static string GetURL()
	{
		return "ui://7dantnbiwqizt9o";
	}

	public static UI_SoulStoneList2 CreateInstance()
	{
		return (UI_SoulStoneList2)(object)UIPackage.CreateObject("SoldierCultivate", "SoulStoneList2");
	}

	public static UI_SoulStoneList2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoulStoneList2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbiwqizt9o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		NumStatus = ((GComponent)this).GetController("NumStatus");
		back = (GImage)((GComponent)this).GetChild("back");
		soulStoneSelectList = (GList)((GComponent)this).GetChild("soulStoneSelectList");
		tip = (GImage)((GComponent)this).GetChild("tip");
		ConfirmBtn = (UI_ConfirmForSoulStoneSelect)(object)((GComponent)this).GetChild("ConfirmBtn");
	}
}
