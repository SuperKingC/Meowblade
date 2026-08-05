using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo;

namespace UI.GvG3Video;

public class UI_com_VideoPlayer : GComponent
{
	private enum PlayerState
	{
		Pending,
		Preparing,
		Playing
	}

	public Controller State;

	public GImage n1;

	public GLoader VideoLoader;

	public GLoader PreviewIcon;

	public GImage n7;

	public GLoader VideoTitle;

	public UI_btn_Play Play;

	public GTextField n3;

	public GImage n5;

	public GTextField Desc;

	public GTextField n10;

	public Transition Prepare;

	public const string URL = "ui://2itu6489ezmi1";

	public static string Name = "UI_com_VideoPlayer";

	public static string GetURL()
	{
		return "ui://2itu6489ezmi1";
	}

	public static UI_com_VideoPlayer CreateInstance()
	{
		return (UI_com_VideoPlayer)(object)UIPackage.CreateObject("GvG3Video", "com_VideoPlayer");
	}

	public static UI_com_VideoPlayer CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_VideoPlayer).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2itu6489ezmi1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		VideoLoader = (GLoader)((GComponent)this).GetChild("VideoLoader");
		PreviewIcon = (GLoader)((GComponent)this).GetChild("PreviewIcon");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		VideoTitle = (GLoader)((GComponent)this).GetChild("VideoTitle");
		Play = (UI_btn_Play)(object)((GComponent)this).GetChild("Play");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://2itu6489ezmi1".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id2 = "ui://2itu6489ezmi1".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id2);
		Prepare = ((GComponent)this).GetTransition("Prepare");
	}

	public void Reset(HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo.GvG3Video video)
	{
		VideoTitle.url = video.Display.TitleIcon;
		State.SetSelectedIndex(0);
		PreviewIcon.url = video.Display.Icon;
		((GObject)Desc).text = video.Display.Desc;
	}

	public void StartPlay()
	{
		State.SetSelectedIndex(1);
	}

	public void Prepared()
	{
		State.SetSelectedIndex(2);
	}
}
