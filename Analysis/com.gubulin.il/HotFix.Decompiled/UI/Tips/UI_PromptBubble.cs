using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_PromptBubble : GComponent
{
	public GImage n10;

	public GTextField n11;

	public GLoader n12;

	public GGroup n13;

	public const string URL = "ui://47lbpgx9bp0rj5ltf7";

	public static string Name = "UI_PromptBubble";

	public static string GetURL()
	{
		return "ui://47lbpgx9bp0rj5ltf7";
	}

	public static UI_PromptBubble CreateInstance()
	{
		return (UI_PromptBubble)(object)UIPackage.CreateObject("Tips", "PromptBubble");
	}

	public static UI_PromptBubble CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PromptBubble).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9bp0rj5ltf7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://47lbpgx9bp0rj5ltf7".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
		n12 = (GLoader)((GComponent)this).GetChild("n12");
		n13 = (GGroup)((GComponent)this).GetChild("n13");
	}
}
