using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Snowbound.Valuables
{
    internal class NukeBehavior : MonoBehaviour
    {
        private static ManualLogSource logger = Plugin.LoggerInstance;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ParticleScriptExplosion particleScriptExplosion;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        // Configs
        //float explodeChance = 0.5f;

        public void Explode()
        {
            logger.LogDebug("Explode() called");
            particleScriptExplosion.Spawn(transform.position, 100, 500, 500, 100, false, false, 10f);

            foreach (var player in GameDirector.instance.PlayerList)
            {
                player.playerHealth.health = 0;
                player.PlayerDeath(-1);
            }

            //GameObject.Destroy(transform.root.gameObject);
        }
    }
}
