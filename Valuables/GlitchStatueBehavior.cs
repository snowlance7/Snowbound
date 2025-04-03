using REPOLib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Snowbound.Valuables
{
    internal class GlitchStatueBehavior : MonoBehaviour
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Material BaldMaterial;
        public SkinnedMeshRenderer renderer;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void Baldify()
        {
            renderer.material = BaldMaterial;
        }
    }
}
