namespace HotelWebApp.Models
{
    public class BookingsDTO
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal Price { get; set; }
        public int CreditCardId { get; set; }
        public bool DepositMade { get; set; }
        public string? DepositMethod { get; set; }
        public string DepositStatus { get; set; } = null!;
        public string? BookingReference { get; set; }
    }
}
