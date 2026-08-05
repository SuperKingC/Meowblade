using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_getTip : GButton
{
	public Controller button;

	public GRichTextField title;

	public const string URL = "ui://edr57v33oipis";

	public static string Name = "UI_getTip";

	public static string GetURL()
	{
		return "ui://edr57v33oipis";
	}

	public static UI_getTip CreateInstance()
	{
		return (UI_getTip)(object)UIPackage.CreateObject("Mail", "getTip");
	}

	public static UI_getTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_getTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33oipis", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		title = (GRichTextField)((GComponent)this).GetChild("title");
	}
}
