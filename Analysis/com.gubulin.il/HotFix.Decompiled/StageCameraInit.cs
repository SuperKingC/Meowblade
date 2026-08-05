using UnityEngine;

public class StageCameraInit : MonoBehaviour
{
	public Camera _Camera;

	public static float DevelopWidth = 1920f;

	public static float DevelopHeigh = 1080f;

	public static float DevelopRate = DevelopHeigh / DevelopWidth;

	public static int curScreenHeight = Screen.height;

	public static int curScreenWidth = Screen.width;

	public static float ScreenRate = (float)Screen.height / (float)Screen.width;

	public static float cameraRectHeightRate = DevelopHeigh / (DevelopWidth / (float)Screen.width * (float)Screen.height);

	public static float cameraRectWidthRate = DevelopWidth / (DevelopHeigh / (float)Screen.height * (float)Screen.width);

	private void Start()
	{
		FitCamera(_Camera);
	}

	private void Update()
	{
	}

	public void FitCamera(Camera camera)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		if (DevelopRate <= ScreenRate)
		{
			camera.rect = new Rect(0f, (1f - cameraRectHeightRate) / 2f, 1f, cameraRectHeightRate);
		}
		else
		{
			camera.rect = new Rect(0f, (1f - cameraRectHeightRate) / 2f, 1f, cameraRectHeightRate);
		}
	}
}
