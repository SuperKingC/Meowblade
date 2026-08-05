using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_storeBtnAnime : GComponent
{
	public GImage n12;

	public GImage n15;

	public Transition t0;

	public const string URL = "ui://29q48tv610g25f75";

	public static string Name = "UI_storeBtnAnime";

	public static string GetURL()
	{
		return "ui://29q48tv610g25f75";
	}

	public static UI_storeBtnAnime CreateInstance()
	{
		return (UI_storeBtnAnime)(object)UIPackage.CreateObject("GameActivity", "storeBtnAnime");
	}

	public static UI_storeBtnAnime CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_storeBtnAnime).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv610g25f75", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
