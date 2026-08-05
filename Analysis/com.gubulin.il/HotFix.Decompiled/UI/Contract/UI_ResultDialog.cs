using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_ResultDialog : GComponent
{
	public GImage back;

	public GTextField title;

	public GList resultList;

	public UI_ConfirmBtn ConfirmBtn;

	public UI_cancelBtn againBtn;

	public const string URL = "ui://avplaivdpzi2t3p";

	public static string Name = "UI_ResultDialog";

	public static string GetURL()
	{
		return "ui://avplaivdpzi2t3p";
	}

	public static UI_ResultDialog CreateInstance()
	{
		return (UI_ResultDialog)(object)UIPackage.CreateObject("Contract", "ResultDialog");
	}

	public static UI_ResultDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ResultDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdpzi2t3p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://avplaivdpzi2t3p".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		resultList = (GList)((GComponent)this).GetChild("resultList");
		ConfirmBtn = (UI_ConfirmBtn)(object)((GComponent)this).GetChild("ConfirmBtn");
		againBtn = (UI_cancelBtn)(object)((GComponent)this).GetChild("againBtn");
	}
}
