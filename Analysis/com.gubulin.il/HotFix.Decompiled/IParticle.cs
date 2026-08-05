public interface IParticle : IEventListener
{
	void Initialize(Contexts contexts, GameEntity entity);

	void Play();

	void Restart();

	void Pause();

	void Stop();
}
