using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_ScoreHistoryPanel : GComponent
{
	public Controller StateController;

	public GGraph mask_dont_delete;

	public GImage back;

	public GList List;

	public UI_ScoreHistoryBtn ScoreHistoryBtn;

	public GImage arrow;

	public Transition Collapse;

	public Transition Expand;

	public const string URL = "ui://0i520nzmh3e5o97";

	public static string Name = "UI_ScoreHistoryPanel";

	public static string GetURL()
	{
		return "ui://0i520nzmh3e5o97";
	}

	public static UI_ScoreHistoryPanel CreateInstance()
	{
		return (UI_ScoreHistoryPanel)(object)UIPackage.CreateObject("LordOfDreams", "ScoreHistoryPanel");
	}

	public static UI_ScoreHistoryPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScoreHistoryPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmh3e5o97", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		StateController = ((GComponent)this).GetController("StateController");
		mask_dont_delete = (GGraph)((GComponent)this).GetChild("mask_dont_delete");
		back = (GImage)((GComponent)this).GetChild("back");
		List = (GList)((GComponent)this).GetChild("List");
		ScoreHistoryBtn = (UI_ScoreHistoryBtn)(object)((GComponent)this).GetChild("ScoreHistoryBtn");
		arrow = (GImage)((GComponent)this).GetChild("arrow");
		Collapse = ((GComponent)this).GetTransition("Collapse");
		Expand = ((GComponent)this).GetTransition("Expand");
	}
}
