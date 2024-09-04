namespace JogoMemoria.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataCadastro { get; set; }
    public int Pontuacao { get; set; }
    public  DateTime DataUltimaJogada { get; set; }
    public DateTime DataJogadaMaiorPontuacao { get; set; }
    public int MaiorPontuacao { get; set; }
}
