using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmpIntroduction;

public class UI_com_GvGAmpIntroductionDialog : GComponent
{
	public Controller Quality;

	public GImage n1;

	public GLoader n18;

	public GLoader Back;

	public GLoader Animation;

	public GComponent AmplifierIcon;

	public GComponent AffectedRange;

	public GTextField n2;

	public GTextField Count;

	public GGroup n7;

	public GImage n9;

	public GTextField n11;

	public GTextField AmpName;

	public GTextField AmpAffectedRangeText;

	public GTextField Property;

	public const string URL = "ui://vt1dz12wkz6b2";

	public static string Name = "UI_com_GvGAmpIntroductionDialog";

	public static string GetURL()
	{
		return "ui://vt1dz12wkz6b2";
	}

	public static UI_com_GvGAmpIntroductionDialog CreateInstance()
	{
		return (UI_com_GvGAmpIntroductionDialog)(object)UIPackage.CreateObject("GvGAmpIntroduction", "com_GvGAmpIntroductionDialog");
	}

	public static UI_com_GvGAmpIntroductionDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GvGAmpIntroductionDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vt1dz12wkz6b2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Quality = ((GComponent)this).GetController("Quality");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n18 = (GLoader)((GComponent)this).GetChild("n18");
		Back = (GLoader)((GComponent)this).GetChild("Back");
		Animation = (GLoader)((GComponent)this).GetChild("Animation");
		AmplifierIcon = (GComponent)((GComponent)this).GetChild("AmplifierIcon");
		AffectedRange = (GComponent)((GComponent)this).GetChild("AffectedRange");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://vt1dz12wkz6b2".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		Count = (GTextField)((GComponent)this).GetChild("Count");
		n7 = (GGroup)((GComponent)this).GetChild("n7");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id2 = "ui://vt1dz12wkz6b2".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id2);
		AmpName = (GTextField)((GComponent)this).GetChild("AmpName");
		AmpAffectedRangeText = (GTextField)((GComponent)this).GetChild("AmpAffectedRangeText");
		Property = (GTextField)((GComponent)this).GetChild("Property");
	}
}
