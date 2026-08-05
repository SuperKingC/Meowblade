using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_Ability : GComponent
{
	public Controller IsNew;

	public GComponent icon;

	public GImage n5;

	public GTextField LvNum;

	public GImage n3;

	public const string URL = "ui://249h3k3dzit42s";

	public static string Name = "UI_com_Ability";

	public static string GetURL()
	{
		return "ui://249h3k3dzit42s";
	}

	public static UI_com_Ability CreateInstance()
	{
		return (UI_com_Ability)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_Ability");
	}

	public static UI_com_Ability CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Ability).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dzit42s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsNew = ((GComponent)this).GetController("IsNew");
		icon = (GComponent)((GComponent)this).GetChild("icon");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		LvNum = (GTextField)((GComponent)this).GetChild("LvNum");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
