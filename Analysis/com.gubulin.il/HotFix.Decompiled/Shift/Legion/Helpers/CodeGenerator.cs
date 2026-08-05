namespace Shift.Legion.Helpers;

public static class CodeGenerator
{
	private const int MinInvitingCodeLength = 6;

	private const int InvitingCodeOffset = 12321;

	private static char[] InvitingCodeCharPage = new char[25]
	{
		'g', 'a', 'k', 'q', 'b', 'j', 'c', 'e', 'm', 'n',
		'd', 'o', 'f', 'u', 't', 's', 'r', 'z', 'p', 'w',
		'i', 'v', 'y', 'x', 'h'
	};

	public static string GetInvitingCode(int userId)
	{
		string text = "";
		int num = userId + 12321;
		int num2 = InvitingCodeCharPage.Length;
		while (num > 0)
		{
			int num3 = num % num2;
			num /= num2;
			text = InvitingCodeCharPage[num3] + text;
		}
		if (text.Length < 6)
		{
			text = text.PadLeft(6, InvitingCodeCharPage[0]);
		}
		char c = text[0];
		char c2 = text[1];
		char c3 = text[2];
		char c4 = text[3];
		char c5 = text[4];
		char c6 = text[5];
		return $"{c2}{c4}{c5}{c}{c6}{c3}";
	}

	public static long GetOrderId(int userId)
	{
		return DateTimeHelper.Ticks * 1000000000 + userId;
	}
}
