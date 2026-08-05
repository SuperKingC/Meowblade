using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_startMessageBtn : GButton
{
	public Controller button;

	public GGraph n4;

	public GImage n3;

	public GLoader icon;

	public const string URL = "ui://edr57v33gx8u3u";

	public static string Name = "UI_startMessageBtn";

	public static string GetURL()
	{
		return "ui://edr57v33gx8u3u";
	}

	public static UI_startMessageBtn CreateInstance()
	{
		return (UI_startMessageBtn)(object)UIPackage.CreateObject("Mail", "startMessageBtn");
	}

	public static UI_startMessageBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_startMessageBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33gx8u3u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
