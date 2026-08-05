using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpPropGrade;

public class UI_DialogLeftContent : GComponent
{
	public Controller PageSwitch;

	public GImage lineLight0;

	public GImage lineLight1;

	public GImage lineLight2;

	public GImage linecircle0;

	public GImage linecircle1;

	public GImage linecircle2;

	public UI_Product Product;

	public UI_Material MaterialItem0;

	public UI_Material MaterialItem1;

	public UI_Material MaterialItem2;

	public GTextField n11;

	public Transition t0;

	public const string URL = "ui://blindbbgmol0n";

	public static string Name = "UI_DialogLeftContent";

	public static string GetURL()
	{
		return "ui://blindbbgmol0n";
	}

	public static UI_DialogLeftContent CreateInstance()
	{
		return (UI_DialogLeftContent)(object)UIPackage.CreateObject("UpPropGrade", "DialogLeftContent");
	}

	public static UI_DialogLeftContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DialogLeftContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgmol0n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageSwitch = ((GComponent)this).GetController("PageSwitch");
		lineLight0 = (GImage)((GComponent)this).GetChild("lineLight0");
		lineLight1 = (GImage)((GComponent)this).GetChild("lineLight1");
		lineLight2 = (GImage)((GComponent)this).GetChild("lineLight2");
		linecircle0 = (GImage)((GComponent)this).GetChild("linecircle0");
		linecircle1 = (GImage)((GComponent)this).GetChild("linecircle1");
		linecircle2 = (GImage)((GComponent)this).GetChild("linecircle2");
		Product = (UI_Product)(object)((GComponent)this).GetChild("Product");
		MaterialItem0 = (UI_Material)(object)((GComponent)this).GetChild("MaterialItem0");
		MaterialItem1 = (UI_Material)(object)((GComponent)this).GetChild("MaterialItem1");
		MaterialItem2 = (UI_Material)(object)((GComponent)this).GetChild("MaterialItem2");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://blindbbgmol0n".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
