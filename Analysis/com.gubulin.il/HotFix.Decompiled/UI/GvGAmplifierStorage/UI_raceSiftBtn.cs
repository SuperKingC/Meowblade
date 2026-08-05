using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierStorage;

public class UI_raceSiftBtn : GButton
{
	public Controller button;

	public Controller Type;

	public GLoader n3;

	public GImage n4;

	public const string URL = "ui://fwpu3639kx8l1b";

	public static string Name = "UI_raceSiftBtn";

	public static string GetURL()
	{
		return "ui://fwpu3639kx8l1b";
	}

	public static UI_raceSiftBtn CreateInstance()
	{
		return (UI_raceSiftBtn)(object)UIPackage.CreateObject("GvGAmplifierStorage", "raceSiftBtn");
	}

	public static UI_raceSiftBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_raceSiftBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fwpu3639kx8l1b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n3 = (GLoader)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
