using System.Collections;
using System.Collections.Generic;
using Shift.Legion.Common.Services;
using UI.GvGWorldMap2;
using UnityEngine;

namespace GvG2;

public class GvG2TipsManager
{
	private class TipData
	{
		public float ShowTimeStamp;

		public Dictionary<string, object> UiParam;
	}

	private static GvG2TipsManager _Instance;

	private List<TipData> TipsParams = new List<TipData>();

	private Coroutine UpdateCoroutineHandler;

	private const int MAX_TIPS = 20;

	public static GvG2TipsManager Instance
	{
		get
		{
			if (_Instance == null)
			{
				_Instance = new GvG2TipsManager();
			}
			return _Instance;
		}
	}

	private GvG2TipsManager()
	{
		TipsParams = new List<TipData>();
	}

	public void PlayTip(Dictionary<string, object> uiParam, float showTimeStamp)
	{
		if (TipsParams.Count < 20)
		{
			int i;
			for (i = 0; i < TipsParams.Count && !(TipsParams[i].ShowTimeStamp > showTimeStamp); i++)
			{
			}
			TipsParams.Insert(i, new TipData
			{
				ShowTimeStamp = showTimeStamp,
				UiParam = uiParam
			});
			if (UpdateCoroutineHandler == null)
			{
				UpdateCoroutineHandler = FGUIManager.Instance.OpenIEnumerator(PlayTipsCotoutine());
			}
		}
	}

	private IEnumerator PlayTipsCotoutine()
	{
		while (TipsParams.Count > 0)
		{
			if (Time.time >= TipsParams[0].ShowTimeStamp)
			{
				TipData tipData = TipsParams[0];
				TipsParams.RemoveAt(0);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvG2Tip.Name, tipData.UiParam, multiMode: true);
			}
			yield return null;
		}
		UpdateCoroutineHandler = null;
	}

	public void StopAllTips()
	{
		if (UpdateCoroutineHandler != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(UpdateCoroutineHandler);
			UpdateCoroutineHandler = null;
		}
		TipsParams.Clear();
		SharedMessenger.Broadcast("ON_GVG_TIP_CLEAR");
	}
}
