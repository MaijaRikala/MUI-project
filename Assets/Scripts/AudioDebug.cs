using UnityEngine;

public class AudioDebug : MonoBehaviour
{
    void Start()
    {
        AudioSource[] sources = Object.FindObjectsByType<AudioSource>(FindObjectsSortMode.None);

        foreach (var source in sources)
        {
            Debug.Log(
                "AudioSource: " + source.gameObject.name +
                " | enabled: " + source.enabled +
                " | activeInHierarchy: " + source.gameObject.activeInHierarchy +
                " | isPlaying: " + source.isPlaying +
                " | clip: " + (source.clip != null ? source.clip.name : "NULL")
            );
        }
    }
}