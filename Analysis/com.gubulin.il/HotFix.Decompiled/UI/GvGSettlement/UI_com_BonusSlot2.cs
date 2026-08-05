using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_com_BonusSlot2 : GComponent
{
	public Controller IsClaimed;

	public UI_com_Item BonusItem;

	public GMovieClip n140;

	public GImage n141;

	public GImage n138;

	public GImage n139;

	public GTextField Count;

	public const string URL = "ui://91jxdrkae1a736";

	public static string Name = "UI_com_BonusSlot2";

	public static string GetURL()
	{
		return "ui://91jxdrkae1a736";
	}

	public static UI_com_BonusSlot2 CreateInstance()
	{
		return (UI_com_BonusSlot2)(object)UIPackage.CreateObject("GvGSettlement", "com_BonusSlot2");
	}

	public static UI_com_BonusSlot2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BonusSlot2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkae1a736", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsClaimed = ((GComponent)this).GetController("IsClaimed");
		BonusItem = (UI_com_Item)(object)((GComponent)this).GetChild("BonusItem");
		n140 = (GMovieClip)((GComponent)this).GetChild("n140");
		n141 = (GImage)((GComponent)this).GetChild("n141");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		n139 = (GImage)((GComponent)this).GetChild("n139");
		Count = (GTextField)((GComponent)this).GetChild("Count");
		string id = "ui://91jxdrkae1a736".Replace("ui://", "") + "-" + ((GObject)Count).id;
		((GObject)Count).text = LanguagesManager.GetDesc(id);
	}
}
