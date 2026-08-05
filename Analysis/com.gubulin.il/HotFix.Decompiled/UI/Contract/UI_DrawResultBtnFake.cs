using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_DrawResultBtnFake : GButton
{
	public Controller button;

	public Controller PageController;

	public GLoader icon;

	public GTextField name;

	public GTextField num;

	public GImage newIcon;

	public GImage n9;

	public GComponent curLevel;

	public GTextField tip1;

	public Transition bounce;

	public const string URL = "ui://avplaivdv93kt3n";

	public static string Name = "UI_DrawResultBtnFake";

	public static string GetURL()
	{
		return "ui://avplaivdv93kt3n";
	}

	public static UI_DrawResultBtnFake CreateInstance()
	{
		return (UI_DrawResultBtnFake)(object)UIPackage.CreateObject("Contract", "DrawResultBtnFake");
	}

	public static UI_DrawResultBtnFake CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DrawResultBtnFake).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdv93kt3n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		PageController = ((GComponent)this).GetController("PageController");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		name = (GTextField)((GComponent)this).GetChild("name");
		string id = "ui://avplaivdv93kt3n".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id);
		num = (GTextField)((GComponent)this).GetChild("num");
		newIcon = (GImage)((GComponent)this).GetChild("newIcon");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		curLevel = (GComponent)((GComponent)this).GetChild("curLevel");
		tip1 = (GTextField)((GComponent)this).GetChild("tip1");
		string id2 = "ui://avplaivdv93kt3n".Replace("ui://", "") + "-" + ((GObject)tip1).id;
		((GObject)tip1).text = LanguagesManager.GetDesc(id2);
		bounce = ((GComponent)this).GetTransition("bounce");
	}
}
