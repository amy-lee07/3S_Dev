namespace EventPlus.webAPI.DTO;

public class ComentarioEventoDTO
{
    public string Descricao { get; set; }
    public Guid IdUsuario { get; set; }
    public Guid IdEvento { get; set; }
}
