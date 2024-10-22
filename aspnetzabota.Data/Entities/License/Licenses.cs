﻿using System.Collections.Generic;

namespace aspnetzabota.Content.Database.Entities
{
    public class Licenses
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<LicensesPhoto> Photo { get; set; }
    }
}
