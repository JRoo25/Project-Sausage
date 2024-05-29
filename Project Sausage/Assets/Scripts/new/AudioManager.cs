using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------- Audio Source -------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------- Audio Clip -------")]
    public AudioClip background;
    public AudioClip checkpoint;
    public AudioClip jump;
    public AudioClip death;
    public AudioClip finish;

    private void Start() {
        musicSource.clip = background;
        musicSource.Play();

        if (PauseMenu.GameIsPaused) {
            musicSource.pitch *= .5f;
        }
    }

    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }
}
