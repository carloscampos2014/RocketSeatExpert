using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketSeat.Leilao.API.Entities;

[Table("Auctions")]
public class Auction
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime Starts { get; set; }

    public DateTime Ends { get; set; }

    public List<Item> Items { get; set; } = [];
}
