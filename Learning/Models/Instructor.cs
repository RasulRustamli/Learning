using Learning.Models.BaseModel;

namespace Learning.Models
{
    public class Instructor:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Work { get; set; }
        public string ImgUrl { get; set; }
    }
}
