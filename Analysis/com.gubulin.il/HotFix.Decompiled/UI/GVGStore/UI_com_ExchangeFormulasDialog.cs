using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_ExchangeFormulasDialog : GComponent
{
	public GImage back;

	public GImage n3;

	public GImage n16;

	public GImage n9;

	public GTextField n2;

	public GList Materials;

	public GList LimitedFormulas;

	public GList FreeFormulas;

	public GImage n17;

	public GTextField UpdateTime;

	public GImage n10;

	public GTextField n11;

	public GGroup n14;

	public GImage n18;

	public GButton Close;

	public const string URL = "ui://fvc33k3gjsiid";

	public static string Name = "UI_com_ExchangeFormulasDialog";

	public static string GetURL()
	{
		return "ui://fvc33k3gjsiid";
	}

	public static UI_com_ExchangeFormulasDialog CreateInstance()
	{
		return (UI_com_ExchangeFormulasDialog)(object)UIPackage.CreateObject("GVGStore", "com_ExchangeFormulasDialog");
	}

	public static UI_com_ExchangeFormulasDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ExchangeFormulasDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gjsiid", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://fvc33k3gjsiid".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		Materials = (GList)((GComponent)this).GetChild("Materials");
		LimitedFormulas = (GList)((GComponent)this).GetChild("LimitedFormulas");
		FreeFormulas = (GList)((GComponent)this).GetChild("FreeFormulas");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		UpdateTime = (GTextField)((GComponent)this).GetChild("UpdateTime");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id2 = "ui://fvc33k3gjsiid".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id2);
		n14 = (GGroup)((GComponent)this).GetChild("n14");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		Close = (GButton)((GComponent)this).GetChild("Close");
	}
}
