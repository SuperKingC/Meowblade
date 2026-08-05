using FairyGUI;
using FairyGUI.Utils;

namespace UI.FullScreenAnimation;

public class UI_ExchangeSoldiersPos : GComponent
{
	public GMovieClip n0;

	public const string URL = "ui://huhayyi1h3uh1";

	public static string Name = "UI_ExchangeSoldiersPos";

	public static string GetURL()
	{
		return "ui://huhayyi1h3uh1";
	}

	public static UI_ExchangeSoldiersPos CreateInstance()
	{
		return (UI_ExchangeSoldiersPos)(object)UIPackage.CreateObject("FullScreenAnimation", "ExchangeSoldiersPos");
	}

	public static UI_ExchangeSoldiersPos CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExchangeSoldiersPos).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://huhayyi1h3uh1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
