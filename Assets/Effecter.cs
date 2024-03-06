using UnityEngine;

public class Effecter : MonoBehaviour
{
    private ParticleSystem[] _particles;

    private void Awake()
    {
        _particles = GetComponentsInChildren<ParticleSystem>();
    }

    public void Show()
    {
        foreach (ParticleSystem particle in _particles)            
            particle.Play();
    }
}