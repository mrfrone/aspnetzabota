using System;

namespace aspnetzabota.Admin.Datamodel.Tokens
{
    public class Jwt
    {
        public int Id { get; set; }

        public string Token { get; set; }

        public DateTimeOffset Expires { get; set; }
    }
}