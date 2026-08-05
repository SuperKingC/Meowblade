using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_AgreementTip : GComponent
{
	public Controller UseLargeText;

	public GRichTextField tip;

	public GRichTextField tip0;

	public GRichTextField tip1;

	public GRichTextField tip2;

	public GGroup n4;

	public const string URL = "ui://yb3s7uv7ithf2t";

	public static string Name = "UI_AgreementTip";

	public static string GetURL()
	{
		return "ui://yb3s7uv7ithf2t";
	}

	public static UI_AgreementTip CreateInstance()
	{
		return (UI_AgreementTip)(object)UIPackage.CreateObject("LoginAndName", "AgreementTip");
	}

	public static UI_AgreementTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AgreementTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7ithf2t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		UseLargeText = ((GComponent)this).GetController("UseLargeText");
		tip = (GRichTextField)((GComponent)this).GetChild("tip");
		string id = "ui://yb3s7uv7ithf2t".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		tip0 = (GRichTextField)((GComponent)this).GetChild("tip0");
		string id2 = "ui://yb3s7uv7ithf2t".Replace("ui://", "") + "-" + ((GObject)tip0).id;
		((GObject)tip0).text = LanguagesManager.GetDesc(id2);
		tip1 = (GRichTextField)((GComponent)this).GetChild("tip1");
		string id3 = "ui://yb3s7uv7ithf2t".Replace("ui://", "") + "-" + ((GObject)tip1).id;
		((GObject)tip1).text = LanguagesManager.GetDesc(id3);
		tip2 = (GRichTextField)((GComponent)this).GetChild("tip2");
		string id4 = "ui://yb3s7uv7ithf2t".Replace("ui://", "") + "-" + ((GObject)tip2).id;
		((GObject)tip2).text = LanguagesManager.GetDesc(id4);
		n4 = (GGroup)((GComponent)this).GetChild("n4");
	}
}
