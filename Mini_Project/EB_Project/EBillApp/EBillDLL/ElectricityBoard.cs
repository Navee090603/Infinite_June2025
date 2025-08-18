using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EBillDLL
{
    public class ElectricityBoard
    {
        public void AddBill(ElectricityBill ebill)
        {
            string currentMonth = DateTime.Now.ToString("MMM-yyyy");

            using (SqlConnection connection = DBHandler.GetConnection())
            {
                connection.Open();

                // Check if bill already exists for this month
                string checkQuery = "SELECT COUNT(*) FROM ElectricityBill WHERE ConsumerNumber = @ConsumerNumber AND BillMonth = @BillMonth";
                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@ConsumerNumber", ebill.ConsumerNumber);
                checkCmd.Parameters.AddWithValue("@BillMonth", currentMonth);

                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    throw new Exception("Bill already generated for this month.");
                }

                // Insert new bill
                string query = "INSERT INTO ElectricityBill (ConsumerNumber, UnitsConsumed, BillAmount, BillMonth) " +
                               "VALUES (@ConsumerNumber, @UnitsConsumed, @BillAmount, @BillMonth)";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ConsumerNumber", ebill.ConsumerNumber);
                cmd.Parameters.AddWithValue("@UnitsConsumed", ebill.UnitsConsumed);
                cmd.Parameters.AddWithValue("@BillAmount", ebill.BillAmount);
                cmd.Parameters.AddWithValue("@BillMonth", currentMonth);

                cmd.ExecuteNonQuery();
            }
        }

        public void CalculateBill(ElectricityBill ebill)
        {
            int units = ebill.UnitsConsumed;
            double amount = 0;

            if (units > 1000)
            {
                amount += (units - 1000) * 7.5;
                units = 1000;
            }
            if (units > 600)
            {
                amount += (units - 600) * 5.5;
                units = 600;
            }
            if (units > 300)
            {
                amount += (units - 300) * 3.5;
                units = 300;
            }
            if (units > 100)
            {
                amount += (units - 100) * 1.5;
                units = 100;
            }

            ebill.BillAmount = amount;
        }

        public List<ElectricityBill> Generate_N_BillDetails(int num)
        {
            List<ElectricityBill> bills = new List<ElectricityBill>();

            using (SqlConnection connection = DBHandler.GetConnection())
            {
                connection.Open();

                string query = "SELECT TOP (@Num) b.ConsumerNumber, c.ConsumerName, b.UnitsConsumed, b.BillAmount " +
                              "FROM ElectricityBill b INNER JOIN Customers c ON b.ConsumerNumber = c.ConsumerNumber " +
                              "ORDER BY b.CreatedDate DESC";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Num", num);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ElectricityBill bill = new ElectricityBill();
                    bill.ConsumerNumber = reader["ConsumerNumber"].ToString();
                    bill.ConsumerName = reader["ConsumerName"].ToString();
                    bill.UnitsConsumed = Convert.ToInt32(reader["UnitsConsumed"]);
                    bill.BillAmount = Convert.ToDouble(reader["BillAmount"]);

                    bills.Add(bill);
                }
            }

            return bills;
        }

        public void AddCustomer(ElectricityBill customer)
        {
            using (SqlConnection connection = DBHandler.GetConnection())
            {
                connection.Open();

                string query = "INSERT INTO Customers (ConsumerNumber, ConsumerName) VALUES (@ConsumerNumber, @ConsumerName)";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ConsumerNumber", customer.ConsumerNumber);
                cmd.Parameters.AddWithValue("@ConsumerName", customer.ConsumerName);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAllCustomers()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = DBHandler.GetConnection())
            {
                connection.Open();

                string query = "SELECT ConsumerNumber, ConsumerName, JoinDate FROM Customers ORDER BY JoinDate DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                da.Fill(dt);
            }

            return dt;
        }

        public DataTable GetCustomerNumbers()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = DBHandler.GetConnection())
            {
                connection.Open();

                string query = "SELECT ConsumerNumber FROM Customers ORDER BY ConsumerNumber";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                da.Fill(dt);
            }

            return dt;
        }
    }
}
