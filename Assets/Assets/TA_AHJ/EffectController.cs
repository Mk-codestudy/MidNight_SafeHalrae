using UnityEngine;

public class EffectController : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private bool isEffectPlayed = false;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        if (particleSystem == null)
        {
            Debug.LogError("ParticleSystem component not found!");
        }
    }

    // 외부에서 호출할 메서드
    public void TriggerEffect()
    {
        if (!isEffectPlayed)
        {
            // 2초 후에 이펙트를 한 번만 재생합니다.
            Invoke(nameof(PlayEffect), 2f);
            isEffectPlayed = true;
        }
    }

    private void PlayEffect()
    {
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }
}