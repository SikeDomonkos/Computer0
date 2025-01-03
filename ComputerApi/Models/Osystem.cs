﻿using System;
using System.Collections.Generic;

namespace ComputerApi.Models;

public partial class Osystem
{
    internal string type;

    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Comp> Comps { get; set; } = new List<Comp>();
}
