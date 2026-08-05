using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.EnemyIntroduction;

public class UI_LegendItemSlot : GButton
{
	public Controller button;

	public Controller Type;

	public GButton Icon;

	public GImage n4;

	public GTextField Tip;

	public GGraph sfxBack;

	public const string URL = "ui://rn232z3erqrej7";

	public static string Name = "UI_LegendItemSlot";

	public static string GetURL()
	{
		return "ui://rn232z3erqrej7";
	}

	public static UI_LegendItemSlot CreateInstance()
	{
		return (UI_LegendItemSlot)(object)UIPackage.CreateObject("EnemyIntroduction", "LegendItemSlot");
	}

	public static UI_LegendItemSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rn232z3erqrej7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		Icon = (GButton)((GComponent)this).GetChild("Icon");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id = "ui://rn232z3erqrej7".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id);
		sfxBack = (GGraph)((GComponent)this).GetChild("sfxBack");
	}
}
