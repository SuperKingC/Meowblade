using System.Collections;
using FairyGUI;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper;

public static class GTweenExtension
{
	public static IEnumerator WaitForComplete(this GTweener self)
	{
		yield return (object)new WaitForSeconds(self.duration);
	}
}
