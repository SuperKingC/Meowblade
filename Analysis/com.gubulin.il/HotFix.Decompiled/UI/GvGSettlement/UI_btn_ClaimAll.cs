using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_btn_ClaimAll : GButton
{
	public Controller button;

	public GImage n3;

	public GMovieClip n6;

	public GLoader icon;

	public GMovieClip n7;

	public GMovieClip n8;

	public const string URL = "ui://91jxdrkanc8f13";

	public static string Name = "UI_btn_ClaimAll";

	public static string GetURL()
	{
		return "ui://91jxdrkanc8f13";
	}

	public static UI_btn_ClaimAll CreateInstance()
	{
		return (UI_btn_ClaimAll)(object)UIPackage.CreateObject("GvGSettlement", "btn_ClaimAll");
	}

	public static UI_btn_ClaimAll CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ClaimAll).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkanc8f13", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n6 = (GMovieClip)((GComponent)this).GetChild("n6");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n7 = (GMovieClip)((GComponent)this).GetChild("n7");
		n8 = (GMovieClip)((GComponent)this).GetChild("n8");
	}
}
