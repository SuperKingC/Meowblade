using System.Collections.Generic;
using Entitas;

public sealed class AudioVolumeEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IAudioVolumeListener> _listenerBuffer;

	public AudioVolumeEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IAudioVolumeListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.AudioVolume) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasAudioVolume && entity.hasAudioVolumeListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			AudioVolumeComponent audioVolume = entity.audioVolume;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.audioVolumeListener.value);
			foreach (IAudioVolumeListener item in _listenerBuffer)
			{
				item.OnAudioVolume(entity, audioVolume.value);
			}
		}
	}
}
