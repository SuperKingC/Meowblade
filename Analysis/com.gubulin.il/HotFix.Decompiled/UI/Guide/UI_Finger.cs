using FairyGUI;
using FairyGUI.Utils;

namespace UI.Guide;

public class UI_Finger : GComponent
{
	public GMovieClip finger;

	public const string URL = "ui://5vxjvcrbb5yvx";

	public static string Name = "UI_Finger";

	public static string GetURL()
	{
		return "ui://5vxjvcrbb5yvx";
	}

	public static UI_Finger CreateInstance()
	{
		return (UI_Finger)(object)UIPackage.CreateObject("Guide", "Finger");
	}

	public static UI_Finger CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Finger).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5vxjvcrbb5yvx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		finger = (GMovieClip)((GComponent)this).GetChild("finger");
	}
}
