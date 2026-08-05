using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoldierAttribute : GComponent
{
	public Controller Status;

	public GGraph attackGrowupBack;

	public GGraph defenseGrowupBack;

	public GGraph healthGrowupBack;

	public GTextField attackGrowup;

	public GTextField healthGrowup;

	public GTextField defenseGrowup;

	public GImage attackGrowupTitle;

	public GImage defenseGrowupTitle;

	public GImage healthGrowupTitle;

	public GGraph attackSfxBack;

	public GGraph healthSfxBack;

	public GGraph defenseSfxBack;

	public const string URL = "ui://7dantnbis0m4t9l";

	public static string Name = "UI_SoldierAttribute";

	public static string GetURL()
	{
		return "ui://7dantnbis0m4t9l";
	}

	public static UI_SoldierAttribute CreateInstance()
	{
		return (UI_SoldierAttribute)(object)UIPackage.CreateObject("SoldierCultivate", "SoldierAttribute");
	}

	public static UI_SoldierAttribute CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierAttribute).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbis0m4t9l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		attackGrowupBack = (GGraph)((GComponent)this).GetChild("attackGrowupBack");
		defenseGrowupBack = (GGraph)((GComponent)this).GetChild("defenseGrowupBack");
		healthGrowupBack = (GGraph)((GComponent)this).GetChild("healthGrowupBack");
		attackGrowup = (GTextField)((GComponent)this).GetChild("attackGrowup");
		healthGrowup = (GTextField)((GComponent)this).GetChild("healthGrowup");
		defenseGrowup = (GTextField)((GComponent)this).GetChild("defenseGrowup");
		attackGrowupTitle = (GImage)((GComponent)this).GetChild("attackGrowupTitle");
		defenseGrowupTitle = (GImage)((GComponent)this).GetChild("defenseGrowupTitle");
		healthGrowupTitle = (GImage)((GComponent)this).GetChild("healthGrowupTitle");
		attackSfxBack = (GGraph)((GComponent)this).GetChild("attackSfxBack");
		healthSfxBack = (GGraph)((GComponent)this).GetChild("healthSfxBack");
		defenseSfxBack = (GGraph)((GComponent)this).GetChild("defenseSfxBack");
	}
}
