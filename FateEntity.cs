
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Fate {
    public class FateEntity {
        /// <summary>
        /// Names should be unique per entity. If two entities have the same
        /// name they might be treated as the same entity.
        /// </summary>
        public string Name {get; private set;}

        public string DisplayName {
            get {
                return Name;
            }
            private set {}
        }

        public Aspect[] Aspects {
            get {
                return _Aspects.Values.ToArray();
            }
            private set {}
        }
        protected Dictionary<string, Aspect> _Aspects;

        public FateEntity(string name, Aspect[] aspects) {
            Name = name;
            _Aspects = aspects.ToDictionary(aspect => aspect.Name, aspect => aspect);
        }

        public Aspect? GetAspect(string name)
        {
            _Aspects.TryGetValue(name, out Aspect? result);
            return result;
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
                _Aspects[aspect.Name] = aspect;
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is FateEntity fateObj)
            {
                if (!Name.Equals(fateObj.Name))
                {
                    return false;
                }


                if (Aspects.Length != fateObj.Aspects.Length)
                {
                    return false;
                }

                for (int i = 0; i < Aspects.Length; i++)
                {
                    if (!Aspects[i].Equals(fateObj.Aspects[i])) 
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}