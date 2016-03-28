using System;
using System.Linq;
using System.Collections.Generic;

using UnityEngine;

using Kopernicus.Components;
using Kopernicus.Configuration;



namespace SigmaGalacticNeighborhood
{
    namespace Configuration
    {
        [ExternalParserTarget("GalacticNeighborhood")]
        public class GalacticNeighborhood : ExternalParserTargetLoader, IParserEventSubscriber
        {
            void IParserEventSubscriber.Apply(ConfigNode node)
            {
                foreach (SunCoronas corona in generatedBody.scaledVersion.GetComponentsInChildren<SunCoronas>(true))
                {
                    corona.renderer.enabled = false;
                }
                generatedBody.scaledVersion.renderer.enabled = false;
                Debug.Log("GNLOG: deleted");
            }

            void IParserEventSubscriber.PostApply(ConfigNode node)
            {
            }

            public GalacticNeighborhood()
            {
            }
        }
    }
}
