using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_com_RubyOutline : GComponent
{
	public GImage n2;

	public GMovieClip n3;

	public GMovieClip n4;

	public GImage n1;

	public Transition t0;

	public const string URL = "ui://zko5n3veoymgev";

	public static string Name = "UI_com_RubyOutline";

	public static string GetURL()
	{
		return "ui://zko5n3veoymgev";
	}

	public static UI_com_RubyOutline CreateInstance()
	{
		return (UI_com_RubyOutline)(object)UIPackage.CreateObject("PrinceOfTheDevils", "com_RubyOutline");
	}

	public static UI_com_RubyOutline CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RubyOutline).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3veoymgev", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GMovieClip)((GComponent)this).GetChild("n3");
		n4 = (GMovieClip)((GComponent)this).GetChild("n4");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
