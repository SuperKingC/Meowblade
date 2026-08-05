using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo;

namespace UI.GvG3Video;

public class UI_btn_VideoPreview : GButton
{
	public Controller button;

	public GImage n13;

	public UI_com_VideoInfo PreviewIcon;

	public GImage n12;

	public GGraph NotEnabledClickGraph;

	public const string URL = "ui://2itu6489fuvq8";

	public static string Name = "UI_btn_VideoPreview";

	public static string GetURL()
	{
		return "ui://2itu6489fuvq8";
	}

	public static UI_btn_VideoPreview CreateInstance()
	{
		return (UI_btn_VideoPreview)(object)UIPackage.CreateObject("GvG3Video", "btn_VideoPreview");
	}

	public static UI_btn_VideoPreview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_VideoPreview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2itu6489fuvq8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		PreviewIcon = (UI_com_VideoInfo)(object)((GComponent)this).GetChild("PreviewIcon");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		NotEnabledClickGraph = (GGraph)((GComponent)this).GetChild("NotEnabledClickGraph");
	}

	public void Render(HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo.GvG3Video video)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		((GObject)this).data = video.Meta.Id;
		RenderPreviewIcon(video);
		((GObject)NotEnabledClickGraph).onClick.Set(new EventCallback1(ShowNotEnabledTip));
	}

	private void RenderPreviewIcon(HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo.GvG3Video video)
	{
		PreviewIcon.State.SetSelectedIndex((int)video.VideoStatus);
		PreviewIcon.PreviewIcon.url = video.Display.Icon;
		((GObject)PreviewIcon.VideoTitle).text = video.Display.Title;
		((GObject)PreviewIcon.PlayTip).text = video.Display.PlayTip;
		((GObject)PreviewIcon.UnlockTip).text = video.Display.UnlockTip;
		KeyValuePair<string, int> keyValuePair = video.Display.DisplayBonus.ToList()[0];
		FGUIManager.Instance.SetItemIconAndFrame(PreviewIcon.RewardIcon, keyValuePair.Key, null, "", frameVisible: false);
		((GObject)PreviewIcon.RewardCount).text = keyValuePair.Value.ToString();
	}

	private void ShowNotEnabledTip(EventContext context)
	{
		VideoStatus selectedIndex = (VideoStatus)PreviewIcon.State.selectedIndex;
		if (selectedIndex != VideoStatus.AllowToPlay)
		{
			context.StopPropagation();
			if (selectedIndex == VideoStatus.NotEnabled)
			{
				"GvG3NotEnabledVideoTip".ToShowLanguageTip();
			}
		}
	}
}
