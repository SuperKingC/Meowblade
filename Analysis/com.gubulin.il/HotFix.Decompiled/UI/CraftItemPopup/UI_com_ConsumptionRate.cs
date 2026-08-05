using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.CraftItemPopup;

public class UI_com_ConsumptionRate : GComponent
{
	public GTextField n16;

	public GLoader InputItemIcon;

	public GRichTextField InputRate;

	public GLoader OutputItemIcon;

	public GRichTextField OutputRate;

	public GImage n23;

	public const string URL = "ui://4pn38ozniuish";

	public static string Name = "UI_com_ConsumptionRate";

	public static string GetURL()
	{
		return "ui://4pn38ozniuish";
	}

	public static UI_com_ConsumptionRate CreateInstance()
	{
		return (UI_com_ConsumptionRate)(object)UIPackage.CreateObject("CraftItemPopup", "com_ConsumptionRate");
	}

	public static UI_com_ConsumptionRate CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ConsumptionRate).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4pn38ozniuish", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id = "ui://4pn38ozniuish".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id);
		InputItemIcon = (GLoader)((GComponent)this).GetChild("InputItemIcon");
		InputRate = (GRichTextField)((GComponent)this).GetChild("InputRate");
		OutputItemIcon = (GLoader)((GComponent)this).GetChild("OutputItemIcon");
		OutputRate = (GRichTextField)((GComponent)this).GetChild("OutputRate");
		n23 = (GImage)((GComponent)this).GetChild("n23");
	}
}
