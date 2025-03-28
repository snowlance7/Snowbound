using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Snowbound.Valuables
{
    internal class FunoPlushBehavior : MonoBehaviour
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AudioSource ItemAudio;
        public AudioClip[] FunoSFX;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void PlayFumoSFX()
        {
            int index = UnityEngine.Random.Range(0, FunoSFX.Length);
            ItemAudio.PlayOneShot(FunoSFX[index]);
        }
    }
}
