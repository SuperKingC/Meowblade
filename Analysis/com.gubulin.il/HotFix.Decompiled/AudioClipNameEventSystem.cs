using System.Collections.Generic;
using Entitas;

public sealed class AudioClipNameEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IAudioClipNameListener> _listenerBuffer;

	public AudioClipNameEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IAudioClipNameListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.AudioClipName) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasAudioClipName && entity.hasAudioClipNameListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			AudioClipNameComponent audioClipName = entity.audioClipName;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.audioClipNameListener.value);
			foreach (IAudioClipNameListener item in _listenerBuffer)
			{
				item.OnAudioClipName(entity, audioClipName.value);
			}
		}
	}
}
