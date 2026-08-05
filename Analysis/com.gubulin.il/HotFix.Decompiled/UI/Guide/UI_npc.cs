using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Guide;

public class UI_npc : GComponent
{
	public GGraph background;

	public GRichTextField nickName;

	public GImage n23;

	public GLoader avatar;

	public GImage n25;

	public Transition showup;

	public const string URL = "ui://5vxjvcrbg6t9t";

	public static string Name = "UI_npc";

	public static string GetURL()
	{
		return "ui://5vxjvcrbg6t9t";
	}

	public static UI_npc CreateInstance()
	{
		return (UI_npc)(object)UIPackage.CreateObject("Guide", "npc");
	}

	public static UI_npc CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_npc).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5vxjvcrbg6t9t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GGraph)((GComponent)this).GetChild("background");
		nickName = (GRichTextField)((GComponent)this).GetChild("nickName");
		string id = "ui://5vxjvcrbg6t9t".Replace("ui://", "") + "-" + ((GObject)nickName).id;
		((GObject)nickName).text = LanguagesManager.GetDesc(id);
		n23 = (GImage)((GComponent)this).GetChild("n23");
		avatar = (GLoader)((GComponent)this).GetChild("avatar");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		showup = ((GComponent)this).GetTransition("showup");
	}
}
