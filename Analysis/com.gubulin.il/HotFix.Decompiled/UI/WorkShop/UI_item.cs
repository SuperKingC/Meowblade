using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorkShop;

public class UI_item : GComponent
{
	public GImage UnlockBack;

	public GImage n59;

	public GGraph titleBack;

	public UI_IconBtn frame;

	public GLoader back;

	public GLoader icon;

	public GTextField title;

	public GRichTextField order;

	public UI_upgrade upgrade;

	public GList goodsList;

	public GTextField stock;

	public GList workersBackList;

	public GList workersList;

	public GGraph outputChangeSpine;

	public GImage max;

	public GTextField stockTitle;

	public GImage recruitmentMark;

	public UI_increase increase;

	public UI_reduce reduce;

	public GTextField outPutTitle;

	public GRichTextField output;

	public GRichTextField outputChange;

	public GButton ExclamationMarkBtn;

	public GGroup unLockGroup;

	public GImage LockBack;

	public GImage lockNote;

	public GTextField lockTip;

	public GGroup lockGroup;

	public const string URL = "ui://k6y9jq3appg4p";

	public static string Name = "UI_item";

	public static string GetURL()
	{
		return "ui://k6y9jq3appg4p";
	}

	public static UI_item CreateInstance()
	{
		return (UI_item)(object)UIPackage.CreateObject("WorkShop", "item");
	}

	public static UI_item CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_item).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k6y9jq3appg4p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		UnlockBack = (GImage)((GComponent)this).GetChild("UnlockBack");
		n59 = (GImage)((GComponent)this).GetChild("n59");
		titleBack = (GGraph)((GComponent)this).GetChild("titleBack");
		frame = (UI_IconBtn)(object)((GComponent)this).GetChild("frame");
		back = (GLoader)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GTextField)((GComponent)this).GetChild("title");
		order = (GRichTextField)((GComponent)this).GetChild("order");
		string id = "ui://k6y9jq3appg4p".Replace("ui://", "") + "-" + ((GObject)order).id;
		((GObject)order).text = LanguagesManager.GetDesc(id);
		upgrade = (UI_upgrade)(object)((GComponent)this).GetChild("upgrade");
		goodsList = (GList)((GComponent)this).GetChild("goodsList");
		stock = (GTextField)((GComponent)this).GetChild("stock");
		workersBackList = (GList)((GComponent)this).GetChild("workersBackList");
		workersList = (GList)((GComponent)this).GetChild("workersList");
		outputChangeSpine = (GGraph)((GComponent)this).GetChild("outputChangeSpine");
		max = (GImage)((GComponent)this).GetChild("max");
		stockTitle = (GTextField)((GComponent)this).GetChild("stockTitle");
		string id2 = "ui://k6y9jq3appg4p".Replace("ui://", "") + "-" + ((GObject)stockTitle).id;
		((GObject)stockTitle).text = LanguagesManager.GetDesc(id2);
		recruitmentMark = (GImage)((GComponent)this).GetChild("recruitmentMark");
		increase = (UI_increase)(object)((GComponent)this).GetChild("increase");
		reduce = (UI_reduce)(object)((GComponent)this).GetChild("reduce");
		outPutTitle = (GTextField)((GComponent)this).GetChild("outPutTitle");
		string id3 = "ui://k6y9jq3appg4p".Replace("ui://", "") + "-" + ((GObject)outPutTitle).id;
		((GObject)outPutTitle).text = LanguagesManager.GetDesc(id3);
		output = (GRichTextField)((GComponent)this).GetChild("output");
		outputChange = (GRichTextField)((GComponent)this).GetChild("outputChange");
		string id4 = "ui://k6y9jq3appg4p".Replace("ui://", "") + "-" + ((GObject)outputChange).id;
		((GObject)outputChange).text = LanguagesManager.GetDesc(id4);
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
		unLockGroup = (GGroup)((GComponent)this).GetChild("unLockGroup");
		LockBack = (GImage)((GComponent)this).GetChild("LockBack");
		lockNote = (GImage)((GComponent)this).GetChild("lockNote");
		lockTip = (GTextField)((GComponent)this).GetChild("lockTip");
		string id5 = "ui://k6y9jq3appg4p".Replace("ui://", "") + "-" + ((GObject)lockTip).id;
		((GObject)lockTip).text = LanguagesManager.GetDesc(id5);
		lockGroup = (GGroup)((GComponent)this).GetChild("lockGroup");
	}
}
