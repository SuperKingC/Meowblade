using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.QQGameActivityMainCity;

public class UI_AgreementCom : GComponent
{
	public UI_btn_01 n0;

	public GTextField n2;

	public UI_btn_02 n3;

	public GTextField n4;

	public UI_btn_03 n5;

	public const string URL = "ui://z947bpf8k09cv45u";

	public static string Name = "UI_AgreementCom";

	public static string GetURL()
	{
		return "ui://z947bpf8k09cv45u";
	}

	public static UI_AgreementCom CreateInstance()
	{
		return (UI_AgreementCom)(object)UIPackage.CreateObject("QQGameActivityMainCity", "AgreementCom");
	}

	public static UI_AgreementCom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AgreementCom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://z947bpf8k09cv45u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (UI_btn_01)(object)((GComponent)this).GetChild("n0");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://z947bpf8k09cv45u".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		n3 = (UI_btn_02)(object)((GComponent)this).GetChild("n3");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://z947bpf8k09cv45u".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		n5 = (UI_btn_03)(object)((GComponent)this).GetChild("n5");
	}
}
