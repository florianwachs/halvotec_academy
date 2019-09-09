using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSample.Abstract
{
    public abstract class Entity : IEquatable<Entity>
    {
        public string Id { get; set; }

        protected Entity()
        {
        }

        public Entity(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("id must be provided", nameof(id));
            }
            Id = id;
        }

        public bool Equals(Entity other)
        {
            if (other == null || GetType() != other.GetType())
            {
                return false;
            }

            return Id == other.Id;
        }

        public override bool Equals(object obj) => Equals(obj as Entity);

        public override int GetHashCode() => Id != null ? Id.GetHashCode() : 0;

        public static bool operator ==(Entity left, Entity right) => Equals(left, right);
        public static bool operator !=(Entity left, Entity right) => !Equals(left, right);

    }
}
