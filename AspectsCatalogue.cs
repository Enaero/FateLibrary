using System;
using System.Collections.Generic;
using System.Linq;

namespace Fate {
    public class AspectsCatalogue {
        private static AspectsCatalogue? _singleton = null;
        private Dictionary<string, Aspect> _loadedAspects;

        public static AspectsCatalogue INSTANCE {
            get {
                if (_singleton != null) {
                    return _singleton;
                }

                Dictionary<string, Aspect> aspects = new();
                aspects.Add("Hard as a rock", new Aspect("Hard as a rock"));

                _singleton = new AspectsCatalogue(aspects);
                return _singleton;
            }

            private set {}
        }

        public static void ClearInstance() {
            _singleton = null;
        }

        public Aspect? GetAspect(string name)
        {
            if (_loadedAspects.ContainsKey(name)) {
                return _loadedAspects[name];
            }
            
            Logger.ERROR($"Aspect not found or loaded: {name}");
            return null;
        }

        public List<Aspect> GetAspects(string[] names)
        {
            if (names == null) {
                Logger.ERROR("names is null cannot GetAspects");
                return new();
            }

#pragma warning disable CS8619 // We filter out nulls
            return names.Select(
                name => GetAspect(name)
            )
            .Where(aspect => aspect != null)
            .ToList();
#pragma warning restore CS8619 // Nulls are filtered out.
        }

        public void AddAspect(Aspect aspect)
        {
            _loadedAspects.Add(aspect.Name, aspect);
        }

        private AspectsCatalogue(
            Dictionary<string, Aspect> loadedAspects) 
        {
            _loadedAspects = loadedAspects;
        }
    }
}