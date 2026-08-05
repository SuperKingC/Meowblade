using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_BonusItem : GComponent
{
	public Controller ShowNum;

	public GGraph Back;

	public GGraph fxBack;

	public GLoader rewardIcon;

	public GTextField num;

	public const string URL = "ui://0i520nzmtajuo8y";

	public static string Name = "UI_BonusItem";

	public static string GetURL()
	{
		return "ui://0i520nzmtajuo8y";
	}

	public static UI_BonusItem CreateInstance()
	{
		return (UI_BonusItem)(object)UIPackage.CreateObject("LordOfDreams", "BonusItem");
	}

	public static UI_BonusItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BonusItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmtajuo8y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		ShowNum = ((GComponent)this).GetController("ShowNum");
		Back = (GGraph)((GComponent)this).GetChild("Back");
		fxBack = (GGraph)((GComponent)this).GetChild("fxBack");
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://0i520nzmtajuo8y".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
	}
}
