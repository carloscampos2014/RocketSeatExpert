using System.ComponentModel.DataAnnotations.Schema;

namespace RocketSeat.Leilao.API.Entities;

[Table("Offers")]
public class Offer
{
    public int Id { get; set; }

    public string CreatedOn { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int ItemId { get; set; }

    public int UserId { get; set; }
}
