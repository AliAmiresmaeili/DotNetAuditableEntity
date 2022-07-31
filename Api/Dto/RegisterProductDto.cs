namespace Api.Dto
{
    public class RegisterProductDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int? CategoryId { get; set; }
    }
}
