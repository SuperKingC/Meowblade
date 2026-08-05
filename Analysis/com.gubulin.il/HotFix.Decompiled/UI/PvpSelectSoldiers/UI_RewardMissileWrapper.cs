using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_RewardMissileWrapper : GComponent
{
	public GMovieClip n0;

	public GLoader VfxWrapper;

	public Transition Explode;

	public const string URL = "ui://82mo10n5nts5dpu";

	public static string Name = "UI_RewardMissileWrapper";

	public static string GetURL()
	{
		return "ui://82mo10n5nts5dpu";
	}

	public static UI_RewardMissileWrapper CreateInstance()
	{
		return (UI_RewardMissileWrapper)(object)UIPackage.CreateObject("PvpSelectSoldiers", "RewardMissileWrapper");
	}

	public static UI_RewardMissileWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RewardMissileWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5nts5dpu", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GMovieClip)((GComponent)this).GetChild("n0");
		VfxWrapper = (GLoader)((GComponent)this).GetChild("VfxWrapper");
		Explode = ((GComponent)this).GetTransition("Explode");
	}
}
