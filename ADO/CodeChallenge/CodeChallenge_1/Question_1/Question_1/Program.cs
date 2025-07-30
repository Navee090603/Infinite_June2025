using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Question_1
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;

        static void Main(string[] args)
        {

            //For Question - 1

            //InsertEmployeeDetailsProc();
            //DisplayEmployeeDetails();


            //For Question - 2

            DisplayEmployeeDetails_Update();
            UpdateEmpSalaryProc();
            DisplayEmployeeDetails_Update();
            Console.ReadLine();
        }

        static SqlConnection GetConnection()
        {
            con = new SqlConnection("Data Source = ICS-LT-DQW1DN3\\SQLEXPRESS; Initial Catalog = CodeChallenge; user id = sa; password = Naveenmessi09@");
            con.Open();
            return con;
        }

        //For INsert Method
        static void InsertEmployeeDetailsProc()
        {
            try
            {
                con = GetConnection();

                // User Details
                Console.Write("Enter Employee Name:");
                string name = Console.ReadLine();

                Console.Write("Enter Salary:");
                float salary = float.Parse(Console.ReadLine());

                Console.Write("Enter Gender:");
                string gender = Console.ReadLine();

                cmd = new SqlCommand("sp_InsertEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Input parameters
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Salary", salary);
                cmd.Parameters.AddWithValue("@Gender", gender);

                // Output parameters
                SqlParameter paramEmpId = new SqlParameter("@GeneratedEmpId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(paramEmpId);

                SqlParameter paramNetSalary = new SqlParameter("@NetSalary", SqlDbType.Float)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(paramNetSalary);

                cmd.ExecuteNonQuery();

                // Show output
                Console.WriteLine("\n*******Newly Inserted Data********");
                Console.WriteLine("\nEmpId : " +  paramEmpId.Value);
                Console.WriteLine("Net Salary after 10% deduction: " + paramNetSalary.Value);
                Console.WriteLine();
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        //For Display Method Question-1

        static void DisplayEmployeeDetails()
        {
            try
            {
                con = GetConnection();
                cmd = new SqlCommand("SELECT * FROM Employee_Details", con);
                dr = cmd.ExecuteReader();

                Console.WriteLine("*******All Employee Details*******");
                Console.WriteLine("\nEmpId\tName\tSalary\tNetSalary\tGender");
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["EmpId"]}\t{dr["Name"]}\t{dr["Salary"]}\t{dr["NetSalary"]}\t{dr["Gender"]}");
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                if (dr != null && !dr.IsClosed)
                    dr.Close();
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        //For Update Method-Question-2

        static void UpdateEmpSalaryProc()
        {
            try
            {
                con = GetConnection();

                Console.Write("\nEnter Employee ID to update salary (+100): ");
                int empid = Convert.ToInt32(Console.ReadLine());

                cmd = new SqlCommand("sp_UpdateEmpSalary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", empid);

                SqlParameter updatedSalaryParam = new SqlParameter("@updatedSalary", SqlDbType.Float)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(updatedSalaryParam);

                cmd.ExecuteNonQuery();

                double updatedSalary = Convert.ToDouble(updatedSalaryParam.Value);
                Console.WriteLine();
                Console.WriteLine($"Salary updated to {updatedSalary} for Employee ID {empid}");

                // Display the employee details whose salary was updated
                DisplayEmployeeById(empid);
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        //For Display the Updated Employee-Question-2

        static void DisplayEmployeeById(int empid)
        {
            try
            {
                con = GetConnection();
                cmd = new SqlCommand("SELECT * FROM Employee_Details WHERE Empid = @eid", con);
                cmd.Parameters.AddWithValue("@eid", empid);
                dr = cmd.ExecuteReader();

                Console.WriteLine("\n********Updated Employee*********");
                Console.WriteLine("\nEmpId\tName\tGender\tSalary");
                if (dr.Read())
                {
                    Console.WriteLine($"\n{dr["Empid"]}\t{dr["Name"]}\t{dr["Gender"]}\t{dr["Salary"]}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("No Employee found with the given EmpID.");
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                if (dr != null && !dr.IsClosed)
                    dr.Close();
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        //Display For the updated employee table -- Question-2

        static void DisplayEmployeeDetails_Update()
        {
            try
            {
                con = GetConnection();
                cmd = new SqlCommand("SELECT * FROM Employee_Details", con);
                dr = cmd.ExecuteReader();

                Console.WriteLine("*******All Employee Details*******");
                Console.WriteLine("\nEmpId\tName\tSalary\tGender");
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["EmpId"]}\t{dr["Name"]}\t{dr["Salary"]}\t{dr["Gender"]}");
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                if (dr != null && !dr.IsClosed)
                    dr.Close();
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
