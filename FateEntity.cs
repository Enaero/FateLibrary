
using System.Collections.Generic;

namespace Fate {
    public class FateEntity {
        public string Name {get; private set;}

        protected Dictionary<string, Aspect> _aspects;

        public FateEntity(string name, Aspect[] aspects) {
            Name = name;
            _aspects = aspects.ToDictionary(aspect => aspect.Name, aspect => aspect);
        }

        public Aspect? GetAspect(string name)
        {
            _aspects.TryGetValue(name, out Aspect? result);
            return result;
        }

        public Aspect[] GetAllAspects() 
        {
            return _aspects.Values.ToArray();
        }

        /// <summary>
        /// Adds the aspects to the FateEntity. If an aspect with the same name
        /// already exists in the entity, that aspect will be replaced.
        /// </summary>
        /// <param name="aspect">The aspect to add or replace.</param>
        public void AddAspects(params Aspect[] aspects)
        {
            foreach(Aspect aspect in aspects)
            {
                _aspects[aspect.Name] = aspect;
            }
        }
    }
}