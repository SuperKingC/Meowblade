using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_CampOverview : GButton
{
	public Controller Camp;

	public GLoader n0;

	public GLoader n1;

	public GTextField n2;

	public const string URL = "ui://4eq8fgd2qf7c76";

	public static string Name = "UI_btn_CampOverview";

	public static string GetURL()
	{
		return "ui://4eq8fgd2qf7c76";
	}

	public static UI_btn_CampOverview CreateInstance()
	{
		return (UI_btn_CampOverview)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_CampOverview");
	}

	public static UI_btn_CampOverview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CampOverview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2qf7c76", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		n0 = (GLoader)((GComponent)this).GetChild("n0");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://4eq8fgd2qf7c76".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
	}
}
