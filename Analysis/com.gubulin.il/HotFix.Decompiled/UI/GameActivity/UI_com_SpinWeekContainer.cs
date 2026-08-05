using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_SpinWeekContainer : GComponent
{
	public Controller Type;

	public GLoader pageLoader;

	public Transition t7;

	public Transition t8;

	public Transition t9;

	public Transition t10;

	public const string URL = "ui://29q48tv6ku17f6i";

	public static string Name = "UI_com_SpinWeekContainer";

	public static string GetURL()
	{
		return "ui://29q48tv6ku17f6i";
	}

	public static UI_com_SpinWeekContainer CreateInstance()
	{
		return (UI_com_SpinWeekContainer)(object)UIPackage.CreateObject("GameActivity", "com_SpinWeekContainer");
	}

	public static UI_com_SpinWeekContainer CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SpinWeekContainer).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6ku17f6i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		pageLoader = (GLoader)((GComponent)this).GetChild("pageLoader");
		t7 = ((GComponent)this).GetTransition("t7");
		t8 = ((GComponent)this).GetTransition("t8");
		t9 = ((GComponent)this).GetTransition("t9");
		t10 = ((GComponent)this).GetTransition("t10");
	}
}
