using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace PolyhydraGames.Valheim.Plugin.Models
{
    public class AudioHelper : MonoBehaviour
    {
        public IEnumerator PlayAudioFromUrl(string url, Vector3 position)
        {
            var audioType = url.Contains(".mp3") ? AudioType.MPEG : AudioType.WAV;
            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, audioType))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogWarning($"Failed to download audio: {www.error}");
                }
                else
                {
                    AudioClip clip = DownloadHandlerAudioClip.GetContent(www);

                    var audioObject = new GameObject("TempAudio");
                    audioObject.transform.position = position;

                    var audioSource = audioObject.AddComponent<AudioSource>();
                    audioSource.clip = clip;
                    audioSource.spatialBlend = 1f; // 3D sound
                    audioSource.Play();

                    Destroy(audioObject, clip.length); // cleanup
                }
            }
        }
    }
}
