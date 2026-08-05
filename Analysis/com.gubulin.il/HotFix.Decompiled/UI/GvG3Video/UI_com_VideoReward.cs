using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo;

namespace UI.GvG3Video;

public class UI_com_VideoReward : GComponent
{
	public Controller State;

	public GImage n0;

	public GTextField n1;

	public GTextField n2;

	public UI_btn_Reward Reward;

	public const string URL = "ui://2itu6489ezmi5";

	public static string Name = "UI_com_VideoReward";

	private EventCallback1 _claimCallback;

	private EventCallback1 _showItemDescCallback;

	public static string GetURL()
	{
		return "ui://2itu6489ezmi5";
	}

	public static UI_com_VideoReward CreateInstance()
	{
		return (UI_com_VideoReward)(object)UIPackage.CreateObject("GvG3Video", "com_VideoReward");
	}

	public static UI_com_VideoReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_VideoReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2itu6489ezmi5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://2itu6489ezmi5".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id2 = "ui://2itu6489ezmi5".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id2);
		Reward = (UI_btn_Reward)(object)((GComponent)this).GetChild("Reward");
	}

	public void Init(EventCallback1 claimCallback, EventCallback1 showItemDescCallback)
	{
		_claimCallback = claimCallback;
		_showItemDescCallback = showItemDescCallback;
	}

	public void UpdateVideoReward(HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo.GvG3Video video)
	{
		KeyValuePair<string, int> reward = video.Display.DisplayBonus.ToList()[0];
		SetRewardClickData(reward.Key);
		RenderVideoReward((int)video.VideoRewardStatus, reward);
		SetClickCallback(video.VideoRewardStatus);
	}

	private void SetRewardClickData(string clickData)
	{
		((GObject)Reward).data = clickData;
	}

	private void RenderVideoReward(int status, KeyValuePair<string, int> reward)
	{
		State.SetSelectedIndex(status);
		Reward.State.SetSelectedIndex(status);
		FGUIManager.Instance.SetItemIconAndFrame(Reward.icon, reward.Key, null, "", frameVisible: false);
		((GObject)Reward.Count).text = reward.Value.ToString();
	}

	private void SetClickCallback(VideoRewardStatus status)
	{
		switch (status)
		{
		case VideoRewardStatus.NotClaimable:
		case VideoRewardStatus.Claimed:
			((GObject)Reward).onClick.Set(_showItemDescCallback);
			break;
		case VideoRewardStatus.Claimable:
			((GObject)Reward).onClick.Set(_claimCallback);
			break;
		}
	}
}
