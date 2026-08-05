using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_tbn_ExclamationMarkBtn : GButton
{
	public Controller button;

	public GGraph mask;

	public GMovieClip n8;

	public const string URL = "ui://hozu168rkmsj79";

	public static string Name = "UI_tbn_ExclamationMarkBtn";

	public static string GetURL()
	{
		return "ui://hozu168rkmsj79";
	}

	public static UI_tbn_ExclamationMarkBtn CreateInstance()
	{
		return (UI_tbn_ExclamationMarkBtn)(object)UIPackage.CreateObject("GvGBrawlFight", "tbn_ExclamationMarkBtn");
	}

	public static UI_tbn_ExclamationMarkBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_tbn_ExclamationMarkBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rkmsj79", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		mask = (GGraph)((GComponent)this).GetChild("mask");
		n8 = (GMovieClip)((GComponent)this).GetChild("n8");
	}
}
