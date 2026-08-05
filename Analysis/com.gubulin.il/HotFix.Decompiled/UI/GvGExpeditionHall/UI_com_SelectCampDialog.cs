using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_SelectCampDialog : GComponent
{
	public GImage tipBack;

	public GTextField n1;

	public GButton CloseBtn;

	public GList CampList;

	public UI_btn_ConfirmCampBtn ConfirmCampBtn;

	public const string URL = "ui://k19peou7dnvl1z";

	public static string Name = "UI_com_SelectCampDialog";

	public static string GetURL()
	{
		return "ui://k19peou7dnvl1z";
	}

	public static UI_com_SelectCampDialog CreateInstance()
	{
		return (UI_com_SelectCampDialog)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_SelectCampDialog");
	}

	public static UI_com_SelectCampDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SelectCampDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7dnvl1z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		tipBack = (GImage)((GComponent)this).GetChild("tipBack");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://k19peou7dnvl1z".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		CloseBtn = (GButton)((GComponent)this).GetChild("CloseBtn");
		CampList = (GList)((GComponent)this).GetChild("CampList");
		ConfirmCampBtn = (UI_btn_ConfirmCampBtn)(object)((GComponent)this).GetChild("ConfirmCampBtn");
	}
}
