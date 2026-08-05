using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_com_MissileWrapper : GComponent
{
	public GMovieClip n0;

	public GGraph SfxBack;

	public Transition Explode;

	public const string URL = "ui://rx5ntv98mvre2h";

	public static string Name = "UI_com_MissileWrapper";

	public static string GetURL()
	{
		return "ui://rx5ntv98mvre2h";
	}

	public static UI_com_MissileWrapper CreateInstance()
	{
		return (UI_com_MissileWrapper)(object)UIPackage.CreateObject("ReturningRewards", "com_MissileWrapper");
	}

	public static UI_com_MissileWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MissileWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98mvre2h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		Explode = ((GComponent)this).GetTransition("Explode");
	}
}
