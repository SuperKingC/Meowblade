using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_rewardWeekTreasureChest : GComponent
{
	public GLoader n72;

	public GLoader n73;

	public GLoader n75;

	public GLoader n76;

	public GLoader n77;

	public GLoader n78;

	public GLoader n79;

	public GLoader n80;

	public const string URL = "ui://29q48tv66vua5f83";

	public static string Name = "UI_com_rewardWeekTreasureChest";

	public static string GetURL()
	{
		return "ui://29q48tv66vua5f83";
	}

	public static UI_com_rewardWeekTreasureChest CreateInstance()
	{
		return (UI_com_rewardWeekTreasureChest)(object)UIPackage.CreateObject("GameActivity", "com_rewardWeekTreasureChest");
	}

	public static UI_com_rewardWeekTreasureChest CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_rewardWeekTreasureChest).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv66vua5f83", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n72 = (GLoader)((GComponent)this).GetChild("n72");
		n73 = (GLoader)((GComponent)this).GetChild("n73");
		n75 = (GLoader)((GComponent)this).GetChild("n75");
		n76 = (GLoader)((GComponent)this).GetChild("n76");
		n77 = (GLoader)((GComponent)this).GetChild("n77");
		n78 = (GLoader)((GComponent)this).GetChild("n78");
		n79 = (GLoader)((GComponent)this).GetChild("n79");
		n80 = (GLoader)((GComponent)this).GetChild("n80");
	}
}
