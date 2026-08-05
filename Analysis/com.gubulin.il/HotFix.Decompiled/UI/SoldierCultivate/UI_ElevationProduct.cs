using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_ElevationProduct : GButton
{
	public GLoader FrameLoader;

	public GLoader IconLoader;

	public GTextField Requirement;

	public GGraph SfxBack;

	public const string URL = "ui://7dantnbionm2d";

	public static string Name = "UI_ElevationProduct";

	public static string GetURL()
	{
		return "ui://7dantnbionm2d";
	}

	public static UI_ElevationProduct CreateInstance()
	{
		return (UI_ElevationProduct)(object)UIPackage.CreateObject("SoldierCultivate", "ElevationProduct");
	}

	public static UI_ElevationProduct CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ElevationProduct).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbionm2d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		FrameLoader = (GLoader)((GComponent)this).GetChild("FrameLoader");
		IconLoader = (GLoader)((GComponent)this).GetChild("IconLoader");
		Requirement = (GTextField)((GComponent)this).GetChild("Requirement");
		string id = "ui://7dantnbionm2d".Replace("ui://", "") + "-" + ((GObject)Requirement).id;
		((GObject)Requirement).text = LanguagesManager.GetDesc(id);
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
	}
}
