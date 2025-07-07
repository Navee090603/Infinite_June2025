namespace TravelLibrary
{
    public class TravelConcession
    {
        public string CalculateConcession(string name, int age, int totalFare)
        {
            if (age <= 5)
            {
                return $"{name}: Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                double discountedFare = totalFare * 0.7; // 30% concession
                return $"{name}: Senior Citizen - Fare after concession: Rs.{discountedFare}";
            }
            else
            {
                return $"{name}: Ticket Booked - Fare: Rs.{totalFare}";
            }
        }
    }
}
