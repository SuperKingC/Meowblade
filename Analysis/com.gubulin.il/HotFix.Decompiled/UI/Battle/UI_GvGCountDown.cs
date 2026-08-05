using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_GvGCountDown : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n4;

	public GTextField Time;

	public const string URL = "ui://twlbabiccvfml4";

	public static string Name = "UI_GvGCountDown";

	public static string GetURL()
	{
		return "ui://twlbabiccvfml4";
	}

	public static UI_GvGCountDown CreateInstance()
	{
		return (UI_GvGCountDown)(object)UIPackage.CreateObject("Battle", "GvGCountDown");
	}

	public static UI_GvGCountDown CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGCountDown).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabiccvfml4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Time = (GTextField)((GComponent)this).GetChild("Time");
		string id = "ui://twlbabiccvfml4".Replace("ui://", "") + "-" + ((GObject)Time).id;
		((GObject)Time).text = LanguagesManager.GetDesc(id);
	}
}
