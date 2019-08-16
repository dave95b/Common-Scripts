using UnityEngine;
using System.Collections;

namespace Common.AudioEvents
{
    [CreateAssetMenu(menuName = "Audio Events/Simple", order = 170)]
    public class SimpleAudioEvent : AudioEvent
    {
        [SerializeField]
        private AudioClip[] clips;

        [SerializeField, MinMaxRange(0f, 1f)]
        private FloatRange volume = new FloatRange(1f, 1f);

        [SerializeField, MinMaxRange(-3f, 3f)]
        private FloatRange pitch = new FloatRange(1f, 1f);

        public override void Play(AudioSource source)
        {
            if (clips.Length == 0)
                return;

            source.clip = clips.GetRandom();
            source.volume = volume.Random;
            source.pitch = pitch.Random;

            source.Play();
        }

        public override void PlayOneShot(AudioSource source)
        {
            if (clips.Length == 0)
                return;

            AudioClip clip = clips.GetRandom();
            source.volume = volume.Random;
            source.pitch = pitch.Random;

            source.PlayOneShot(clip);
        }
    }
}