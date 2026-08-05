using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_LevelStar : GComponent
{
	public GImage n2;

	public GImage n3;

	public GLoader loader;

	public GGraph SfxBack;

	public const string URL = "ui://7dantnbionm2j";

	public static string Name = "UI_LevelStar";

	public static string GetURL()
	{
		return "ui://7dantnbionm2j";
	}

	public static UI_LevelStar CreateInstance()
	{
		return (UI_LevelStar)(object)UIPackage.CreateObject("SoldierCultivate", "LevelStar");
	}

	public static UI_LevelStar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LevelStar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbionm2j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		loader = (GLoader)((GComponent)this).GetChild("loader");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
	}
}
