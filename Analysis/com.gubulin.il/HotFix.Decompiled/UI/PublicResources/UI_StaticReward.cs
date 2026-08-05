using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_StaticReward : GButton
{
	public Controller button;

	public Controller Type;

	public GImage Bg;

	public GGraph fxBack;

	public GLoader icon;

	public GRichTextField title;

	public GImage newLogo;

	public GImage chipNote;

	public UI_ExclamationMarkBtn ExclamationMarkBtn;

	public Transition ShowSelf;

	public const string URL = "ui://kt6rg65ovv0ue5";

	public static string Name = "UI_StaticReward";

	public static string GetURL()
	{
		return "ui://kt6rg65ovv0ue5";
	}

	public static UI_StaticReward CreateInstance()
	{
		return (UI_StaticReward)(object)UIPackage.CreateObject("PublicResources", "StaticReward");
	}

	public static UI_StaticReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_StaticReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovv0ue5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		Bg = (GImage)((GComponent)this).GetChild("Bg");
		fxBack = (GGraph)((GComponent)this).GetChild("fxBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		newLogo = (GImage)((GComponent)this).GetChild("newLogo");
		chipNote = (GImage)((GComponent)this).GetChild("chipNote");
		ExclamationMarkBtn = (UI_ExclamationMarkBtn)(object)((GComponent)this).GetChild("ExclamationMarkBtn");
		ShowSelf = ((GComponent)this).GetTransition("ShowSelf");
	}
}
