using aspnetzabota.Admin.Database.Entities;
using System;
using System.Threading.Tasks;

namespace aspnetzabota.Admin.Database.Repository.Tokens
{
    public interface ITokensRepository
    {
        Task<Jwts> IssueToken(int id, DateTimeOffset expirationDate);
        Task WriteBody(int tokenId, string token);
        Task<Jwts> GetById(int id, bool trackChanges = false);
        Task<bool> RevokeByTokenId(int actorId, int tokenId);
    }
}
