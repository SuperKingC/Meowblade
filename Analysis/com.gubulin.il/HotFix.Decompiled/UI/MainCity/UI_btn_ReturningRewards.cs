using System.Collections;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using UI.ReturningRewards;
using UnityEngine;

namespace UI.MainCity;

public class UI_btn_ReturningRewards : GButton
{
	public Controller button;

	public Controller Claimable;

	public Controller isShowCountDown;

	public GImage n3;

	public GLoader n5;

	public GImage n11;

	public GMovieClip n6;

	public GImage n7;

	public GGraph effPos;

	public GTextField countDown;

	public const string URL = "ui://j611zmymwin2v458";

	public static string Name = "UI_btn_ReturningRewards";

	private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

	private Coroutine _countdownCoroutine;

	private long _endTimeStamp;

	public static string GetURL()
	{
		return "ui://j611zmymwin2v458";
	}

	public static UI_btn_ReturningRewards CreateInstance()
	{
		return (UI_btn_ReturningRewards)(object)UIPackage.CreateObject("MainCity", "btn_ReturningRewards");
	}

	public static UI_btn_ReturningRewards CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ReturningRewards).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmymwin2v458", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Claimable = ((GComponent)this).GetController("Claimable");
		isShowCountDown = ((GComponent)this).GetController("isShowCountDown");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GLoader)((GComponent)this).GetChild("n5");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n6 = (GMovieClip)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		effPos = (GGraph)((GComponent)this).GetChild("effPos");
		countDown = (GTextField)((GComponent)this).GetChild("countDown");
	}

	public async Task OnShow()
	{
		GetRecallWelfareResponse response = await GameManagers.Instance.ActivityManager.GetRecallWelfare();
		((GObject)this).visible = response != null;
		if (response != null)
		{
			_endTimeStamp = response.BeginTime + response.ValidPeriod * 86400;
			int now = DateTimeHelper.ServerNowTimestamp;
			if (_endTimeStamp - now <= 259200)
			{
				isShowCountDown.SetSelectedIndex(1);
				_countdownCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateCountdown());
			}
		}
	}

	public void Register()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((GObject)this).onClick.Set(new EventCallback0(OnClick));
		SharedMessenger.AddListener<Cache_RecallWelfare_RedDot>("ON_RECALL_WELFARE_MISSION_PROGRESS_CHANGED", OnRecallWelfareRedDotChange);
	}

	public void Unregister()
	{
		((GObject)this).onClick.Clear();
		SharedMessenger.RemoveListener<Cache_RecallWelfare_RedDot>("ON_RECALL_WELFARE_MISSION_PROGRESS_CHANGED", OnRecallWelfareRedDotChange);
	}

	public void BeforeDestroy()
	{
		if (_countdownCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_countdownCoroutine);
			_countdownCoroutine = null;
		}
	}

	private static void OnClick()
	{
		RecallWelfareUiParams parameters = GameManagers.Instance.ActivityManager.CreateRecallWelfareUiParams();
		UI_main_ReturningRewards.Open(parameters);
	}

	private void OnRecallWelfareRedDotChange(Cache_RecallWelfare_RedDot cache)
	{
		Claimable.SetSelectedIndex(cache.IsShowRedDot ? 1 : 0);
	}

	private IEnumerator UpdateCountdown()
	{
		while (true)
		{
			double nowStamp = GameController.Instance.GetServerRealtimeSeconds();
			int remainTime = (int)((double)_endTimeStamp - nowStamp);
			string remainTimeText = UiHelper.ParseTimeSpanUniversal(remainTime);
			((GObject)countDown).text = remainTimeText;
			yield return _waitForSeconds;
		}
	}
}
