using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpgradePotential;

public class UI_confirmBtn : GButton
{
	public Controller button;

	public GImage background;

	public GLoader n5;

	public const string URL = "ui://l5ik1uclic7jt7y";

	public static string Name = "UI_confirmBtn";

	public static string GetURL()
	{
		return "ui://l5ik1uclic7jt7y";
	}

	public static UI_confirmBtn CreateInstance()
	{
		return (UI_confirmBtn)(object)UIPackage.CreateObject("UpgradePotential", "confirmBtn");
	}

	public static UI_confirmBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_confirmBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l5ik1uclic7jt7y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		background = (GImage)((GComponent)this).GetChild("background");
		n5 = (GLoader)((GComponent)this).GetChild("n5");
	}
}
