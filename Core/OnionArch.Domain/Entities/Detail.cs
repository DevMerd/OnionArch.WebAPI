using OnionArch.Domain.Common;

namespace OnionArch.Domain.Entities
{
    public class Detail : EntityBase, IEntityBase
    {
        public Detail()
        {

        }
        public Detail(string title, string description, int categoryId)
        {
            Title = title;
            Description = description;
            CategoryId = categoryId;
        }
        public string Description { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
