using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_RedDot : GComponent
{
	public GImage redPoint;

	public Transition jump;

	public const string URL = "ui://zko5n3veudxqdz";

	public static string Name = "UI_RedDot";

	public static string GetURL()
	{
		return "ui://zko5n3veudxqdz";
	}

	public static UI_RedDot CreateInstance()
	{
		return (UI_RedDot)(object)UIPackage.CreateObject("PrinceOfTheDevils", "RedDot");
	}

	public static UI_RedDot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RedDot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3veudxqdz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		redPoint = (GImage)((GComponent)this).GetChild("redPoint");
		jump = ((GComponent)this).GetTransition("jump");
	}
}
