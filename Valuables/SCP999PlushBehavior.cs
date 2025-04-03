using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static Snowbound.Plugin;

namespace Snowbound.Valuables
{
    internal class SCP999PlushBehavior : MonoBehaviour
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AudioSource ItemAudio;
        public AudioClip[] HugSFX;
        public PhysGrabObject grabObject;
        public Animator ItemAnimator;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        float timeSinceHeal;

        // Configs
        float healInterval = 5f;
        int healAmount = 5;

        public void Start()
        {
            healInterval = configSCP999PlushHealInterval.Value;
            healAmount = configSCP999PlushHealAmount.Value;
        }

        public void Update()
        {
            if (grabObject.playerGrabbing.Count > 0)
            {
                ItemAnimator.SetBool("hug", true);

                timeSinceHeal += Time.deltaTime;

                if (timeSinceHeal > healInterval)
                {
                    timeSinceHeal = 0f;

                    foreach (var player in grabObject.playerGrabbing)
                    {
                        player.playerAvatar.playerHealth.Heal(healAmount);
                    }

                    int index = UnityEngine.Random.Range(0, HugSFX.Length);
                    ItemAudio.PlayOneShot(HugSFX[index]);
                }
            }
            else
            {
                ItemAnimator.SetBool("hug", false);
            }
        }
    }
}
