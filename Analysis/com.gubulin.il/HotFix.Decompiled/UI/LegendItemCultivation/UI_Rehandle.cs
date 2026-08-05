using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_Rehandle : GComponent
{
	public Controller PageController;

	public GImage n74;

	public GList attributes;

	public GButton noBtn;

	public GButton yesBtn;

	public GButton Rehandle;

	public GList CostInfo;

	public GTextField n95;

	public GList PropertyContent;

	public GButton Help;

	public const string URL = "ui://b9wlonaqtpmtf";

	public static string Name = "UI_Rehandle";

	public void SetButtonTitle()
	{
		noBtn.title = LanguagesManager.GetDesc("LegendItemCultivation-Rehandle-noBtn-title");
		yesBtn.title = LanguagesManager.GetDesc("LegendItemCultivation-Rehandle-yesBtn-title");
	}

	public static string GetURL()
	{
		return "ui://b9wlonaqtpmtf";
	}

	public static UI_Rehandle CreateInstance()
	{
		return (UI_Rehandle)(object)UIPackage.CreateObject("LegendItemCultivation", "Rehandle");
	}

	public static UI_Rehandle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Rehandle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqtpmtf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		n74 = (GImage)((GComponent)this).GetChild("n74");
		attributes = (GList)((GComponent)this).GetChild("attributes");
		noBtn = (GButton)((GComponent)this).GetChild("noBtn");
		yesBtn = (GButton)((GComponent)this).GetChild("yesBtn");
		Rehandle = (GButton)((GComponent)this).GetChild("Rehandle");
		CostInfo = (GList)((GComponent)this).GetChild("CostInfo");
		n95 = (GTextField)((GComponent)this).GetChild("n95");
		string id = "ui://b9wlonaqtpmtf".Replace("ui://", "") + "-" + ((GObject)n95).id;
		((GObject)n95).text = LanguagesManager.GetDesc(id);
		PropertyContent = (GList)((GComponent)this).GetChild("PropertyContent");
		Help = (GButton)((GComponent)this).GetChild("Help");
	}
}
