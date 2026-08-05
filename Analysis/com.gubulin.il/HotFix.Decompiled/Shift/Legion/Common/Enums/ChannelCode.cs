using System.Collections.Generic;
using HotFix;

namespace Shift.Legion.Common.Enums;

public class ChannelCode
{
	public const string YYTX = "1001";

	public const string Xinxin = "1002";

	public const string Houlang = "1003";

	public const string toutiao_official = "101";

	public const string PVP_test_official = "10";

	public const string AndroidToutiao = "toutiao-android";

	public const string AndroidTapTap = "taptap";

	public const string TapTapPrivacyReview = "taptapprivacyreview";

	public const string TapPlay = "tapplay";

	public const string gubulin_official = "gubulin-android";

	public const string International = "intl";

	public const string Google = "Google";

	public const string TapTapInternational = "TapIntl";

	public const string Facebook = "Facebook";

	public const string Twitter = "Twitter";

	public const string Apple = "Apple";

	public const string AndroidGDT = "gdt-android";

	public const string AndroidLenovo = "lenovo-android";

	public const string BiliBili = "bilibili";

	public const string HaoYouKuaiBao = "haoyoukuaibao";

	public const string XiPu = "xipu";

	private static Dictionary<string, string> ChannelCodeMappedValueDict = new Dictionary<string, string>
	{
		{ "taptap", "0" },
		{ "taptapprivacyreview", "1" },
		{ "toutiao-android", "2" },
		{ "gubulin-android", "3" },
		{ "Apple", "4" },
		{ "bilibili", "5" },
		{ "haoyoukuaibao", "6" },
		{ "xipu", "7" },
		{ "gdt-android", "8" },
		{ "tapplay", "9" }
	};

	public static string GetChannelCodeMappedValue()
	{
		if (ChannelCodeMappedValueDict.TryGetValue(HotUpdateProcess.ChannelCode, out var value))
		{
			return value;
		}
		return HotUpdateProcess.ChannelCode;
	}
}
