using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_GiftPanel : GComponent
{
	public GImage OfflineEarningWindow;

	public GButton exitBtn;

	public GTextField title;

	public UI_confirmBtn confirmBtn;

	public GList giftsList;

	public const string URL = "ui://47lbpgx9bw1c3i";

	public static string Name = "UI_GiftPanel";

	public static string GetURL()
	{
		return "ui://47lbpgx9bw1c3i";
	}

	public static UI_GiftPanel CreateInstance()
	{
		return (UI_GiftPanel)(object)UIPackage.CreateObject("Tips", "GiftPanel");
	}

	public static UI_GiftPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GiftPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9bw1c3i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		OfflineEarningWindow = (GImage)((GComponent)this).GetChild("OfflineEarningWindow");
		exitBtn = (GButton)((GComponent)this).GetChild("exitBtn");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://47lbpgx9bw1c3i".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		confirmBtn = (UI_confirmBtn)(object)((GComponent)this).GetChild("confirmBtn");
		giftsList = (GList)((GComponent)this).GetChild("giftsList");
	}
}
