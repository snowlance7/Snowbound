using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Snowbound.Valuables
{
    internal class NukeBehavior : MonoBehaviour
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ParticleScriptExplosion particleScriptExplosion;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        // Configs
        float explodeChance = 0.5f;

        public void Explode()
        {
            particleScriptExplosion.Spawn(transform.position, 300f, 500, 500, 100, false, false, 10f);

            //foreach (var player in GameManager.instance.)

            GameObject.Destroy(transform.root.gameObject);
        }
    }
}
