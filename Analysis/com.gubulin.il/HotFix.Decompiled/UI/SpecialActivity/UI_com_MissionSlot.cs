using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_com_MissionSlot : GComponent
{
	public UI_com_MissionSlotContent Content;

	public Transition RemoveTrans;

	public const string URL = "ui://kozswd8hiqdsf32";

	public static string Name = "UI_com_MissionSlot";

	public static string GetURL()
	{
		return "ui://kozswd8hiqdsf32";
	}

	public static UI_com_MissionSlot CreateInstance()
	{
		return (UI_com_MissionSlot)(object)UIPackage.CreateObject("SpecialActivity", "com_MissionSlot");
	}

	public static UI_com_MissionSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MissionSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hiqdsf32", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		Content = (UI_com_MissionSlotContent)(object)((GComponent)this).GetChild("Content");
		RemoveTrans = ((GComponent)this).GetTransition("RemoveTrans");
	}
}
