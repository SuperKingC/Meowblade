using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_legionScale : GButton
{
	public Controller button;

	public UI_com_RubyOutline highlight;

	public GImage n10;

	public GGraph SfxBack;

	public UI_RedDot redPoint;

	public const string URL = "ui://zko5n3vepewcx";

	public static string Name = "UI_legionScale";

	public static string GetURL()
	{
		return "ui://zko5n3vepewcx";
	}

	public static UI_legionScale CreateInstance()
	{
		return (UI_legionScale)(object)UIPackage.CreateObject("PrinceOfTheDevils", "legionScale");
	}

	public static UI_legionScale CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_legionScale).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3vepewcx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		highlight = (UI_com_RubyOutline)(object)((GComponent)this).GetChild("highlight");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		redPoint = (UI_RedDot)(object)((GComponent)this).GetChild("redPoint");
	}
}
