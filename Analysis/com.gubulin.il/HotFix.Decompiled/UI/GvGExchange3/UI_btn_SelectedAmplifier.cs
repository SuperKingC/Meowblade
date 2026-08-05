using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_SelectedAmplifier : GButton
{
	public Controller Selected;

	public UI_com_AmplifierSlot Amplifier;

	public GImage n4;

	public GTextField n5;

	public const string URL = "ui://tt2iq07onhzv19";

	public static string Name = "UI_btn_SelectedAmplifier";

	public static string GetURL()
	{
		return "ui://tt2iq07onhzv19";
	}

	public static UI_btn_SelectedAmplifier CreateInstance()
	{
		return (UI_btn_SelectedAmplifier)(object)UIPackage.CreateObject("GvGExchange3", "btn_SelectedAmplifier");
	}

	public static UI_btn_SelectedAmplifier CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SelectedAmplifier).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07onhzv19", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Selected = ((GComponent)this).GetController("Selected");
		Amplifier = (UI_com_AmplifierSlot)(object)((GComponent)this).GetChild("Amplifier");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://tt2iq07onhzv19".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}
