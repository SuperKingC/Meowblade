using System.Collections.Generic;
using Entitas;

public sealed class SkinEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<ISkinListener> _listenerBuffer;

	public SkinEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<ISkinListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.Skin) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasSkin && entity.hasSkinListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			SkinComponent skin = entity.skin;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.skinListener.value);
			foreach (ISkinListener item in _listenerBuffer)
			{
				item.OnSkin(entity, skin.value);
			}
		}
	}
}
