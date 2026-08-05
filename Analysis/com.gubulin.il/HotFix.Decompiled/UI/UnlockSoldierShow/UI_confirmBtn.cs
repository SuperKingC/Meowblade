using FairyGUI;
using FairyGUI.Utils;

namespace UI.UnlockSoldierShow;

public class UI_confirmBtn : GButton
{
	public Controller button;

	public GImage background;

	public GImage title;

	public const string URL = "ui://ia1am3ehgf0n8";

	public static string Name = "UI_confirmBtn";

	public static string GetURL()
	{
		return "ui://ia1am3ehgf0n8";
	}

	public static UI_confirmBtn CreateInstance()
	{
		return (UI_confirmBtn)(object)UIPackage.CreateObject("UnlockSoldierShow", "confirmBtn");
	}

	public static UI_confirmBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_confirmBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ia1am3ehgf0n8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		title = (GImage)((GComponent)this).GetChild("title");
	}
}
