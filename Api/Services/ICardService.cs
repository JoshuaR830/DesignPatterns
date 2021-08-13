using System.Collections;
using System.Collections.Generic;
using Common;

namespace Api.Services
{
    // Serve list of cards for primary player
    public interface ICardService
    {
        // Don't need to specify the type - this is more decoupled
        IEnumerable<Card> FetchCards();
    }
}