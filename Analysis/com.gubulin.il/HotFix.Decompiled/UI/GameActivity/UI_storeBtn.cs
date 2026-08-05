using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_storeBtn : GButton
{
	public Controller button;

	public GImage n12;

	public UI_storeBtnAnime storeBtnAnime;

	public GImage n3;

	public GMovieClip n11;

	public GImage n4;

	public GMovieClip n10;

	public GImage n5;

	public GLoader ticketIcon;

	public GTextField ticketCount;

	public GMovieClip n13;

	public GGraph vfxWrapper;

	public Transition BreathingLights;

	public Transition Stars;

	public Transition Flash;

	public const string URL = "ui://29q48tv6q9xef5v";

	public static string Name = "UI_storeBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6q9xef5v";
	}

	public static UI_storeBtn CreateInstance()
	{
		return (UI_storeBtn)(object)UIPackage.CreateObject("GameActivity", "storeBtn");
	}

	public static UI_storeBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_storeBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6q9xef5v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		storeBtnAnime = (UI_storeBtnAnime)(object)((GComponent)this).GetChild("storeBtnAnime");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n11 = (GMovieClip)((GComponent)this).GetChild("n11");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n10 = (GMovieClip)((GComponent)this).GetChild("n10");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		ticketIcon = (GLoader)((GComponent)this).GetChild("ticketIcon");
		ticketCount = (GTextField)((GComponent)this).GetChild("ticketCount");
		n13 = (GMovieClip)((GComponent)this).GetChild("n13");
		vfxWrapper = (GGraph)((GComponent)this).GetChild("vfxWrapper");
		BreathingLights = ((GComponent)this).GetTransition("BreathingLights");
		Stars = ((GComponent)this).GetTransition("Stars");
		Flash = ((GComponent)this).GetTransition("Flash");
	}
}
