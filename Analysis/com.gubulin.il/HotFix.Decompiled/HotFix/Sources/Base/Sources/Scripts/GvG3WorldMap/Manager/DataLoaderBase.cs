using System.Collections;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;

public abstract class DataLoaderBase
{
	public bool IsLoading;

	public bool NeedInterruptionAndReload;

	public DataLoaderBase()
	{
		IsLoading = false;
		NeedInterruptionAndReload = false;
	}

	public abstract IEnumerator Reload();

	public virtual void UnloadAll()
	{
	}
}
