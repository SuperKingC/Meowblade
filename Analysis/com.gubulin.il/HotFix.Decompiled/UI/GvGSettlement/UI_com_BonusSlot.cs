using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_com_BonusSlot : GComponent
{
	public Controller IsClaimed;

	public UI_com_Item BonusItem;

	public GMovieClip n140;

	public GImage n141;

	public GImage n138;

	public GImage n139;

	public const string URL = "ui://91jxdrkanc8fw";

	public static string Name = "UI_com_BonusSlot";

	public static string GetURL()
	{
		return "ui://91jxdrkanc8fw";
	}

	public static UI_com_BonusSlot CreateInstance()
	{
		return (UI_com_BonusSlot)(object)UIPackage.CreateObject("GvGSettlement", "com_BonusSlot");
	}

	public static UI_com_BonusSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BonusSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkanc8fw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsClaimed = ((GComponent)this).GetController("IsClaimed");
		BonusItem = (UI_com_Item)(object)((GComponent)this).GetChild("BonusItem");
		n140 = (GMovieClip)((GComponent)this).GetChild("n140");
		n141 = (GImage)((GComponent)this).GetChild("n141");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		n139 = (GImage)((GComponent)this).GetChild("n139");
	}
}
