using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_BonusDetailBtn : GButton
{
	public Controller button;

	public GImage n4;

	public GImage n3;

	public const string URL = "ui://0i520nzmo3e9o8n";

	public static string Name = "UI_BonusDetailBtn";

	public static string GetURL()
	{
		return "ui://0i520nzmo3e9o8n";
	}

	public static UI_BonusDetailBtn CreateInstance()
	{
		return (UI_BonusDetailBtn)(object)UIPackage.CreateObject("LordOfDreams", "BonusDetailBtn");
	}

	public static UI_BonusDetailBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BonusDetailBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmo3e9o8n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
