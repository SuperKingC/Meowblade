using FairyGUI;
using FairyGUI.Utils;

namespace UI.Lottery;

public class UI_LotteryTimesProcessBar : GProgressBar
{
	public GGraph n0;

	public GGraph bar;

	public const string URL = "ui://gxhnhhxkhblgr";

	public static string Name = "UI_LotteryTimesProcessBar";

	public static string GetURL()
	{
		return "ui://gxhnhhxkhblgr";
	}

	public static UI_LotteryTimesProcessBar CreateInstance()
	{
		return (UI_LotteryTimesProcessBar)(object)UIPackage.CreateObject("Lottery", "LotteryTimesProcessBar");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		bar = (GGraph)((GComponent)this).GetChild("bar");
	}
}
