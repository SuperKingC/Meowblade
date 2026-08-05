using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_com_ResTip : GComponent
{
	public GImage n4;

	public GTextField ResRemain;

	public GTextField n2;

	public GTextField ResTotal;

	public const string URL = "ui://p4ocf6q0ubyv1p";

	public static string Name = "UI_com_ResTip";

	public static string GetURL()
	{
		return "ui://p4ocf6q0ubyv1p";
	}

	public static UI_com_ResTip CreateInstance()
	{
		return (UI_com_ResTip)(object)UIPackage.CreateObject("GvGRandomEvent3", "com_ResTip");
	}

	public static UI_com_ResTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ResTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0ubyv1p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		ResRemain = (GTextField)((GComponent)this).GetChild("ResRemain");
		string id = "ui://p4ocf6q0ubyv1p".Replace("ui://", "") + "-" + ((GObject)ResRemain).id;
		((GObject)ResRemain).text = LanguagesManager.GetDesc(id);
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		ResTotal = (GTextField)((GComponent)this).GetChild("ResTotal");
		string id2 = "ui://p4ocf6q0ubyv1p".Replace("ui://", "") + "-" + ((GObject)ResTotal).id;
		((GObject)ResTotal).text = LanguagesManager.GetDesc(id2);
	}
}
