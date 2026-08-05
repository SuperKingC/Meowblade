using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_btn_LuckdrawPositive : GButton
{
	public Controller Type;

	public Controller button;

	public GImage n30;

	public GImage n29;

	public UI_mc_Slot PrizeItem;

	public GImage n32;

	public GMovieClip n33;

	public const string URL = "ui://k2sprg26laau4v";

	public static string Name = "UI_btn_LuckdrawPositive";

	public static string GetURL()
	{
		return "ui://k2sprg26laau4v";
	}

	public static UI_btn_LuckdrawPositive CreateInstance()
	{
		return (UI_btn_LuckdrawPositive)(object)UIPackage.CreateObject("IslandComeAgain", "btn_LuckdrawPositive");
	}

	public static UI_btn_LuckdrawPositive CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_LuckdrawPositive).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau4v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		button = ((GComponent)this).GetController("button");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		PrizeItem = (UI_mc_Slot)(object)((GComponent)this).GetChild("PrizeItem");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n33 = (GMovieClip)((GComponent)this).GetChild("n33");
	}
}
