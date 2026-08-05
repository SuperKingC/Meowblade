using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_LevelIcon : GComponent
{
	public Controller button;

	public Controller PageController;

	public GImage frame1;

	public GImage frame0;

	public UI_WaveMask WaveMask;

	public GImage I40001_SP;

	public GImage I40001;

	public GTextField num;

	public GGraph SfxBack;

	public Transition Disapear;

	public const string URL = "ui://c9n2h0ksm7wz8z";

	public static string Name = "UI_LevelIcon";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz8z";
	}

	public static UI_LevelIcon CreateInstance()
	{
		return (UI_LevelIcon)(object)UIPackage.CreateObject("WorldMap", "LevelIcon");
	}

	public static UI_LevelIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LevelIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz8z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		PageController = ((GComponent)this).GetController("PageController");
		frame1 = (GImage)((GComponent)this).GetChild("frame1");
		frame0 = (GImage)((GComponent)this).GetChild("frame0");
		WaveMask = (UI_WaveMask)(object)((GComponent)this).GetChild("WaveMask");
		I40001_SP = (GImage)((GComponent)this).GetChild("I40001_SP");
		I40001 = (GImage)((GComponent)this).GetChild("I40001");
		num = (GTextField)((GComponent)this).GetChild("num");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		Disapear = ((GComponent)this).GetTransition("Disapear");
	}
}
