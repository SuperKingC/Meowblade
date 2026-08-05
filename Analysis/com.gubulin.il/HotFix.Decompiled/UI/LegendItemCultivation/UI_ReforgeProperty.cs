using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_ReforgeProperty : GComponent
{
	public Controller TyepController;

	public GImage ContentBack;

	public GImage n10;

	public GTextField Title;

	public GRichTextField curContent;

	public GRichTextField nextContent;

	public GRichTextField curValue;

	public GRichTextField nextValue;

	public GGraph curContentSfxBack;

	public GGraph curValueSfxBack;

	public GGraph nextContentSfxBack;

	public GGraph nextValueSfxBack;

	public UI_PropetryLock lockBtn;

	public GImage n26;

	public GTextField lockedContent;

	public GGraph n32;

	public GTextField Index;

	public const string URL = "ui://b9wlonaqmpf91k";

	public static string Name = "UI_ReforgeProperty";

	public static string GetURL()
	{
		return "ui://b9wlonaqmpf91k";
	}

	public static UI_ReforgeProperty CreateInstance()
	{
		return (UI_ReforgeProperty)(object)UIPackage.CreateObject("LegendItemCultivation", "ReforgeProperty");
	}

	public static UI_ReforgeProperty CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReforgeProperty).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqmpf91k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		TyepController = ((GComponent)this).GetController("TyepController");
		ContentBack = (GImage)((GComponent)this).GetChild("ContentBack");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://b9wlonaqmpf91k".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		curContent = (GRichTextField)((GComponent)this).GetChild("curContent");
		nextContent = (GRichTextField)((GComponent)this).GetChild("nextContent");
		curValue = (GRichTextField)((GComponent)this).GetChild("curValue");
		nextValue = (GRichTextField)((GComponent)this).GetChild("nextValue");
		curContentSfxBack = (GGraph)((GComponent)this).GetChild("curContentSfxBack");
		curValueSfxBack = (GGraph)((GComponent)this).GetChild("curValueSfxBack");
		nextContentSfxBack = (GGraph)((GComponent)this).GetChild("nextContentSfxBack");
		nextValueSfxBack = (GGraph)((GComponent)this).GetChild("nextValueSfxBack");
		lockBtn = (UI_PropetryLock)(object)((GComponent)this).GetChild("lockBtn");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		lockedContent = (GTextField)((GComponent)this).GetChild("lockedContent");
		n32 = (GGraph)((GComponent)this).GetChild("n32");
		Index = (GTextField)((GComponent)this).GetChild("Index");
	}
}
