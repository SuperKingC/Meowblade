using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Medal;

public class UI_btn_ChangeMedal : GButton
{
	public Controller button;

	public GImage n3;

	public GTextField n4;

	public const string URL = "ui://g5hi1peosxgwy";

	public static string Name = "UI_btn_ChangeMedal";

	public static string GetURL()
	{
		return "ui://g5hi1peosxgwy";
	}

	public static UI_btn_ChangeMedal CreateInstance()
	{
		return (UI_btn_ChangeMedal)(object)UIPackage.CreateObject("GvG3Medal", "btn_ChangeMedal");
	}

	public static UI_btn_ChangeMedal CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ChangeMedal).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peosxgwy", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://g5hi1peosxgwy".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
	}
}
