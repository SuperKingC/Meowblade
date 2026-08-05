using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivity;

public class UI_com_storePackItem : GButton
{
	public Controller button;

	public Controller Status;

	public GImage back;

	public GImage iconBack;

	public GLoader icon;

	public GTextField Number;

	public GTextField result;

	public GTextField reward;

	public GLoader currentCurrencyIcon;

	public GTextField Price1st;

	public GGroup priceZhGroup;

	public GImage n56;

	public GImage n59;

	public GTextField n60;

	public GTextField n55;

	public GLoader ticketIcon;

	public GTextField lockText;

	public GGroup lockGroup;

	public GImage n62;

	public const string URL = "ui://jl0c82y5fmsk8";

	public static string Name = "UI_com_storePackItem";

	public static string GetURL()
	{
		return "ui://jl0c82y5fmsk8";
	}

	public static UI_com_storePackItem CreateInstance()
	{
		return (UI_com_storePackItem)(object)UIPackage.CreateObject("WeekActivity", "com_storePackItem");
	}

	public static UI_com_storePackItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_storePackItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5fmsk8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		back = (GImage)((GComponent)this).GetChild("back");
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		Number = (GTextField)((GComponent)this).GetChild("Number");
		result = (GTextField)((GComponent)this).GetChild("result");
		string id = "ui://jl0c82y5fmsk8".Replace("ui://", "") + "-" + ((GObject)result).id;
		((GObject)result).text = LanguagesManager.GetDesc(id);
		reward = (GTextField)((GComponent)this).GetChild("reward");
		string id2 = "ui://jl0c82y5fmsk8".Replace("ui://", "") + "-" + ((GObject)reward).id;
		((GObject)reward).text = LanguagesManager.GetDesc(id2);
		currentCurrencyIcon = (GLoader)((GComponent)this).GetChild("currentCurrencyIcon");
		Price1st = (GTextField)((GComponent)this).GetChild("Price1st");
		priceZhGroup = (GGroup)((GComponent)this).GetChild("priceZhGroup");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		n59 = (GImage)((GComponent)this).GetChild("n59");
		n60 = (GTextField)((GComponent)this).GetChild("n60");
		string id3 = "ui://jl0c82y5fmsk8".Replace("ui://", "") + "-" + ((GObject)n60).id;
		((GObject)n60).text = LanguagesManager.GetDesc(id3);
		n55 = (GTextField)((GComponent)this).GetChild("n55");
		string id4 = "ui://jl0c82y5fmsk8".Replace("ui://", "") + "-" + ((GObject)n55).id;
		((GObject)n55).text = LanguagesManager.GetDesc(id4);
		ticketIcon = (GLoader)((GComponent)this).GetChild("ticketIcon");
		lockText = (GTextField)((GComponent)this).GetChild("lockText");
		string id5 = "ui://jl0c82y5fmsk8".Replace("ui://", "") + "-" + ((GObject)lockText).id;
		((GObject)lockText).text = LanguagesManager.GetDesc(id5);
		lockGroup = (GGroup)((GComponent)this).GetChild("lockGroup");
		n62 = (GImage)((GComponent)this).GetChild("n62");
	}
}
