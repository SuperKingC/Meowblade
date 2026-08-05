public interface IAudioClip : IEventListener, IAudioClipNameListener, IAudioVolumeListener
{
	void Initialize(Contexts contexts, GameEntity entity);

	void Play();

	void Restart();

	void Pause();

	void Stop();
}
