using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CustomPerformanceMonitor : MonoBehaviour
{
	public static CustomPerformanceMonitor Instance;

	public Text fpsText;

	public Text minMaxText;

	public bool showOnScreen = true;

	public float updateInterval = 0.5f;

	public int maxRecordCount = 300;

	private List<float> fpsRecords = new List<float>();

	private float deltaTime = 0f;

	private float timeLeft;

	private StringBuilder stringBuilder = new StringBuilder();

	private float currentFPS = 0f;

	private float averageFPS = 0f;

	private float minFPS = float.MaxValue;

	private float maxFPS = float.MinValue;

	private void Awake()
	{
		showOnScreen = true;
		updateInterval = 0.5f;
		maxRecordCount = 300;
		fpsRecords = new List<float>();
		deltaTime = 0.5f;
		stringBuilder = new StringBuilder();
		CreateFPSUI();
	}

	private void Start()
	{
		timeLeft = updateInterval;
		if (!showOnScreen)
		{
			((Behaviour)this).enabled = false;
		}
	}

	private void Update()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		currentFPS = 1f / deltaTime;
		fpsRecords.Add(currentFPS);
		if (fpsRecords.Count > maxRecordCount)
		{
			fpsRecords.RemoveAt(0);
		}
		timeLeft -= Time.unscaledDeltaTime;
		if (timeLeft <= 0f)
		{
			UpdatePerformanceStats();
			UpdateDisplay();
			timeLeft = updateInterval;
		}
	}

	private void UpdatePerformanceStats()
	{
		averageFPS = CalculateAverageFPS();
		minFPS = CalculateMinFPS();
		maxFPS = CalculateMaxFPS();
	}

	private float CalculateAverageFPS()
	{
		if (fpsRecords.Count == 0)
		{
			return 0f;
		}
		float num = 0f;
		foreach (float fpsRecord in fpsRecords)
		{
			num += fpsRecord;
		}
		return num / (float)fpsRecords.Count;
	}

	private float CalculateMinFPS()
	{
		if (fpsRecords.Count == 0)
		{
			return 0f;
		}
		float num = float.MaxValue;
		foreach (float fpsRecord in fpsRecords)
		{
			if (fpsRecord < num)
			{
				num = fpsRecord;
			}
		}
		return num;
	}

	private float CalculateMaxFPS()
	{
		if (fpsRecords.Count == 0)
		{
			return 0f;
		}
		float num = float.MinValue;
		foreach (float fpsRecord in fpsRecords)
		{
			if (fpsRecord > num)
			{
				num = fpsRecord;
			}
		}
		return num;
	}

	private void UpdateDisplay()
	{
		if (showOnScreen && (!((Object)(object)fpsText == (Object)null) || !((Object)(object)minMaxText == (Object)null)))
		{
			stringBuilder.Clear();
			if ((Object)(object)fpsText != (Object)null)
			{
				stringBuilder.Append("FPS: ");
				stringBuilder.Append(currentFPS.ToString("F0"));
				stringBuilder.Append("\nAvg: ");
				stringBuilder.Append(averageFPS.ToString("F0"));
				fpsText.text = stringBuilder.ToString();
			}
			if ((Object)(object)minMaxText != (Object)null)
			{
				stringBuilder.Clear();
				stringBuilder.Append("Min: ");
				stringBuilder.Append(minFPS.ToString("F0"));
				stringBuilder.Append(" | Max: ");
				stringBuilder.Append(maxFPS.ToString("F0"));
				minMaxText.text = stringBuilder.ToString();
			}
		}
	}

	public float GetCurrentFPS()
	{
		return currentFPS;
	}

	public float GetAverageFPS()
	{
		return averageFPS;
	}

	public float GetMinFPS()
	{
		return minFPS;
	}

	public float GetMaxFPS()
	{
		return maxFPS;
	}

	public void ClearRecords()
	{
		fpsRecords.Clear();
		minFPS = float.MaxValue;
		maxFPS = float.MinValue;
	}

	public string GetPerformanceReport()
	{
		return $"当前FPS: {currentFPS:F0}\n" + $"平均FPS: {averageFPS:F0}\n" + $"最低FPS: {minFPS:F0}\n" + $"最高FPS: {maxFPS:F0}\n" + $"记录帧数: {fpsRecords.Count}";
	}

	public void ToggleDisplay()
	{
		showOnScreen = !showOnScreen;
		if ((Object)(object)fpsText != (Object)null)
		{
			((Behaviour)fpsText).enabled = showOnScreen;
		}
		if ((Object)(object)minMaxText != (Object)null)
		{
			((Behaviour)minMaxText).enabled = showOnScreen;
		}
	}

	private void CreateFPSUI()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject("FPS Canvas");
		Canvas val2 = val.AddComponent<Canvas>();
		CanvasScaler val3 = val.AddComponent<CanvasScaler>();
		GraphicRaycaster val4 = val.AddComponent<GraphicRaycaster>();
		val2.renderMode = (RenderMode)0;
		val2.sortingOrder = 999;
		GameObject val5 = new GameObject("FPSText");
		val5.transform.SetParent(val.transform);
		fpsText = val5.AddComponent<Text>();
		fpsText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
		fpsText.fontSize = 20;
		((Graphic)fpsText).color = Color.green;
		fpsText.alignment = (TextAnchor)0;
		RectTransform component = ((Component)fpsText).GetComponent<RectTransform>();
		component.anchorMin = new Vector2(0f, 1f);
		component.anchorMax = new Vector2(0f, 1f);
		component.pivot = new Vector2(0f, 1f);
		component.anchoredPosition = new Vector2(10f, -10f);
		component.sizeDelta = new Vector2(200f, 30f);
		GameObject val6 = new GameObject("MinMaxText");
		val6.transform.SetParent(val.transform);
		minMaxText = val6.AddComponent<Text>();
		minMaxText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
		minMaxText.fontSize = 16;
		((Graphic)minMaxText).color = Color.yellow;
		minMaxText.alignment = (TextAnchor)0;
		RectTransform component2 = ((Component)minMaxText).GetComponent<RectTransform>();
		component2.anchorMin = new Vector2(0f, 1f);
		component2.anchorMax = new Vector2(0f, 1f);
		component2.pivot = new Vector2(0f, 1f);
		component2.anchoredPosition = new Vector2(10f, -45f);
		component2.sizeDelta = new Vector2(300f, 25f);
		Object.DontDestroyOnLoad((Object)(object)val);
	}
}
