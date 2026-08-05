using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_FormationBtn : GButton
{
	public Controller controll;

	public Controller Status;

	public UI_Content Contentfake;

	public UI_Content Content;

	public GImage note;

	public GButton ConsumptionItem;

	public UI_Btn_02 ChangeBtn;

	public UI_Btn_01 UnlockBtn;

	public GGroup n40;

	public GGraph SfxBack;

	public Transition Expand;

	public Transition ShowContent;

	public const string URL = "ui://twlbabicx61yn";

	public static string Name = "UI_FormationBtn";

	public static string GetURL()
	{
		return "ui://twlbabicx61yn";
	}

	public static UI_FormationBtn CreateInstance()
	{
		return (UI_FormationBtn)(object)UIPackage.CreateObject("Battle", "FormationBtn");
	}

	public static UI_FormationBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FormationBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicx61yn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		controll = ((GComponent)this).GetController("controll");
		Status = ((GComponent)this).GetController("Status");
		Contentfake = (UI_Content)(object)((GComponent)this).GetChild("Contentfake");
		Content = (UI_Content)(object)((GComponent)this).GetChild("Content");
		note = (GImage)((GComponent)this).GetChild("note");
		ConsumptionItem = (GButton)((GComponent)this).GetChild("ConsumptionItem");
		ChangeBtn = (UI_Btn_02)(object)((GComponent)this).GetChild("ChangeBtn");
		UnlockBtn = (UI_Btn_01)(object)((GComponent)this).GetChild("UnlockBtn");
		n40 = (GGroup)((GComponent)this).GetChild("n40");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		Expand = ((GComponent)this).GetTransition("Expand");
		ShowContent = ((GComponent)this).GetTransition("ShowContent");
	}
}
