namespace CadastroLivros.Models  
{
    public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public int Ano { get; set; }
    public string ImagemUrl { get; set; } = string.Empty; 
}

 }

