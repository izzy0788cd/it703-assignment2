namespace HotelWebApp.Models
{
    public class RoomsDTO
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = null!;
        public int RoomTypeId { get; set; }
        public int StatusId { get; set; }
        public bool BookingAvailable { get; set; }
        public string? CarPark { get; set; }
    }
}
