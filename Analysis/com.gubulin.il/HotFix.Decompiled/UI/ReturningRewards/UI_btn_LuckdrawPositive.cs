using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_btn_LuckdrawPositive : GButton
{
	public Controller Type;

	public Controller button;

	public GImage n36;

	public GImage n37;

	public GLoader icon;

	public GMovieClip n38;

	public GTextField Qty;

	public const string URL = "ui://rx5ntv98kaq512";

	public static string Name = "UI_btn_LuckdrawPositive";

	public static string GetURL()
	{
		return "ui://rx5ntv98kaq512";
	}

	public static UI_btn_LuckdrawPositive CreateInstance()
	{
		return (UI_btn_LuckdrawPositive)(object)UIPackage.CreateObject("ReturningRewards", "btn_LuckdrawPositive");
	}

	public static UI_btn_LuckdrawPositive CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_LuckdrawPositive).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98kaq512", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		button = ((GComponent)this).GetController("button");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n38 = (GMovieClip)((GComponent)this).GetChild("n38");
		Qty = (GTextField)((GComponent)this).GetChild("Qty");
	}
}
