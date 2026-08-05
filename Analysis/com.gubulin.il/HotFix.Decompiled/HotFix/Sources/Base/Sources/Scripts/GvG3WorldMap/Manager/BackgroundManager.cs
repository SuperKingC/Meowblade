using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;

public class BackgroundManager
{
	private const float MAP_GROUND_DIST = 0.95f;

	private const float MAP_SPACE_DIST = 0.995f;

	private const float SCALE_DAMPING = 0.05f;

	private Transform GroundScaleTrans;

	private Transform GroundPosTrans;

	private Transform SpaceScaleTrans;

	private Transform SpacePosTrans;

	private Transform CamTrans;

	private Camera Camera;

	private float CamInitSize;

	private Vector3 CamInitPos;

	private GameObject _backGroundGo;

	private bool _isBrawlEvent;

	public BackgroundManager(GameObject WorldMap, Transform camBaseTrans, Camera camera, float cameraInitSize)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		_isBrawlEvent = WorldMapConfigHelper.Configs.IsBrawlEvent();
		GameObject val = Addressables.InstantiateAsync((object)(_isBrawlEvent ? "GvG/Background_VoidBrawl" : "GvG/Background"), WorldMap.transform, false, true).WaitForCompletion();
		((Object)val).name = "Background";
		_backGroundGo = val;
		GroundScaleTrans = WorldMap.transform.Find("Background/Ground");
		GroundPosTrans = WorldMap.transform.Find("Background/Ground/PosWrapper");
		SpaceScaleTrans = WorldMap.transform.Find("Background/Space");
		SpacePosTrans = WorldMap.transform.Find("Background/Space/PosWrapper");
		CamTrans = camBaseTrans;
		Camera = camera;
		CamInitSize = cameraInitSize;
		if (_isBrawlEvent)
		{
			CamInitSize = 30f;
		}
		CamInitPos = new Vector3(0f, CamTrans.position.y, 0f - CamTrans.position.y);
	}

	public void Update()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		float num = Camera.orthographicSize / CamInitSize;
		float num2 = num - 0.05f * num * num;
		Vector3 localScale = default(Vector3);
		((Vector3)(ref localScale))._002Ector(num2, num2, num2);
		GroundScaleTrans.localScale = localScale;
		((Vector3)(ref localScale))._002Ector(num, num, num);
		SpaceScaleTrans.localScale = localScale;
		Vector3 val = CamTrans.position - CamInitPos;
		GroundScaleTrans.position = val;
		SpaceScaleTrans.position = val;
		GroundPosTrans.localPosition = val * -0.050000012f;
		SpacePosTrans.localPosition = val * -0.004999995f;
	}

	public void ChangeSpace(string spaceGoName = null)
	{
		if (_isBrawlEvent)
		{
			if (string.IsNullOrEmpty(spaceGoName))
			{
				spaceGoName = "Space";
			}
			for (int i = 0; i < SpacePosTrans.childCount; i++)
			{
				Transform child = SpacePosTrans.GetChild(i);
				((Component)child).gameObject.SetActive(((Object)((Component)child).gameObject).name == spaceGoName);
			}
		}
	}

	public void OnDestroy()
	{
		Addressables.ReleaseInstance(_backGroundGo);
	}
}
