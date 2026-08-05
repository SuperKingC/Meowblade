using UnityEngine;

namespace GvG2;

internal static class GvGHelper
{
	public static void SetOutlineText(Transform trans, string text)
	{
		TextMesh[] componentsInChildren = ((Component)trans).GetComponentsInChildren<TextMesh>();
		TextMesh[] array = componentsInChildren;
		foreach (TextMesh val in array)
		{
			val.text = text;
		}
	}
}
