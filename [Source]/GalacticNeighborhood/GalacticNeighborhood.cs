using System;
using System.Linq;
using System.Collections.Generic;

using UnityEngine;

using Kopernicus.Components;
using Kopernicus.Configuration;

//using SigmaGalacticNeighborhood.Components;


namespace SigmaGalacticNeighborhood
{
    namespace Configuration
    {
        [ExternalParserTarget("GalacticNeighborhood")]
        public class GalacticNeighborhood : ExternalParserTargetLoader, IParserEventSubscriber
        {
           // public GalacticNeighborhood galacticneighborhood { get; set; }
            
            void IParserEventSubscriber.Apply(ConfigNode node)
            {
                foreach (SunCoronas corona in generatedBody.scaledVersion.GetComponentsInChildren<SunCoronas>(true))
                {
                    corona.renderer.enabled = false;
                }
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
