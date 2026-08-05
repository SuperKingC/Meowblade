using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_com_TechResultDialog : GComponent
{
	public GImage back;

	public GImage n5;

	public GTextField title;

	public GList List;

	public GImage n6;

	public UI_btn_Confirm ConfirmBtn;

	public const string URL = "ui://th385mttlgfv1l";

	public static string Name = "UI_com_TechResultDialog";

	public static string GetURL()
	{
		return "ui://th385mttlgfv1l";
	}

	public static UI_com_TechResultDialog CreateInstance()
	{
		return (UI_com_TechResultDialog)(object)UIPackage.CreateObject("GvGOuterTech", "com_TechResultDialog");
	}

	public static UI_com_TechResultDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TechResultDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttlgfv1l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://th385mttlgfv1l".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		List = (GList)((GComponent)this).GetChild("List");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		ConfirmBtn = (UI_btn_Confirm)(object)((GComponent)this).GetChild("ConfirmBtn");
	}
}
