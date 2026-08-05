using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_SoldierNamePotentialLevelBack : GComponent
{
	public Controller Level;

	public GImage n4;

	public GImage n5;

	public GImage n2;

	public GImage n3;

	public GImage n8;

	public GImage n9;

	public GImage n6;

	public GImage n7;

	public GImage n10;

	public GImage n11;

	public GImage n13;

	public const string URL = "ui://kt6rg65os8sztbl";

	public static string Name = "UI_SoldierNamePotentialLevelBack";

	public static string GetURL()
	{
		return "ui://kt6rg65os8sztbl";
	}

	public static UI_SoldierNamePotentialLevelBack CreateInstance()
	{
		return (UI_SoldierNamePotentialLevelBack)(object)UIPackage.CreateObject("PublicResources", "SoldierNamePotentialLevelBack");
	}

	public static UI_SoldierNamePotentialLevelBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierNamePotentialLevelBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65os8sztbl", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Level = ((GComponent)this).GetController("Level");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n13 = (GImage)((GComponent)this).GetChild("n13");
	}
}
