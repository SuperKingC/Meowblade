using FairyGUI;
using FairyGUI.Utils;

namespace UI.Playback;

public class UI_PlayBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n4;

	public GImage n5;

	public const string URL = "ui://9u6qpm6pt6gc6";

	public static string Name = "UI_PlayBtn";

	public static string GetURL()
	{
		return "ui://9u6qpm6pt6gc6";
	}

	public static UI_PlayBtn CreateInstance()
	{
		return (UI_PlayBtn)(object)UIPackage.CreateObject("Playback", "PlayBtn");
	}

	public static UI_PlayBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PlayBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://9u6qpm6pt6gc6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
