using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_PotentialLevelText_small_New : GComponent
{
	public Controller Level;

	public GImage n5;

	public GImage n6;

	public GImage n7;

	public GImage n8;

	public GImage n9;

	public GImage n10;

	public GImage n11;

	public GImage n12;

	public GImage n13;

	public GImage n14;

	public const string URL = "ui://kt6rg65opbt7v4ap";

	public static string Name = "UI_PotentialLevelText_small_New";

	public static string GetURL()
	{
		return "ui://kt6rg65opbt7v4ap";
	}

	public static UI_PotentialLevelText_small_New CreateInstance()
	{
		return (UI_PotentialLevelText_small_New)(object)UIPackage.CreateObject("PublicResources", "PotentialLevelText_small_New");
	}

	public static UI_PotentialLevelText_small_New CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PotentialLevelText_small_New).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65opbt7v4ap", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Level = ((GComponent)this).GetController("Level");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
	}
}
