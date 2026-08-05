using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_consumption : GComponent
{
	public GRichTextField consumeNum;

	public GLoader icon;

	public GLoader frame;

	public GLoader back;

	public GGroup n14;

	public GTextField n16;

	public const string URL = "ui://47lbpgx9ic7j31";

	public static string Name = "UI_consumption";

	public static string GetURL()
	{
		return "ui://47lbpgx9ic7j31";
	}

	public static UI_consumption CreateInstance()
	{
		return (UI_consumption)(object)UIPackage.CreateObject("Tips", "consumption");
	}

	public static UI_consumption CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_consumption).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9ic7j31", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		consumeNum = (GRichTextField)((GComponent)this).GetChild("consumeNum");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		back = (GLoader)((GComponent)this).GetChild("back");
		n14 = (GGroup)((GComponent)this).GetChild("n14");
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id = "ui://47lbpgx9ic7j31".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id);
	}
}
