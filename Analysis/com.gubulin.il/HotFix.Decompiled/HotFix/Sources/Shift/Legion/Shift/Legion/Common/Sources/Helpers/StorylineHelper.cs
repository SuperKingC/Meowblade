using HotFix.Sources.Base.Scripts.Helper;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Helpers;

public static class StorylineHelper
{
	private static readonly string _csharpCodeZhTcText13 = "CsharpCodeZhTcText13".ToLanguage();

	private static readonly string _csharpCodeZhTcText625 = "CsharpCodeZhTcText625".ToLanguage();

	private static readonly string _mainStoryComplete = "MAIN_STORY_COMPLETE_UNLOCK".ToLanguage();

	public static string GetLevelDisplayTextFromLevelID(string levelId)
	{
		switch (levelId)
		{
		case "P201":
			return _csharpCodeZhTcText13 + "2-01" + _csharpCodeZhTcText625;
		case "P220":
			return _csharpCodeZhTcText13 + "2-20" + _csharpCodeZhTcText625;
		case "P320":
			return _csharpCodeZhTcText13 + "3-20" + _csharpCodeZhTcText625;
		case "P1130":
			return _mainStoryComplete;
		default:
			ILRuntimeDebug.LogError("[StorylineHelper] GetLevelDisplayTextFromLevelID 找不到对应的关卡文本转换 levelId = " + levelId);
			return "";
		}
	}
}
