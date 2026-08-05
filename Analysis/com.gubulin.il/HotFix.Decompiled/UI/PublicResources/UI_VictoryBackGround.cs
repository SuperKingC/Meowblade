using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_VictoryBackGround : GComponent
{
	public UI_VictoryLight n4;

	public GImage n5;

	public Transition backRotate;

	public const string URL = "ui://kt6rg65oqtmo41";

	public static string Name = "UI_VictoryBackGround";

	public static string GetURL()
	{
		return "ui://kt6rg65oqtmo41";
	}

	public static UI_VictoryBackGround CreateInstance()
	{
		return (UI_VictoryBackGround)(object)UIPackage.CreateObject("PublicResources", "VictoryBackGround");
	}

	public static UI_VictoryBackGround CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_VictoryBackGround).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oqtmo41", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (UI_VictoryLight)(object)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		backRotate = ((GComponent)this).GetTransition("backRotate");
	}
}
