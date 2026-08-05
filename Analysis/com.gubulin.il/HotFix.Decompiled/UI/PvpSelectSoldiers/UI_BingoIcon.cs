using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_BingoIcon : GComponent
{
	public GImage n99;

	public GMovieClip n100;

	public GMovieClip n101;

	public Transition Appear;

	public const string URL = "ui://82mo10n5uwtxjds3";

	public static string Name = "UI_BingoIcon";

	public static string GetURL()
	{
		return "ui://82mo10n5uwtxjds3";
	}

	public static UI_BingoIcon CreateInstance()
	{
		return (UI_BingoIcon)(object)UIPackage.CreateObject("PvpSelectSoldiers", "BingoIcon");
	}

	public static UI_BingoIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BingoIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5uwtxjds3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n99 = (GImage)((GComponent)this).GetChild("n99");
		n100 = (GMovieClip)((GComponent)this).GetChild("n100");
		n101 = (GMovieClip)((GComponent)this).GetChild("n101");
		Appear = ((GComponent)this).GetTransition("Appear");
	}
}
