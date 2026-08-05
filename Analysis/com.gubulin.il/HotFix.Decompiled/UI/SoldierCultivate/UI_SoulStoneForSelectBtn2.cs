using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoulStoneForSelectBtn2 : GButton
{
	public Controller button;

	public GImage n9;

	public GButton iconBtn;

	public GImage n6;

	public GImage note;

	public GGraph SfxBack;

	public const string URL = "ui://7dantnbiwqizt9r";

	public static string Name = "UI_SoulStoneForSelectBtn2";

	public static string GetURL()
	{
		return "ui://7dantnbiwqizt9r";
	}

	public static UI_SoulStoneForSelectBtn2 CreateInstance()
	{
		return (UI_SoulStoneForSelectBtn2)(object)UIPackage.CreateObject("SoldierCultivate", "SoulStoneForSelectBtn2");
	}

	public static UI_SoulStoneForSelectBtn2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoulStoneForSelectBtn2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbiwqizt9r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		iconBtn = (GButton)((GComponent)this).GetChild("iconBtn");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		note = (GImage)((GComponent)this).GetChild("note");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
	}
}
