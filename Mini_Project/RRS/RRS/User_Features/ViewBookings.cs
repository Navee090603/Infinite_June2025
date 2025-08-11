using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace RRS.User_Features
{
    public class ViewBookings
    {
        public static int? loggedInUserId { get; set; }

        public static void viewBookings()
        {
            if (loggedInUserId == null)
            {
                Console.WriteLine("Please login first to view bookings.");
                return;
            }

            try
            {
                Console.Clear();
                Console.WriteLine("========== YOUR BOOKINGS ==========\n");

                var ds = DataAccess.Instance.ExecuteDataSet(
                    "sp_GetUserBookings",
                    new SqlParameter("@UserId", loggedInUserId),
                    new SqlParameter("@BookingStatus", DBNull.Value),
                    new SqlParameter("@PageNumber", 1),
                    new SqlParameter("@PageSize", 10)
                );

                var dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("No bookings found.");
                    return;
                }

                foreach (DataRow row in dt.Rows)
                {
                    string pnr = row["pnr_number"].ToString();
                    string trainName = row["train_name"].ToString();
                    string date = ((DateTime)row["journey_date"]).ToString("yyyy-MM-dd");
                    decimal amount = Convert.ToDecimal(row["total_amount"]);
                    int count = Convert.ToInt32(row["passenger_count"]);
                    string amountStr = $"₹{amount:N2}";

                    Console.WriteLine($"PNR         : {pnr}");
                    Console.WriteLine($"Train       : {trainName}");
                    Console.WriteLine($"Journey Date: {date}");
                    Console.WriteLine($"Amount      : {amountStr}");
                    Console.WriteLine($"Passengers  : {count}");
                    Console.WriteLine();

                    var passengers = DataAccess.Instance.ExecuteTable(
                        "SELECT name, age, gender, seat_type, seat_number, coach_number, fare_paid, status FROM passengers WHERE booking_id = @booking_id",
                        new SqlParameter("@booking_id", row["booking_id"])
                    );

                    if (passengers.Rows.Count > 0)
                    {
                        Console.WriteLine("Passenger Details:");
                        Console.WriteLine($"{"Name",-15} {"Age",3} {"Gender",-6} {"Type",-6} {"Coach",-5} {"Seat",-4} {"Fare",8} {"Status",-10}");
                        Console.WriteLine(new string('-', 65));

                        foreach (DataRow prow in passengers.Rows)
                        {
                            string name = prow["name"].ToString();
                            string age = prow["age"].ToString();
                            string gender = prow["gender"].ToString();
                            string type = prow["seat_type"].ToString();
                            string coach = prow["coach_number"].ToString();
                            string seat = prow["seat_number"].ToString();
                            string fare = $"₹{Convert.ToDecimal(prow["fare_paid"]):N2}";
                            string status = prow["status"].ToString();

                            Console.WriteLine($"{name,-15} {age,3} {gender,-6} {type,-6} {coach,-5} {seat,-4} {fare,8} {status,-10}");
                        }
                    }

                    Console.WriteLine("\n" + new string('=', 40) + "\n");
                }

                int totalRecords = Convert.ToInt32(ds.Tables[1].Rows[0]["totalrecords"]);
                Console.WriteLine($"Total Bookings: {totalRecords}\n");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
