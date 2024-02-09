using RocketSeat.Leilao.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketSeat.Leilao.API.Entities;

[Table("Items")]
public class Item
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Brand { get; set; } = string.Empty;

    public Condition Condition { get; set; }

    public decimal BasePrice { get; set; }

    public int AuctionId { get; set; }
}
