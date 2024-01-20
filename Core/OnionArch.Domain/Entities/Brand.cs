using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities
{
    public class Brand : EntityBase, IEntityBase
    {
        public Brand()
        {

        }

        public Brand(string name)
        {
            Name = name;
        }
        public required string Name { get; set; }

    }
}
