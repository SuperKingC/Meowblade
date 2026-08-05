using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOEMResult3;

public class UI_com_ForgeResult : GComponent
{
	public Controller HasAmps;

	public Controller HasExtraBonus;

	public GImage n191;

	public GImage n211;

	public GList Amps;

	public GList Other;

	public UI_btn_ConfirmBtn Confirm;

	public GImage n204;

	public GImage n205;

	public GTextField n206;

	public GTextField n207;

	public GImage n208;

	public GTextField n209;

	public GTextField n210;

	public const string URL = "ui://5k1s1pjxpzxd0";

	public static string Name = "UI_com_ForgeResult";

	public static string GetURL()
	{
		return "ui://5k1s1pjxpzxd0";
	}

	public static UI_com_ForgeResult CreateInstance()
	{
		return (UI_com_ForgeResult)(object)UIPackage.CreateObject("GvGOEMResult3", "com_ForgeResult");
	}

	public static UI_com_ForgeResult CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ForgeResult).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5k1s1pjxpzxd0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasAmps = ((GComponent)this).GetController("HasAmps");
		HasExtraBonus = ((GComponent)this).GetController("HasExtraBonus");
		n191 = (GImage)((GComponent)this).GetChild("n191");
		n211 = (GImage)((GComponent)this).GetChild("n211");
		Amps = (GList)((GComponent)this).GetChild("Amps");
		Other = (GList)((GComponent)this).GetChild("Other");
		Confirm = (UI_btn_ConfirmBtn)(object)((GComponent)this).GetChild("Confirm");
		n204 = (GImage)((GComponent)this).GetChild("n204");
		n205 = (GImage)((GComponent)this).GetChild("n205");
		n206 = (GTextField)((GComponent)this).GetChild("n206");
		string id = "ui://5k1s1pjxpzxd0".Replace("ui://", "") + "-" + ((GObject)n206).id;
		((GObject)n206).text = LanguagesManager.GetDesc(id);
		n207 = (GTextField)((GComponent)this).GetChild("n207");
		string id2 = "ui://5k1s1pjxpzxd0".Replace("ui://", "") + "-" + ((GObject)n207).id;
		((GObject)n207).text = LanguagesManager.GetDesc(id2);
		n208 = (GImage)((GComponent)this).GetChild("n208");
		n209 = (GTextField)((GComponent)this).GetChild("n209");
		string id3 = "ui://5k1s1pjxpzxd0".Replace("ui://", "") + "-" + ((GObject)n209).id;
		((GObject)n209).text = LanguagesManager.GetDesc(id3);
		n210 = (GTextField)((GComponent)this).GetChild("n210");
		string id4 = "ui://5k1s1pjxpzxd0".Replace("ui://", "") + "-" + ((GObject)n210).id;
		((GObject)n210).text = LanguagesManager.GetDesc(id4);
	}
}
