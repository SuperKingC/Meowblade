using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_GvGBattleRecordBossHpBar : GComponent
{
	public GImage mask;

	public GImage back;

	public UI_GvGBossHpBackBar BackHp;

	public UI_GvGBossHpMiddleBar MiddleBar;

	public UI_GvGBossHpFrontBar FrontHp;

	public const string URL = "ui://twlbabiclqo8l9";

	public static string Name = "UI_GvGBattleRecordBossHpBar";

	private int CurrentTypeIndex;

	private const int HpTypeCount = 5;

	private int HpBarCountValue = -1;

	public static string GetURL()
	{
		return "ui://twlbabiclqo8l9";
	}

	public static UI_GvGBattleRecordBossHpBar CreateInstance()
	{
		return (UI_GvGBattleRecordBossHpBar)(object)UIPackage.CreateObject("Battle", "GvGBattleRecordBossHpBar");
	}

	public static UI_GvGBattleRecordBossHpBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBattleRecordBossHpBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabiclqo8l9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GImage)((GComponent)this).GetChild("mask");
		back = (GImage)((GComponent)this).GetChild("back");
		BackHp = (UI_GvGBossHpBackBar)(object)((GComponent)this).GetChild("BackHp");
		MiddleBar = (UI_GvGBossHpMiddleBar)(object)((GComponent)this).GetChild("MiddleBar");
		FrontHp = (UI_GvGBossHpFrontBar)(object)((GComponent)this).GetChild("FrontHp");
	}

	public void BossHpBarInit()
	{
		CurrentTypeIndex = 0;
		ResetHpBar(isInit: true);
	}

	public void UpdateBossHpBarValue(float hpValue)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		((GProgressBar)FrontHp).TweenValue((double)hpValue, 0.02f).OnComplete((GTweenCallback)delegate
		{
			((GProgressBar)MiddleBar).TweenValue((double)hpValue, 0.1f);
		});
	}

	public void UpdateBossHpBarCount(int hpBarCount, GTextField hpBarCountTextField)
	{
		if (hpBarCount >= 0 || HpBarCountValue >= 0)
		{
			bool flag = HpBarCountValue != -1 && HpBarCountValue != hpBarCount;
			HpBarCountValue = hpBarCount;
			if (hpBarCountTextField != null && !((GObject)hpBarCountTextField).isDisposed)
			{
				((GObject)hpBarCountTextField).text = $"X{HpBarCountValue}";
			}
			if (HpBarCountValue == 0)
			{
				((GObject)BackHp).alpha = 0f;
			}
			if (flag)
			{
				CurrentTypeIndex = ((CurrentTypeIndex + 1 < 5) ? (CurrentTypeIndex + 1) : 0);
				ResetHpBar();
			}
		}
	}

	private void ResetHpBar(bool isInit = false)
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		FrontHp.bar.Type.selectedIndex = CurrentTypeIndex;
		BackHp.bar.Type.selectedIndex = CurrentTypeIndex;
		((GProgressBar)FrontHp).value = 100.0;
		if (isInit)
		{
			((GProgressBar)BackHp).value = 100.0;
			((GProgressBar)MiddleBar).value = 100.0;
		}
		else
		{
			((GProgressBar)FrontHp).TweenValue(100.0, 0.05f).OnComplete((GTweenCallback)delegate
			{
				((GProgressBar)MiddleBar).value = 100.0;
			});
		}
	}
}
