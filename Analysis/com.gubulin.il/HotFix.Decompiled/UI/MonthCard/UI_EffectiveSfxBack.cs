using FairyGUI;
using FairyGUI.Utils;

namespace UI.MonthCard;

public class UI_EffectiveSfxBack : GComponent
{
	public Controller StatusController;

	public GGraph cardActivaitedSfxBack;

	public GImage stampBack;

	public GGraph stampActivaitedSfxBack;

	public GImage stamp;

	public GGraph eyeSfxBack;

	public GGraph explosionSfxBack;

	public const string URL = "ui://4ctl553sgawyl";

	public static string Name = "UI_EffectiveSfxBack";

	public static string GetURL()
	{
		return "ui://4ctl553sgawyl";
	}

	public static UI_EffectiveSfxBack CreateInstance()
	{
		return (UI_EffectiveSfxBack)(object)UIPackage.CreateObject("MonthCard", "EffectiveSfxBack");
	}

	public static UI_EffectiveSfxBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EffectiveSfxBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553sgawyl", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		StatusController = ((GComponent)this).GetController("StatusController");
		cardActivaitedSfxBack = (GGraph)((GComponent)this).GetChild("cardActivaitedSfxBack");
		stampBack = (GImage)((GComponent)this).GetChild("stampBack");
		stampActivaitedSfxBack = (GGraph)((GComponent)this).GetChild("stampActivaitedSfxBack");
		stamp = (GImage)((GComponent)this).GetChild("stamp");
		eyeSfxBack = (GGraph)((GComponent)this).GetChild("eyeSfxBack");
		explosionSfxBack = (GGraph)((GComponent)this).GetChild("explosionSfxBack");
	}
}
