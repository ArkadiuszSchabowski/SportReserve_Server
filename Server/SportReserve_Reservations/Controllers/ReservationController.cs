using Microsoft.AspNetCore.Mvc;
using SportReserve_Reservations.Interfaces;
using SportReserve_Reservations.Models;

namespace SportReserve_Reservations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationAccess _reservationAccess;

        public ReservationController(IReservationAccess reservationAccess)
        {
            _reservationAccess = reservationAccess;
        }

        [HttpPost]
        public async Task<ActionResult> Add(ReservationModel reservation)
        {
            string collectionName = "reservations";

            var collection = _reservationAccess.ConnectToMongo<ReservationModel>(collectionName);
            await collection.InsertOneAsync(reservation);

            return Ok();
        }
    }
}
