using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_mc_Bubble01 : GComponent
{
	public Controller State;

	public GImage n10;

	public GTextField n11;

	public UI_mc_Slot BigPrizeItem;

	public GImage n13;

	public GImage n14;

	public GTextField PrizeName;

	public GImage n16;

	public const string URL = "ui://k2sprg26laau6h";

	public static string Name = "UI_mc_Bubble01";

	public static string GetURL()
	{
		return "ui://k2sprg26laau6h";
	}

	public static UI_mc_Bubble01 CreateInstance()
	{
		return (UI_mc_Bubble01)(object)UIPackage.CreateObject("IslandComeAgain", "mc_Bubble01");
	}

	public static UI_mc_Bubble01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_Bubble01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau6h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://k2sprg26laau6h".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
		BigPrizeItem = (UI_mc_Slot)(object)((GComponent)this).GetChild("BigPrizeItem");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		PrizeName = (GTextField)((GComponent)this).GetChild("PrizeName");
		n16 = (GImage)((GComponent)this).GetChild("n16");
	}
}
