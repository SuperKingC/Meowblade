using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_Com_NeutralContractTimes : GComponent
{
	public Controller c1;

	public Controller c2;

	public GImage n1;

	public GImage n2;

	public GTextField n3;

	public const string URL = "ui://f4wr270rgq2l7x";

	public static string Name = "UI_Com_NeutralContractTimes";

	public static string GetURL()
	{
		return "ui://f4wr270rgq2l7x";
	}

	public static UI_Com_NeutralContractTimes CreateInstance()
	{
		return (UI_Com_NeutralContractTimes)(object)UIPackage.CreateObject("InstanceZones", "Com_NeutralContractTimes");
	}

	public static UI_Com_NeutralContractTimes CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Com_NeutralContractTimes).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rgq2l7x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		c2 = ((GComponent)this).GetController("c2");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://f4wr270rgq2l7x".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
	}
}
