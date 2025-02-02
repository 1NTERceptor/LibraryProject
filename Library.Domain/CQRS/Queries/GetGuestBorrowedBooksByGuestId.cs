using Library.Domain.Aggregates.Persons;
using MediatR;
using System.Collections.Generic;

namespace Library.Domain.CQRS.Queries
{
    public class GetGuestBorrowedBooksByGuestId : IRequest<IEnumerable<GuestBook>>
    {
        public int GuestId { get; set; }

        public GetGuestBorrowedBooksByGuestId(int guestId)
        {
            GuestId = guestId;
        }
    }
}
