using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.BlackMarketer;

public class UI_CardBasis : GButton
{
	public Controller CategoryController;

	public GImage n21;

	public GImage n22;

	public GImage n23;

	public GImage n27;

	public GImage n30;

	public GImage n24;

	public GGraph n3;

	public GLoader logo;

	public GButton showPicture;

	public GTextField showTitle;

	public GButton ExclamationTipBtn;

	public GImage newIcon;

	public GImage n28;

	public GImage n29;

	public Transition breathing;

	public const string URL = "ui://036k96hric7j1l";

	public static string Name = "UI_CardBasis";

	public static string GetURL()
	{
		return "ui://036k96hric7j1l";
	}

	public static UI_CardBasis CreateInstance()
	{
		return (UI_CardBasis)(object)UIPackage.CreateObject("BlackMarketer", "CardBasis");
	}

	public static UI_CardBasis CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CardBasis).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://036k96hric7j1l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CategoryController = ((GComponent)this).GetController("CategoryController");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n3 = (GGraph)((GComponent)this).GetChild("n3");
		logo = (GLoader)((GComponent)this).GetChild("logo");
		showPicture = (GButton)((GComponent)this).GetChild("showPicture");
		showTitle = (GTextField)((GComponent)this).GetChild("showTitle");
		string id = "ui://036k96hric7j1l".Replace("ui://", "") + "-" + ((GObject)showTitle).id;
		((GObject)showTitle).text = LanguagesManager.GetDesc(id);
		ExclamationTipBtn = (GButton)((GComponent)this).GetChild("ExclamationTipBtn");
		newIcon = (GImage)((GComponent)this).GetChild("newIcon");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		breathing = ((GComponent)this).GetTransition("breathing");
	}
}
