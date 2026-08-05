namespace HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi;

public abstract class BaseActivityRedDotIndicator : IActivityRedDotIndicator
{
	private static string SpecialActivities => HotUpdateProcess.Instance.Configs["SpecialActivities"];

	public abstract bool DisplayRedDot();

	protected bool IsSpecial(string activityId)
	{
		return SpecialActivities.Contains(activityId);
	}
}
