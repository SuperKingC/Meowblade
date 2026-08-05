using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_WaveMask : GButton
{
	public Controller button;

	public GImage n8;

	public GImage mask;

	public GMovieClip wave;

	public GImage frame;

	public Transition fluctuation;

	public const string URL = "ui://c9n2h0ksm7wz8t";

	public static string Name = "UI_WaveMask";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz8t";
	}

	public static UI_WaveMask CreateInstance()
	{
		return (UI_WaveMask)(object)UIPackage.CreateObject("WorldMap", "WaveMask");
	}

	public static UI_WaveMask CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WaveMask).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz8t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		mask = (GImage)((GComponent)this).GetChild("mask");
		wave = (GMovieClip)((GComponent)this).GetChild("wave");
		frame = (GImage)((GComponent)this).GetChild("frame");
		fluctuation = ((GComponent)this).GetTransition("fluctuation");
	}
}
