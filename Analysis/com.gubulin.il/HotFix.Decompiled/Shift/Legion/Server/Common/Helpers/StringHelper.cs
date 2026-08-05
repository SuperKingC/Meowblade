using System;
using System.Text;

namespace Shift.Legion.Server.Common.Helpers;

public class StringHelper
{
	private const string Characters = "abcdefghijklmnopqrstuvwxyz1234567890";

	public static string GenerateRandom(int length)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < length; i++)
		{
			stringBuilder.Append("abcdefghijklmnopqrstuvwxyz1234567890"[new Random(Guid.NewGuid().GetHashCode()).Next("abcdefghijklmnopqrstuvwxyz1234567890".Length)]);
		}
		return stringBuilder.ToString();
	}
}
