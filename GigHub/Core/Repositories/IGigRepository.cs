using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
  public interface IGigRepository
  {
    Gig GetGigAttendances(int gigId);
    IEnumerable<Gig> GetGigsUserAttending(string userId);
    Gig GetGig(int id);
    IEnumerable<Gig> GetUpcomingGigs();
    IEnumerable<Gig> GetUpcomingGigsByArtist(string userId);
    void Add(Gig gig);
    Gig GetGigWithAttendees(int gigId);
  }
}