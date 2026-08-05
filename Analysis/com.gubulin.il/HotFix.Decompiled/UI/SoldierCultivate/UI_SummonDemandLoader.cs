using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SummonDemandLoader : GButton
{
	public GLoader frame;

	public GLoader icon;

	public GTextField Amount;

	public GTextField Title;

	public const string URL = "ui://7dantnbionm2o";

	public static string Name = "UI_SummonDemandLoader";

	public static string GetURL()
	{
		return "ui://7dantnbionm2o";
	}

	public static UI_SummonDemandLoader CreateInstance()
	{
		return (UI_SummonDemandLoader)(object)UIPackage.CreateObject("SoldierCultivate", "SummonDemandLoader");
	}

	public static UI_SummonDemandLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SummonDemandLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbionm2o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		frame = (GLoader)((GComponent)this).GetChild("frame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		Amount = (GTextField)((GComponent)this).GetChild("Amount");
		string id = "ui://7dantnbionm2o".Replace("ui://", "") + "-" + ((GObject)Amount).id;
		((GObject)Amount).text = LanguagesManager.GetDesc(id);
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id2 = "ui://7dantnbionm2o".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id2);
	}
}
