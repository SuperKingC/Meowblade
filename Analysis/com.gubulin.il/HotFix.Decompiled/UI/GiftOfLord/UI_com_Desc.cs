using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GiftOfLord;

public class UI_com_Desc : GComponent
{
	public GImage n0;

	public GImage n2;

	public GImage n4;

	public GMovieClip n5;

	public GMovieClip n6;

	public GImage n1;

	public GTextField n3;

	public Transition t0;

	public const string URL = "ui://nz2z1ab8t0xze";

	public static string Name = "UI_com_Desc";

	public static string GetURL()
	{
		return "ui://nz2z1ab8t0xze";
	}

	public static UI_com_Desc CreateInstance()
	{
		return (UI_com_Desc)(object)UIPackage.CreateObject("GiftOfLord", "com_Desc");
	}

	public static UI_com_Desc CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Desc).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://nz2z1ab8t0xze", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GMovieClip)((GComponent)this).GetChild("n5");
		n6 = (GMovieClip)((GComponent)this).GetChild("n6");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://nz2z1ab8t0xze".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
