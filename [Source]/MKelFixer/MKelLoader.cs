using System;
using System.Linq;
using System.Collections.Generic;

using UnityEngine;

using Kopernicus.Components;
using Kopernicus.Configuration;

using SigmaGalacticNeighborhood.Components;


namespace SigmaGalacticNeighborhood
{
    namespace Configuration
    {
        [ExternalParserTarget("Orbit")]
        public class MKelLoader : ExternalParserTargetLoader, IParserEventSubscriber
        {
            public MKelFixer mkelfixer { get; set; }
            public static List<string> ArchivesFixerList = new List<string>();

            [ParserTarget("realReference", optional = true)]
            public string realReference
            {
                get { return mkelfixer.realReference; }
                set { mkelfixer.realReference = value; }
            }
            [ParserTarget("realSMA", optional = true)]
            public NumericParser<double> realSMA
            {
                get { return mkelfixer.realSMA; }
                set { mkelfixer.realSMA = value; }
            }

            void IParserEventSubscriber.Apply(ConfigNode node)
            {
                mkelfixer = generatedBody.celestialBody.gameObject.AddComponent<MKelFixer>();
            }

            void IParserEventSubscriber.PostApply(ConfigNode node)
            {
            }

            public MKelLoader()
            {
            }
        }
    }
}
