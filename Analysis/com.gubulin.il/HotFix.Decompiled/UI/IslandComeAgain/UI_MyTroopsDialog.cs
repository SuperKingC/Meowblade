using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_MyTroopsDialog : GComponent
{
	public Controller Type;

	public GImage back;

	public GGraph n49;

	public UI_MyTroopsSketchMap FormationSketchMap;

	public GTextField n59;

	public GTextField n66;

	public UI_BackToCampAndReplenishTroops ReplenishBtn;

	public UI_BackToCampAndChangeTroops ChangeTroopsBtn;

	public UI_CurTroopsFormation Formation;

	public const string URL = "ui://k2sprg26in7b1b";

	public static string Name = "UI_MyTroopsDialog";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://k2sprg26in7b1b".Replace("ui://", ""), ((GObject)n59).id, Type.selectedIndex);
		((GObject)n59).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://k2sprg26in7b1b";
	}

	public static UI_MyTroopsDialog CreateInstance()
	{
		return (UI_MyTroopsDialog)(object)UIPackage.CreateObject("IslandComeAgain", "MyTroopsDialog");
	}

	public static UI_MyTroopsDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MyTroopsDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b1b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		back = (GImage)((GComponent)this).GetChild("back");
		n49 = (GGraph)((GComponent)this).GetChild("n49");
		FormationSketchMap = (UI_MyTroopsSketchMap)(object)((GComponent)this).GetChild("FormationSketchMap");
		n59 = (GTextField)((GComponent)this).GetChild("n59");
		string id = "ui://k2sprg26in7b1b".Replace("ui://", "") + "-" + ((GObject)n59).id;
		((GObject)n59).text = LanguagesManager.GetDesc(id);
		n66 = (GTextField)((GComponent)this).GetChild("n66");
		string id2 = "ui://k2sprg26in7b1b".Replace("ui://", "") + "-" + ((GObject)n66).id;
		((GObject)n66).text = LanguagesManager.GetDesc(id2);
		ReplenishBtn = (UI_BackToCampAndReplenishTroops)(object)((GComponent)this).GetChild("ReplenishBtn");
		ChangeTroopsBtn = (UI_BackToCampAndChangeTroops)(object)((GComponent)this).GetChild("ChangeTroopsBtn");
		Formation = (UI_CurTroopsFormation)(object)((GComponent)this).GetChild("Formation");
	}
}
