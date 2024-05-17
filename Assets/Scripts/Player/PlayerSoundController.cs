using UnityEngine;

public class PlayerSoundController : MonoBehaviour {
    [SerializeField]
    private PlayerHpController hpController;

    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioClip shotSound;

    [SerializeField]
    private AudioClip deathSound;

    private void OnValidate() {
        if (!source) {
            source = GetComponent<AudioSource>();
        }

        if (!hpController) {
            hpController = GetComponent<PlayerHpController>();
        }
    }


    public void PlayDeathSound() {
        if (source.isPlaying) {
            return;
        }

        source.clip = deathSound;
        source.Play();
    }

    public void PlayShotSound() {
        if (source.isPlaying) {
            return;
        }

        source.clip = shotSound;
        source.Play();
    }
}