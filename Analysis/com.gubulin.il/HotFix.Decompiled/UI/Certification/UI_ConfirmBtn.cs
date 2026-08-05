using FairyGUI;
using FairyGUI.Utils;

namespace UI.Certification;

public class UI_ConfirmBtn : GButton
{
	public Controller button;

	public GImage n16;

	public GImage n17;

	public const string URL = "ui://56q48tcqm13tg";

	public static string Name = "UI_ConfirmBtn";

	public static string GetURL()
	{
		return "ui://56q48tcqm13tg";
	}

	public static UI_ConfirmBtn CreateInstance()
	{
		return (UI_ConfirmBtn)(object)UIPackage.CreateObject("Certification", "ConfirmBtn");
	}

	public static UI_ConfirmBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13tg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GImage)((GComponent)this).GetChild("n17");
	}
}
