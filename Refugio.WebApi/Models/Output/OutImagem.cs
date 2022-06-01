namespace Refugio.WebApi.Models.Output
{
    public class OutImagem
    {
        public int Id { get; set; }
        public int EvolucaoId { get; set; }
        public string Nome { get; set; }
        public byte[] BytesImagem { get; set; }
    }
}
