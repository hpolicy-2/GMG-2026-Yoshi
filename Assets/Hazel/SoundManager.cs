using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Pooled 2D SFX sources")]
    [SerializeField] private int poolSize = 8;
    private List<AudioSource> sourcePool = new List<AudioSource>();

    [Header("Music")]
    [SerializeField] private AudioSource musicSourceA;
    [SerializeField] private AudioSource musicSourceB;
    private AudioSource activeMusicSource;
    private AudioSource inactiveMusicSource;
    private Coroutine fadeRoutine;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < poolSize; i++)
        {
            AudioSource src = gameObject.AddComponent<AudioSource>();
            src.playOnAwake = false;
            sourcePool.Add(src);
        }

        // two music sources defined
        musicSourceA.loop = true;
        musicSourceB.loop = true;
        musicSourceA.playOnAwake = false;
        musicSourceB.playOnAwake = false;
        activeMusicSource = musicSourceA;
        inactiveMusicSource = musicSourceB;
    }

    public void PlaySFX(AudioClip clip, float volume = 1f, float pitch = 1f)
    {
        if (clip == null) return;
        AudioSource src = GetAvailableSource();
        src.clip = clip;
        src.volume = volume;
        src.pitch = pitch;
        src.Play();
    }

    public void PlaySFXRandomPitch(AudioClip clip, float volume = 1f, float minPitch = 0.95f, float maxPitch = 1.05f)
    {
        PlaySFX(clip, volume, Random.Range(minPitch, maxPitch));
    }

    private AudioSource GetAvailableSource()
    {
        foreach (var src in sourcePool)
        {
            if (!src.isPlaying) return src;
        }
        return sourcePool[0];
    }

    // switch + crossfade
    public void PlayMusic(AudioClip newClip, float fadeDuration = 1f)
    {
        if (newClip == null) return;

        // track is already plating
        if (activeMusicSource.clip == newClip && activeMusicSource.isPlaying) return;

        if (fadeRoutine != null) StopCoroutine(fadeRoutine);
        fadeRoutine = StartCoroutine(CrossfadeMusic(newClip, fadeDuration));
    }

    private IEnumerator CrossfadeMusic(AudioClip newClip, float duration)
    {
        inactiveMusicSource.clip = newClip;
        inactiveMusicSource.volume = 0f;
        inactiveMusicSource.Play();

        float t = 0f;
        float startVolume = activeMusicSource.volume;

        while (t < duration)
        {
            t += Time.deltaTime;
            float lerp = t / duration;
            activeMusicSource.volume = Mathf.Lerp(startVolume, 0f, lerp);
            inactiveMusicSource.volume = Mathf.Lerp(0f, 1f, lerp);
            yield return null;
        }

        activeMusicSource.Stop();
        activeMusicSource.volume = startVolume; // reset for next time it's used

        // swap roles
        var temp = activeMusicSource;
        activeMusicSource = inactiveMusicSource;
        inactiveMusicSource = temp;
    }
}