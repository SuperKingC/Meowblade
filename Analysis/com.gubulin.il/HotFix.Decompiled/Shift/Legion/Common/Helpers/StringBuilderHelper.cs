using System.Text;

namespace Shift.Legion.Common.Helpers;

public static class StringBuilderHelper
{
	private static StringBuilder inst = new StringBuilder();

	public static StringBuilder Inst()
	{
		inst.Clear();
		return inst;
	}
}
