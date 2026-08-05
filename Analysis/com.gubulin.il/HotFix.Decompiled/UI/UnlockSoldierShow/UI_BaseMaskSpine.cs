using FairyGUI;
using FairyGUI.Utils;

namespace UI.UnlockSoldierShow;

public class UI_BaseMaskSpine : GComponent
{
	public GMovieClip n82;

	public const string URL = "ui://ia1am3ehkfyut3g";

	public static string Name = "UI_BaseMaskSpine";

	public static string GetURL()
	{
		return "ui://ia1am3ehkfyut3g";
	}

	public static UI_BaseMaskSpine CreateInstance()
	{
		return (UI_BaseMaskSpine)(object)UIPackage.CreateObject("UnlockSoldierShow", "BaseMaskSpine");
	}

	public static UI_BaseMaskSpine CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BaseMaskSpine).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ia1am3ehkfyut3g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n82 = (GMovieClip)((GComponent)this).GetChild("n82");
	}
}
