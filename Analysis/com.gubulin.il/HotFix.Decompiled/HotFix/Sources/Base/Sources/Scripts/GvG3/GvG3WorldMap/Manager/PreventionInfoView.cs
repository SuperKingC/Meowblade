using System.Collections;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.C2S;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using Shift.Legion.Common.Helpers;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3WorldMap.Manager;

public class PreventionInfoView
{
	private StackPool<GameObject> _pool;

	private Coroutine _updateCoroutine;

	private GameObject _go;

	public C2S_GetPreventionInfo.EnemyShipData Data;

	public void InitPreventionInfo(StackPool<GameObject> pool, C2S_GetPreventionInfo.EnemyShipData shipData)
	{
		GameObject val = pool.Get();
		SpriteRenderer componentInChildren = val.GetComponentInChildren<SpriteRenderer>();
		_go = val;
		_pool = pool;
		Data = shipData;
		if (GvGWorldMapController.IsInstanceCreated && ((Component)GvGWorldMapController.Instance).gameObject.activeInHierarchy)
		{
			_updateCoroutine = ((MonoBehaviour)GvGWorldMapController.Instance).StartCoroutine(UpdateShipPos(componentInChildren));
		}
	}

	private IEnumerator UpdateShipPos(SpriteRenderer sp)
	{
		Transform spTrans = ((Component)sp).transform;
		Vector3 endPos = Data.GetTargetIslandPos();
		WaitForSeconds wait = new WaitForSeconds(0.2f);
		while (Object.op_Implicit((Object)(object)sp))
		{
			double serverTime = GameController.Instance.GetServerRealtimeSeconds();
			Vector3 startPos = Data.GetShipRealtimePos(serverTime);
			Vector3 lockAtVec = endPos - startPos;
			spTrans.localPosition = startPos;
			spTrans.localRotation = Quaternion.FromToRotation(Vector3.right, lockAtVec);
			float scale = Singleton<CameraService>.Instance.MainCamera.orthographicSize / 4f;
			Vector2 size = sp.size;
			size.x = ((Vector3)(ref lockAtVec)).magnitude / scale;
			sp.size = size;
			spTrans.localScale = Vector3.one * scale;
			yield return wait;
		}
	}

	public void Destroy()
	{
		((MonoBehaviour)GvGWorldMapController.Instance).StopCoroutine(_updateCoroutine);
		_pool.Release(_go);
	}
}
