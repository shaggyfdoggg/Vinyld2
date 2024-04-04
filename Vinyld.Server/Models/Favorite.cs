using System;
using System.Collections.Generic;

namespace Vinyld.Server.Models;

public partial class Favorite
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? FavoriteItem { get; set; }

    public virtual User? User { get; set; }
}
