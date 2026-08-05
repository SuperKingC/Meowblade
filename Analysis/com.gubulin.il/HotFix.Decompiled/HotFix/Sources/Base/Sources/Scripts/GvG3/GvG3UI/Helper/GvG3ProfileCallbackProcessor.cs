using System.Collections;
using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;

public class GvG3ProfileCallbackProcessor
{
	private readonly List<IEnumerator> _enumerators = new List<IEnumerator>();

	public GvG3ProfileCallbackProcessor(List<IEnumerator> enumerators)
	{
		_enumerators.AddRange(enumerators);
	}

	public void AddEnumerator(IEnumerator enumerator)
	{
		_enumerators.Add(enumerator);
	}

	public IEnumerator ExecuteEnumerators()
	{
		foreach (IEnumerator enumerator2 in _enumerators)
		{
			yield return enumerator2;
		}
		yield return null;
	}
}
