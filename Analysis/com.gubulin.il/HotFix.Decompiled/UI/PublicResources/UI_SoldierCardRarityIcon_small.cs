using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_SoldierCardRarityIcon_small : GComponent
{
	public Controller Level;

	public GImage n3;

	public GImage n4;

	public GImage n5;

	public GImage n6;

	public GImage n7;

	public GImage n8;

	public GImage n9;

	public GImage n10;

	public const string URL = "ui://kt6rg65og7ifvf3";

	public static string Name = "UI_SoldierCardRarityIcon_small";

	public static string GetURL()
	{
		return "ui://kt6rg65og7ifvf3";
	}

	public static UI_SoldierCardRarityIcon_small CreateInstance()
	{
		return (UI_SoldierCardRarityIcon_small)(object)UIPackage.CreateObject("PublicResources", "SoldierCardRarityIcon_small");
	}

	public static UI_SoldierCardRarityIcon_small CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierCardRarityIcon_small).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65og7ifvf3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Level = ((GComponent)this).GetController("Level");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
