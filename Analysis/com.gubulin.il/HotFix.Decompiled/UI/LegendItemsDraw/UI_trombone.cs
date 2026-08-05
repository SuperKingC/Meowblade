using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemsDraw;

public class UI_trombone : GButton
{
	public Controller button;

	public GImage n4;

	public GImage n3;

	public Transition play1;

	public Transition play2;

	public Transition play_1;

	public Transition play_2;

	public const string URL = "ui://xogvri2hs2vze";

	public static string Name = "UI_trombone";

	public static string GetURL()
	{
		return "ui://xogvri2hs2vze";
	}

	public static UI_trombone CreateInstance()
	{
		return (UI_trombone)(object)UIPackage.CreateObject("LegendItemsDraw", "trombone");
	}

	public static UI_trombone CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_trombone).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://xogvri2hs2vze", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		play1 = ((GComponent)this).GetTransition("play1");
		play2 = ((GComponent)this).GetTransition("play2");
		play_1 = ((GComponent)this).GetTransition("play-1");
		play_2 = ((GComponent)this).GetTransition("play-2");
	}
}
