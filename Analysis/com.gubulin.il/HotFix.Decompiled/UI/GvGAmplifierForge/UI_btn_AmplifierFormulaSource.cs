using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierForge;

public class UI_btn_AmplifierFormulaSource : GButton
{
	public Controller GotoBtnDisplaying;

	public GImage n2;

	public GTextField Source;

	public GImage n4;

	public GTextField n5;

	public const string URL = "ui://fpjheycbqvpvv4g5";

	public static string Name = "UI_btn_AmplifierFormulaSource";

	public static string GetURL()
	{
		return "ui://fpjheycbqvpvv4g5";
	}

	public static UI_btn_AmplifierFormulaSource CreateInstance()
	{
		return (UI_btn_AmplifierFormulaSource)(object)UIPackage.CreateObject("GvGAmplifierForge", "btn_AmplifierFormulaSource");
	}

	public static UI_btn_AmplifierFormulaSource CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_AmplifierFormulaSource).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbqvpvv4g5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		GotoBtnDisplaying = ((GComponent)this).GetController("GotoBtnDisplaying");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		Source = (GTextField)((GComponent)this).GetChild("Source");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://fpjheycbqvpvv4g5".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}
