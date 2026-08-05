using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;

public class AreaRenderManager
{
	private RenderTexture _FogOfWarMainTexture;

	private Texture2D _FogOfWar2DTexture;

	private Transform AreaRenderer;

	private GameObject _FogOfWarCanvas;

	private Camera[] AreaCameras;

	private Transform Canvas;

	public GameObject FogOfWarCanvas => _FogOfWarCanvas;

	public AreaRenderManager(GameObject worldMap)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		InitCullingMask();
		AreaRenderer = worldMap.transform.Find("AreaRenderer");
		_FogOfWarCanvas = ((Component)AreaRenderer.Find("Canvas/FogOfWar")).gameObject;
		Transform parent = ((Component)Camera.main).transform.parent;
		((Component)AreaRenderer).transform.position = parent.position;
		Canvas = AreaRenderer.Find("Canvas");
		AreaCameras = ((Component)AreaRenderer).GetComponentsInChildren<Camera>();
		_FogOfWarCanvas.SetActive(true);
		_FogOfWarCanvas.AddComponent<MeshCollider>();
		MeshRenderer component = _FogOfWarCanvas.GetComponent<MeshRenderer>();
		Material material = ((Renderer)component).material;
		ref RenderTexture fogOfWarMainTexture = ref _FogOfWarMainTexture;
		Texture texture = material.GetTexture("_TextGroup1");
		fogOfWarMainTexture = (RenderTexture)(object)((texture is RenderTexture) ? texture : null);
		_FogOfWar2DTexture = new Texture2D(((Texture)_FogOfWarMainTexture).width, ((Texture)_FogOfWarMainTexture).height);
	}

	public void OnDestroy()
	{
		Camera[] areaCameras = AreaCameras;
		foreach (Camera val in areaCameras)
		{
			val.targetTexture = null;
		}
		Object.DestroyImmediate((Object)(object)_FogOfWar2DTexture);
	}

	public void InitCullingMask()
	{
		Camera component = ((Component)Camera.main).GetComponent<Camera>();
		component.cullingMask &= -2049;
		component.cullingMask &= -4097;
	}

	public void UpdateCamPos(Vector3 globalPos)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		((Component)AreaRenderer).transform.position = globalPos;
	}

	public void OnCamSizeChange(float val)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		Canvas.localScale = new Vector3(val * 2f, 1f, val * 2f);
		Camera[] areaCameras = AreaCameras;
		foreach (Camera val2 in areaCameras)
		{
			val2.orthographicSize = val * 1.03125f;
		}
	}

	public Color SampleColorFromFogOfWar(Vector2 uv)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = _FogOfWarMainTexture;
		_FogOfWar2DTexture.ReadPixels(new Rect(0f, 0f, (float)((Texture)_FogOfWarMainTexture).width, (float)((Texture)_FogOfWarMainTexture).height), 0, 0);
		_FogOfWar2DTexture.Apply();
		Color pixel = _FogOfWar2DTexture.GetPixel((int)(uv.x * (float)((Texture)_FogOfWar2DTexture).width), (int)(uv.y * (float)((Texture)_FogOfWar2DTexture).height));
		RenderTexture.active = active;
		return pixel;
	}
}
