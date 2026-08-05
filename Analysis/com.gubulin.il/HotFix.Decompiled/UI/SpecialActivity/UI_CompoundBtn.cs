using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_CompoundBtn : GButton
{
	public Controller button;

	public GImage n6;

	public GImage n12;

	public const string URL = "ui://kozswd8hndjaw";

	public static string Name = "UI_CompoundBtn";

	public static string GetURL()
	{
		return "ui://kozswd8hndjaw";
	}

	public static UI_CompoundBtn CreateInstance()
	{
		return (UI_CompoundBtn)(object)UIPackage.CreateObject("SpecialActivity", "CompoundBtn");
	}

	public static UI_CompoundBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CompoundBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hndjaw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n12 = (GImage)((GComponent)this).GetChild("n12");
	}
}
