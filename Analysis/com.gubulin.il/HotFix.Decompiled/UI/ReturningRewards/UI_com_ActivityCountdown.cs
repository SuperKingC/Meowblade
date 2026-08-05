using System.Collections;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using UnityEngine;

namespace UI.ReturningRewards;

public class UI_com_ActivityCountdown : GComponent
{
	public GImage n3;

	public GImage n0;

	public GRichTextField countDownText;

	public const string URL = "ui://rx5ntv98win2m";

	public static string Name = "UI_com_ActivityCountdown";

	private const string RETURNING_REWARD_END_TIME = "ReturningRewardEndTime";

	private const string RETURNING_REWARD_END_TIME_DEFAULT = "Activity Ends In {0}";

	private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

	private Coroutine _countdownCoroutine;

	private long _endTimeStamp;

	public static string GetURL()
	{
		return "ui://rx5ntv98win2m";
	}

	public static UI_com_ActivityCountdown CreateInstance()
	{
		return (UI_com_ActivityCountdown)(object)UIPackage.CreateObject("ReturningRewards", "com_ActivityCountdown");
	}

	public static UI_com_ActivityCountdown CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ActivityCountdown).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98win2m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		countDownText = (GRichTextField)((GComponent)this).GetChild("countDownText");
	}

	public void OnShow(int endTime)
	{
		FGUIManager.Instance.CloseIEnumerator(_countdownCoroutine);
		_endTimeStamp = endTime;
		_countdownCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateCountdown());
	}

	public void BeforeDestroy()
	{
		if (_countdownCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_countdownCoroutine);
			_countdownCoroutine = null;
		}
	}

	private IEnumerator UpdateCountdown()
	{
		while (true)
		{
			double nowStamp = GameController.Instance.GetServerRealtimeSeconds();
			int remainTime = (int)((double)_endTimeStamp - nowStamp);
			string tip = LanguagesManager.GetDesc("ReturningRewardEndTime", "Activity Ends In {0}");
			string remainTimeText = (HotUpdateProcess.Instance.IsRegionOutCN ? UiHelper.ParseTimeSpanUniversal(remainTime) : UiHelper.ParseTimeChnForGift(remainTime));
			((GObject)countDownText).text = string.Format(tip, remainTimeText);
			yield return _waitForSeconds;
		}
	}
}
