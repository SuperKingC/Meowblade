using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_FireSupportConfirmDialog : GComponent
{
	public GImage back;

	public GImage n29;

	public GTextField n28;

	public GTextField n39;

	public GTextField n36;

	public GTextField n41;

	public GTextField TimeOfUsage;

	public GGroup n43;

	public GButton Buff;

	public UI_btn_yes Confirm;

	public const string URL = "ui://4eq8fgd2lpif6scj";

	public static string Name = "UI_com_FireSupportConfirmDialog";

	public static string GetURL()
	{
		return "ui://4eq8fgd2lpif6scj";
	}

	public static UI_com_FireSupportConfirmDialog CreateInstance()
	{
		return (UI_com_FireSupportConfirmDialog)(object)UIPackage.CreateObject("GvGWorldMap3", "com_FireSupportConfirmDialog");
	}

	public static UI_com_FireSupportConfirmDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FireSupportConfirmDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2lpif6scj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id = "ui://4eq8fgd2lpif6scj".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id);
		n39 = (GTextField)((GComponent)this).GetChild("n39");
		string id2 = "ui://4eq8fgd2lpif6scj".Replace("ui://", "") + "-" + ((GObject)n39).id;
		((GObject)n39).text = LanguagesManager.GetDesc(id2);
		n36 = (GTextField)((GComponent)this).GetChild("n36");
		string id3 = "ui://4eq8fgd2lpif6scj".Replace("ui://", "") + "-" + ((GObject)n36).id;
		((GObject)n36).text = LanguagesManager.GetDesc(id3);
		n41 = (GTextField)((GComponent)this).GetChild("n41");
		string id4 = "ui://4eq8fgd2lpif6scj".Replace("ui://", "") + "-" + ((GObject)n41).id;
		((GObject)n41).text = LanguagesManager.GetDesc(id4);
		TimeOfUsage = (GTextField)((GComponent)this).GetChild("TimeOfUsage");
		n43 = (GGroup)((GComponent)this).GetChild("n43");
		Buff = (GButton)((GComponent)this).GetChild("Buff");
		Confirm = (UI_btn_yes)(object)((GComponent)this).GetChild("Confirm");
	}
}
