using Microsoft.AspNetCore.Mvc;

namespace ListaDeDesenhos.Models
{
    public enum Material
    {
        Giz,
        Caneta,
        LapisDeCor,
        LapisGrafite,
        Tinta
    }

    public class Desenho
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public DateTime Data { get; set; }
        public Material Material { get; set; }
        public required string Descricao { get; set; }
        public int NotaDesempenho { get; set; }
    }
}

