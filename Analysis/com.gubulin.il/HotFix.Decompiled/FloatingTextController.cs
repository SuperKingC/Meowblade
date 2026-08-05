using HotFix;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextController : MonoBehaviour, IFloatingTextListener, IFloatingTextAlphaListener, IPooled
{
	[SerializeField]
	private Text _text;

	[SerializeField]
	private CanvasRenderer _renderer;

	private GameEntity _entity;

	public int opUniqueId { get; set; }

	public bool Active { get; set; }

	public void Initialize(Contexts contexts, GameEntity entity)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		_text.text = entity.floatingText.text;
		((Graphic)_text).color = entity.floatingText.color;
		_entity = entity;
		RegisterListeners();
	}

	public void RegisterListeners()
	{
		_entity.AddFloatingTextListener(this);
		_entity.AddFloatingTextAlphaListener(this);
	}

	public void UnregisterListeners()
	{
		_entity.RemoveFloatingTextListener(this);
		_entity.RemoveFloatingTextAlphaListener(this);
	}

	public void UnSpawn()
	{
	}

	public void OnInstantiate()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		_text.text = string.Empty;
		((Graphic)_text).color = Color.black;
	}

	public void OnUnSpawn()
	{
		UnregisterListeners();
	}

	public void OnFloatingText(GameEntity entity, Color color, string text)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		((Graphic)_text).color = color;
		_text.text = text;
	}

	public void OnFloatingTextAlpha(GameEntity entity, float value)
	{
		_renderer.SetAlpha(value);
	}
}
