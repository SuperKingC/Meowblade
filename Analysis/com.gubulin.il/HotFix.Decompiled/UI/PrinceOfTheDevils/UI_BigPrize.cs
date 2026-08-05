using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_BigPrize : GButton
{
	public Controller claimStatus;

	public GImage n7;

	public GGraph fxBack;

	public GLoader rewardIcon;

	public GTextField rewardNum;

	public GMovieClip n8;

	public GImage redPoint;

	public GImage n9;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://zko5n3vez7z6l";

	public static string Name = "UI_BigPrize";

	public static string GetURL()
	{
		return "ui://zko5n3vez7z6l";
	}

	public static UI_BigPrize CreateInstance()
	{
		return (UI_BigPrize)(object)UIPackage.CreateObject("PrinceOfTheDevils", "BigPrize");
	}

	public static UI_BigPrize CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BigPrize).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3vez7z6l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		claimStatus = ((GComponent)this).GetController("claimStatus");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		fxBack = (GGraph)((GComponent)this).GetChild("fxBack");
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		rewardNum = (GTextField)((GComponent)this).GetChild("rewardNum");
		string id = "ui://zko5n3vez7z6l".Replace("ui://", "") + "-" + ((GObject)rewardNum).id;
		((GObject)rewardNum).text = LanguagesManager.GetDesc(id);
		n8 = (GMovieClip)((GComponent)this).GetChild("n8");
		redPoint = (GImage)((GComponent)this).GetChild("redPoint");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
