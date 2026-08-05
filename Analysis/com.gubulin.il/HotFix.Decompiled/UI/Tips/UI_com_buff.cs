using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_com_buff : GComponent
{
	public Controller effectRange;

	public Controller showMode;

	public Controller isDeactivate;

	public GImage n99;

	public GLoader itemIcon;

	public GImage n97;

	public GImage n102;

	public GImage n103;

	public GTextField rewardCount;

	public const string URL = "ui://47lbpgx9k73hj5ltg2";

	public static string Name = "UI_com_buff";

	public static string GetURL()
	{
		return "ui://47lbpgx9k73hj5ltg2";
	}

	public static UI_com_buff CreateInstance()
	{
		return (UI_com_buff)(object)UIPackage.CreateObject("Tips", "com_buff");
	}

	public static UI_com_buff CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_buff).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9k73hj5ltg2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		effectRange = ((GComponent)this).GetController("effectRange");
		showMode = ((GComponent)this).GetController("showMode");
		isDeactivate = ((GComponent)this).GetController("isDeactivate");
		n99 = (GImage)((GComponent)this).GetChild("n99");
		itemIcon = (GLoader)((GComponent)this).GetChild("itemIcon");
		n97 = (GImage)((GComponent)this).GetChild("n97");
		n102 = (GImage)((GComponent)this).GetChild("n102");
		n103 = (GImage)((GComponent)this).GetChild("n103");
		rewardCount = (GTextField)((GComponent)this).GetChild("rewardCount");
		string id = "ui://47lbpgx9k73hj5ltg2".Replace("ui://", "") + "-" + ((GObject)rewardCount).id;
		((GObject)rewardCount).text = LanguagesManager.GetDesc(id);
	}
}
