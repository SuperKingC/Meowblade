using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_com_effCoinFlash : GComponent
{
	public GMovieClip n0;

	public const string URL = "ui://rx5ntv98k5p229";

	public static string Name = "UI_com_effCoinFlash";

	public static string GetURL()
	{
		return "ui://rx5ntv98k5p229";
	}

	public static UI_com_effCoinFlash CreateInstance()
	{
		return (UI_com_effCoinFlash)(object)UIPackage.CreateObject("ReturningRewards", "com_effCoinFlash");
	}

	public static UI_com_effCoinFlash CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_effCoinFlash).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98k5p229", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GMovieClip)((GComponent)this).GetChild("n0");
	}
}
