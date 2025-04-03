using REPOLib;
using REPOLib.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static Snowbound.Plugin;

namespace Snowbound.Valuables
{
    internal class SCP956Behavior : MonoBehaviour
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ValuableObject[] Candies;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        int minCandy = 5;
        int maxCandy = 15;

        public void Start()
        {
            minCandy = configSCP956MinCandy.Value;
            maxCandy = configSCP956MaxCandy.Value;
        }

        public void SpawnCandy()
        {
            if (!SemiFunc.IsMasterClientOrSingleplayer()) { return; }

            //ItemAudio.PlayOneShot(PartySFX);
            int candyAmount = UnityEngine.Random.Range(minCandy, maxCandy);

            for (int i = 0; i < candyAmount; i++)
            {
                int index = UnityEngine.Random.Range(0, Candies.Length);
                REPOLib.Modules.Valuables.SpawnValuable(Candies[index], transform.position, Quaternion.identity);
            }
        }
    }
}
