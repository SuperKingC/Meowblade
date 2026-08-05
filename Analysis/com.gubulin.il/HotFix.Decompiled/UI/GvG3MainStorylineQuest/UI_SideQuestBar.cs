using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_SideQuestBar : GProgressBar
{
	public Controller Status;

	public GImage n8;

	public GLoader bar;

	public GTextField Progress;

	public GTextField n16;

	public const string URL = "ui://249h3k3dvihg23";

	public static string Name = "UI_SideQuestBar";

	public static string GetURL()
	{
		return "ui://249h3k3dvihg23";
	}

	public static UI_SideQuestBar CreateInstance()
	{
		return (UI_SideQuestBar)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "SideQuestBar");
	}

	public static UI_SideQuestBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SideQuestBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dvihg23", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		bar = (GLoader)((GComponent)this).GetChild("bar");
		Progress = (GTextField)((GComponent)this).GetChild("Progress");
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id = "ui://249h3k3dvihg23".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id);
	}
}
