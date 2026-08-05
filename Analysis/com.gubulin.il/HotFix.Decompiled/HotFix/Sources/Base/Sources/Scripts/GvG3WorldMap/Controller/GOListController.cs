using System;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;

public class GOListController : MonoBehaviour
{
	public float gap = 0f;

	public GameObject itemProvider;

	public Action<int, GameObject> itemRenderer;

	public int numItems
	{
		get
		{
			return ((Component)this).transform.childCount;
		}
		set
		{
			Render(value);
		}
	}

	public void Awake()
	{
	}

	private void Render(int renderCount)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		if (((Component)this).transform.childCount > 0)
		{
			ClearChildren();
		}
		if (renderCount > 0)
		{
			Vector3 zero = Vector3.zero;
			float num = itemProvider.transform.localScale.x + gap;
			zero.x = (float)(renderCount - 1) * num * -0.5f;
			for (int i = 0; i < renderCount; i++)
			{
				GameObject val = Object.Instantiate<GameObject>(itemProvider, ((Component)this).transform, false);
				val.transform.localPosition = zero;
				zero.x += num;
				itemRenderer(i, val);
			}
		}
	}

	private void ClearChildren()
	{
		for (int num = ((Component)this).transform.childCount - 1; num >= 0; num--)
		{
			Object.Destroy((Object)(object)((Component)((Component)this).transform.GetChild(num)).gameObject);
		}
	}
}
