using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_TreasureChest : GComponent
{
	public GImage n73;

	public GImage n74;

	public GImage n78;

	public GImage n81;

	public GImage n80;

	public GImage n75;

	public GImage n76;

	public GImage n77;

	public GImage n79;

	public Transition idle;

	public Transition gacha1;

	public Transition gacha2;

	public const string URL = "ui://29q48tv6c7pn5f8j";

	public static string Name = "UI_com_TreasureChest";

	public static string GetURL()
	{
		return "ui://29q48tv6c7pn5f8j";
	}

	public static UI_com_TreasureChest CreateInstance()
	{
		return (UI_com_TreasureChest)(object)UIPackage.CreateObject("GameActivity", "com_TreasureChest");
	}

	public static UI_com_TreasureChest CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TreasureChest).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6c7pn5f8j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n73 = (GImage)((GComponent)this).GetChild("n73");
		n74 = (GImage)((GComponent)this).GetChild("n74");
		n78 = (GImage)((GComponent)this).GetChild("n78");
		n81 = (GImage)((GComponent)this).GetChild("n81");
		n80 = (GImage)((GComponent)this).GetChild("n80");
		n75 = (GImage)((GComponent)this).GetChild("n75");
		n76 = (GImage)((GComponent)this).GetChild("n76");
		n77 = (GImage)((GComponent)this).GetChild("n77");
		n79 = (GImage)((GComponent)this).GetChild("n79");
		idle = ((GComponent)this).GetTransition("idle");
		gacha1 = ((GComponent)this).GetTransition("gacha1");
		gacha2 = ((GComponent)this).GetTransition("gacha2");
	}
}
