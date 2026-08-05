using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_Com_StoryInfo : GComponent
{
	public GGraph n0;

	public GImage n1;

	public GImage n2;

	public GTextField LevelName;

	public GTextField ChapterName;

	public GImage n6;

	public GImage n7;

	public GImage n3;

	public Transition t0;

	public const string URL = "ui://twlbabicujdzp2";

	public static string Name = "UI_Com_StoryInfo";

	public static string GetURL()
	{
		return "ui://twlbabicujdzp2";
	}

	public static UI_Com_StoryInfo CreateInstance()
	{
		return (UI_Com_StoryInfo)(object)UIPackage.CreateObject("Battle", "Com_StoryInfo");
	}

	public static UI_Com_StoryInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Com_StoryInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicujdzp2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		LevelName = (GTextField)((GComponent)this).GetChild("LevelName");
		ChapterName = (GTextField)((GComponent)this).GetChild("ChapterName");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
