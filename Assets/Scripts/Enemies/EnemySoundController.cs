using UnityEngine;

public class EnemySoundController : MonoBehaviour {
    public AudioSource source;

    [SerializeField]
    private AudioClip shotSound;

    [SerializeField]
    private AudioClip deathSound;

    private void OnValidate() {
        if (!source) {
            source = GetComponent<AudioSource>();
        }
    }

    public void PlayShotSound() {
        if (source.isPlaying) {
            return;
        }

        source.clip = shotSound;
        source.Play();
    }

    public void PlayDeathSound() {
        if (source.isPlaying) {
            return;
        }

        source.clip = deathSound;
        source.Play();
    }
}