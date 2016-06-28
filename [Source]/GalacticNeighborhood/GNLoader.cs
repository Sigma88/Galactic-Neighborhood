using Kopernicus.Configuration;
using GalacticNeighborhoodPlugin.Components;


namespace GalacticNeighborhoodPlugin
{
    namespace Configuration
    {
        [ExternalParserTarget("GalacticNeighborhood")]
        public class GalacticNeighborhoodLoader : ExternalParserTargetLoader, IParserEventSubscriber
        {
            public GalacticNeighborhood GalacticNeighborhood { get; set; }
            
            void IParserEventSubscriber.Apply(ConfigNode node)
            {
                GalacticNeighborhood = generatedBody.celestialBody.gameObject.AddComponent<GalacticNeighborhood>();
            }

            void IParserEventSubscriber.PostApply(ConfigNode node)
            {
            }

            public GalacticNeighborhoodLoader()
            {
            }
        }
    }
}
