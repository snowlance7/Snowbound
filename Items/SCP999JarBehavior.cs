using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Snowbound.Items
{
    internal class SCP999JarBehavior : MonoBehaviour
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public PhysGrabObject grabObject;
        public ItemEquippable itemEquippable;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        float timeSinceLastHeal;

        int healAmountPerHeal = 1;
        float secondsPerHeal = 3f;

        public void Update()
        {
            timeSinceLastHeal += Time.deltaTime;

            if (timeSinceLastHeal <= secondsPerHeal) { return; }

            timeSinceLastHeal = 0f;

            if ((itemEquippable.isEquipped || grabObject.playerGrabbing.Count > 0) && RunManager.instance.levelCurrent != RunManager.instance.levelShop)
            {
                if (itemEquippable.isEquipped)
                {
                    itemEquippable.latestOwner.playerAvatar.playerHealth.Heal(healAmountPerHeal);
                }
                else
                {
                    foreach (var player in grabObject.playerGrabbing)
                    {
                        player.playerAvatar.playerHealth.Heal(healAmountPerHeal);
                    }
                }
            }
        }
    }
}
