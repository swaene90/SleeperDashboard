using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SleeperDashboard.Data.Entity.Player;

[PrimaryKey(nameof(Id))]
public class FantasyPosition
{
    public int Id { get; set; }
    
    [MaxLength(255)]
    public string? Position { get; set; }
}