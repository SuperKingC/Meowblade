using FairyGUI;
using FairyGUI.Utils;

namespace UI.NewbieMission;

public class UI_ArrowBtn : GButton
{
	public Controller button;

	public Controller Type;

	public GGraph n4;

	public GImage n3;

	public GImage redNote;

	public const string URL = "ui://kmmwvr7cu32ta";

	public static string Name = "UI_ArrowBtn";

	public static string GetURL()
	{
		return "ui://kmmwvr7cu32ta";
	}

	public static UI_ArrowBtn CreateInstance()
	{
		return (UI_ArrowBtn)(object)UIPackage.CreateObject("NewbieMission", "ArrowBtn");
	}

	public static UI_ArrowBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ArrowBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kmmwvr7cu32ta", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		redNote = (GImage)((GComponent)this).GetChild("redNote");
	}
}
