using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_DamageBonusItem : GComponent
{
	public GLoader Back;

	public GGraph fxBack;

	public GLoader rewardIcon;

	public GTextField num;

	public const string URL = "ui://0i520nzmnfonobo";

	public static string Name = "UI_DamageBonusItem";

	public static string GetURL()
	{
		return "ui://0i520nzmnfonobo";
	}

	public static UI_DamageBonusItem CreateInstance()
	{
		return (UI_DamageBonusItem)(object)UIPackage.CreateObject("LordOfDreams", "DamageBonusItem");
	}

	public static UI_DamageBonusItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DamageBonusItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmnfonobo", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Back = (GLoader)((GComponent)this).GetChild("Back");
		fxBack = (GGraph)((GComponent)this).GetChild("fxBack");
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://0i520nzmnfonobo".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
	}
}
