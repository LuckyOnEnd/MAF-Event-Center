using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Domain.ValueObjects
{
    public sealed record GameId
    {
        public Guid Id { get; set; }

        public GameId(Guid id)
        {
            if(id == Guid.Empty)
                throw new ArgumentNullException("id");

            Id = id;
        }

        public static GameId Create() => new(Guid.NewGuid());

        public static implicit operator Guid(GameId gameId) => gameId.Id;
        public static implicit operator GameId(Guid gameId) => new(gameId);
    }
}
