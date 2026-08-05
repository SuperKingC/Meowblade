using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivity;

public class UI_com_giftContent : GComponent
{
	public GImage n5;

	public GImage n8;

	public GImage n6;

	public GList cardList;

	public GImage n10;

	public GMovieClip n11;

	public GImage n9;

	public UI_ExitAdvancedBtn backBtn;

	public Transition t0;

	public const string URL = "ui://jl0c82y5hah9e";

	public static string Name = "UI_com_giftContent";

	public static string GetURL()
	{
		return "ui://jl0c82y5hah9e";
	}

	public static UI_com_giftContent CreateInstance()
	{
		return (UI_com_giftContent)(object)UIPackage.CreateObject("WeekActivity", "com_giftContent");
	}

	public static UI_com_giftContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_giftContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5hah9e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		cardList = (GList)((GComponent)this).GetChild("cardList");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GMovieClip)((GComponent)this).GetChild("n11");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		backBtn = (UI_ExitAdvancedBtn)(object)((GComponent)this).GetChild("backBtn");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
