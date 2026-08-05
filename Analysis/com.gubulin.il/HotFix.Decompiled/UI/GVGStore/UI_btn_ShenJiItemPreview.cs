using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_btn_ShenJiItemPreview : GButton
{
	public Controller State;

	public Controller HasPurchaseLimit;

	public Controller button;

	public GImage n6;

	public GImage n7;

	public GLoader itemIcon;

	public GTextField itemName;

	public GTextField RemainingPurchaseLimitCount;

	public GTextField n4;

	public GGroup n5;

	public const string URL = "ui://fvc33k3gllla35";

	public static string Name = "UI_btn_ShenJiItemPreview";

	public static string GetURL()
	{
		return "ui://fvc33k3gllla35";
	}

	public static UI_btn_ShenJiItemPreview CreateInstance()
	{
		return (UI_btn_ShenJiItemPreview)(object)UIPackage.CreateObject("GVGStore", "btn_ShenJiItemPreview");
	}

	public static UI_btn_ShenJiItemPreview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ShenJiItemPreview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gllla35", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		HasPurchaseLimit = ((GComponent)this).GetController("HasPurchaseLimit");
		button = ((GComponent)this).GetController("button");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		itemIcon = (GLoader)((GComponent)this).GetChild("itemIcon");
		itemName = (GTextField)((GComponent)this).GetChild("itemName");
		RemainingPurchaseLimitCount = (GTextField)((GComponent)this).GetChild("RemainingPurchaseLimitCount");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://fvc33k3gllla35".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		n5 = (GGroup)((GComponent)this).GetChild("n5");
	}
}
