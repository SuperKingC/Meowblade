using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.QuadTree;

public class SparseVoxelQuadTree<T>
{
	private SparseVoxelQuadTree<T>[] ChildNodes;

	private Rect[] ChildRects;

	public Rect Rect { get; private set; }

	public List<T> DataList { get; private set; }

	public List<Rect> DataRectList { get; private set; }

	public int Level { get; private set; }

	public SparseVoxelQuadTree(Rect rect, int maxDepth)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		Rect = rect;
		DataList = new List<T>();
		DataRectList = new List<Rect>();
		Level = maxDepth;
		if (Level > 0)
		{
			ChildNodes = new SparseVoxelQuadTree<T>[4];
			ChildRects = (Rect[])(object)new Rect[4];
			Rect rect2 = Rect;
			float xMin = ((Rect)(ref rect2)).xMin;
			rect2 = Rect;
			float yMin = ((Rect)(ref rect2)).yMin;
			rect2 = Rect;
			float num = ((Rect)(ref rect2)).width * 0.5f;
			rect2 = Rect;
			float num2 = ((Rect)(ref rect2)).height * 0.5f;
			ChildRects[0] = new Rect(xMin, yMin, num, num2);
			ChildRects[1] = new Rect(xMin + num, yMin, num, num2);
			ChildRects[2] = new Rect(xMin, yMin + num2, num, num2);
			ChildRects[3] = new Rect(xMin + num, yMin + num2, num, num2);
		}
		else
		{
			ChildNodes = new SparseVoxelQuadTree<T>[0];
			ChildRects = (Rect[])(object)new Rect[0];
		}
	}

	public void IteratePostOrder(Action<SparseVoxelQuadTree<T>> callback)
	{
		SparseVoxelQuadTree<T>[] childNodes = ChildNodes;
		for (int i = 0; i < childNodes.Length; i++)
		{
			childNodes[i]?.IteratePostOrder(callback);
		}
		callback(this);
	}

	public List<T> GetAllData()
	{
		List<T> list = new List<T>();
		_GetAllData(list);
		return list;
	}

	private void _GetAllData(List<T> data)
	{
		SparseVoxelQuadTree<T>[] childNodes = ChildNodes;
		for (int i = 0; i < childNodes.Length; i++)
		{
			childNodes[i]?._GetAllData(data);
		}
		data.AddRange(DataList);
	}

	public void Insert(Vector2 point, T data)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		Rect rect = Rect;
		if (!((Rect)(ref rect)).Contains(point))
		{
			Debug.LogError((object)"Out of bound");
		}
		else
		{
			_Insert(point, data);
		}
	}

	private void _Insert(Vector2 point, T data)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		if (Level != 0)
		{
			for (int i = 0; i < ChildRects.Length; i++)
			{
				if (((Rect)(ref ChildRects[i])).Contains(point))
				{
					if (ChildNodes[i] == null)
					{
						ChildNodes[i] = new SparseVoxelQuadTree<T>(ChildRects[i], Level - 1);
					}
					ChildNodes[i]._Insert(point, data);
					return;
				}
			}
		}
		DataList.Add(data);
	}

	public SparseVoxelQuadTree<T> Search(Vector2 point)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		Rect rect = Rect;
		if (!((Rect)(ref rect)).Contains(point))
		{
			return null;
		}
		return _Search(point);
	}

	private SparseVoxelQuadTree<T> _Search(Vector2 point)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		if (Level != 0)
		{
			for (int i = 0; i < ChildRects.Length; i++)
			{
				if (ChildNodes[i] != null && ((Rect)(ref ChildRects[i])).Contains(point))
				{
					return ChildNodes[i].Search(point);
				}
			}
		}
		return this;
	}

	public void Insert(Rect rect, T data)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (!Rect.Contains(rect))
		{
			Debug.LogError((object)$"{rect} Out of bound -> {Rect}");
		}
		else
		{
			_Insert(rect, data);
		}
	}

	private void _Insert(Rect rect, T data)
	{
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		if (Level != 0)
		{
			for (int i = 0; i < ChildRects.Length; i++)
			{
				if (ChildRects[i].Contains(rect))
				{
					if (ChildNodes[i] == null)
					{
						ChildNodes[i] = new SparseVoxelQuadTree<T>(ChildRects[i], Level - 1);
					}
					ChildNodes[i]._Insert(rect, data);
					return;
				}
			}
		}
		DataList.Add(data);
		DataRectList.Add(rect);
	}

	public List<T> Search(Rect targetRect)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		List<T> list = new List<T>();
		Rect rect = Rect;
		if (((Rect)(ref rect)).Overlaps(targetRect))
		{
			_Search(list, targetRect);
		}
		return list;
	}

	private void _Search(List<T> data, Rect targetRect)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		if (!targetRect.Contains(Rect))
		{
			SparseVoxelQuadTree<T>[] childNodes = ChildNodes;
			Rect val;
			foreach (SparseVoxelQuadTree<T> sparseVoxelQuadTree in childNodes)
			{
				if (sparseVoxelQuadTree != null)
				{
					val = sparseVoxelQuadTree.Rect;
					if (((Rect)(ref val)).Overlaps(targetRect))
					{
						sparseVoxelQuadTree._Search(data, targetRect);
					}
				}
			}
			for (int j = 0; j < DataList.Count; j++)
			{
				val = DataRectList[j];
				if (((Rect)(ref val)).Overlaps(targetRect))
				{
					data.Add(DataList[j]);
				}
			}
		}
		else
		{
			data.AddRange(GetAllData());
		}
	}
}
