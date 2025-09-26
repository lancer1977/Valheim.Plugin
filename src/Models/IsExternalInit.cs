
using System.Collections;
// ReSharper disable once CheckNamespace
using UnityEngine;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
namespace System.Runtime.CompilerServices
{

    public class IsExternalInit
    {

    }



    public class AudioHelper : MonoBehaviour
    {
        public IEnumerator PlayAudioFromUrl(string url, Vector3 position)
        {
            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV))
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