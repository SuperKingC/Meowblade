using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_GoToLegion : GButton
{
	public Controller button;

	public GImage Bg;

	public GLoader icon;

	public GRichTextField title;

	public GImage n4;

	public Transition t0;

	public const string URL = "ui://82mo10n5hcbs70";

	public static string Name = "UI_GoToLegion";

	public static string GetURL()
	{
		return "ui://82mo10n5hcbs70";
	}

	public static UI_GoToLegion CreateInstance()
	{
		return (UI_GoToLegion)(object)UIPackage.CreateObject("PvpSelectSoldiers", "GoToLegion");
	}

	public static UI_GoToLegion CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GoToLegion).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5hcbs70", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Bg = (GImage)((GComponent)this).GetChild("Bg");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://82mo10n5hcbs70".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
