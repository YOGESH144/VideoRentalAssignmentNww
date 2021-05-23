using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoRentalAssignmentNww
{
   public class ControllerTask
    {
        //create the instance of the SQL Connection class
        public SqlConnection conn;

        //write the connection sstring to assthe data form one for to the database 
        public String loc = "Data Source=DESKTOP-G2UGPMF\\SQLEXPRESS;Initial Catalog=VideoAssignTask;Integrated Security=True";

        //command are use to excute the command of isnert , delete , update
        public SqlCommand cmd;

        //data reader is used to read thedata from the database table 
        public SqlDataReader DReader;

        public void registerCustomer(String Name, String Email,String Phone, String Address) {
            conn = new SqlConnection(loc);
            conn.Open();
            String query = "insert into tblCustomer(Name,Email,Phone,Address)values(@Name,@Email,@Phone,@Address)";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Phone", Email);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Customer Record is saved  ");
        }
        public void editCustomer(int cID, String Name, String Email, String Phone, String Address) {
           
            conn = new SqlConnection(loc);
            conn.Open();
            String query = "update  tblCustomer set Name=@Name,Email=@Email,Phone=@Phone,Address=@Address where cID=@cID";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@cID", cID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Phone", Email);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Customer Record is Edited  ");

        }

        public void DelCustomer(int cID)
        {

            conn = new SqlConnection(loc);
            conn.Open();
            String query = "delete from tblCustomer  where cID=@cID";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@cID", cID);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Customer Record is Removed  ");

        }


        public void registerBooking(String vID, String cID, String bookingDt, String returnDt)
        {
            conn = new SqlConnection(loc);
            conn.Open();
            String query = "insert into tblBooking(vID,cID,bookingDt,returnDt)values(@vID,@cID,@bookingDt,@returnDt)";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@vID",vID);
            cmd.Parameters.AddWithValue("@cID",cID);
            cmd.Parameters.AddWithValue("@bookingDt",bookingDt);
            cmd.Parameters.AddWithValue("@returnDt",returnDt);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Movie is isssued   ");
        }
        public void returnBooking(int bID, String vID, String cID, String bookingDt, String returnDt)
        {

            conn = new SqlConnection(loc);
            conn.Open();
            String query = "update tblBooking set vID=@vID,cID=@cID,bookingDt=@bookingDt,returnDt=@returnDt where bID=@bID";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@bID", bID);
            cmd.Parameters.AddWithValue("@vID",vID);
            cmd.Parameters.AddWithValue("@cID", cID);
            
            cmd.Parameters.AddWithValue("@bookingDt",bookingDt);
            cmd.Parameters.AddWithValue("@returnDt",returnDt);
            
            cmd.ExecuteNonQuery();
            conn.Close();


            DataTable tbl = new DataTable();

            conn = new SqlConnection(loc);

            conn.Open();

            cmd = new SqlCommand("select * from tblVideo where vID="+Convert.ToInt32(vID)+"", conn);

            DReader = cmd.ExecuteReader();

            tbl.Load(DReader);

            conn.Close();

            int price = Convert.ToInt32(tbl.Rows[0]["price"].ToString());



            DateTime current_date = DateTime.Now;

            //convert the old date from string to Date fromat
            DateTime prev_date = Convert.ToDateTime(bookingDt);


            //get the difference in the days fromat
            String Daysdiff = (current_date - prev_date).TotalDays.ToString();


            // calculate the round off value 
            Double DaysInterval = Math.Round(Convert.ToDouble(Daysdiff));



            int total =Convert.ToInt32( price * DaysInterval);

            MessageBox.Show("Issues movie is returned  and bill is $"+total);

        }

        public void DelIssuedMovie(int bID)
        {

            conn = new SqlConnection(loc);
            conn.Open();
            String query = "delete from tblBooking  where bID=@bID";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@bID", bID);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Booking Record is removed   ");

        }




        public void registerMovie(String title,String year,String ratting,String copy,String price,String genre,String plot)
        {
            conn = new SqlConnection(loc);
            conn.Open();
            String query = "insert into tblVideo(title,year,ratting,copy,price,genre,plot)values(@title,@year,@ratting,@copy,@price,@genre,@plot)";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@title",title);
            cmd.Parameters.AddWithValue("@year",year);
            cmd.Parameters.AddWithValue("@ratting",ratting);
            cmd.Parameters.AddWithValue("@copy", copy);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@genre", genre);
            cmd.Parameters.AddWithValue("@plot", plot);

            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Movie is record  ");
        }
        public void editMovie(int vID, String title, String year, String ratting, String copy, String price, String genre, String plot)
        {

            conn = new SqlConnection(loc);
            conn.Open();

            String query = "update tblVideo set title=@title,year=@year,ratting=@ratting,copy=@copy,price=@price,genre=@genre,plot=@plot where vID=@vID";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@vID",vID);
            cmd.Parameters.AddWithValue("@title", title);

            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@ratting", ratting);
            cmd.Parameters.AddWithValue("@copy", copy);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@genre", genre);
            cmd.Parameters.AddWithValue("@plot", plot);

            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Movie record is Edited ");

        }

        public void DelMovie(int vID)
        {

            conn = new SqlConnection(loc);
            conn.Open();
            String query = "delete from tblMovie  where vID=@vID";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@vID", vID);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Movie is removed   ");

        }

        public void bestCustomer() {
            int x = 0, y = 0, cunt = 0;
            String Name = "";




            DataTable tbl = new DataTable();

            conn = new SqlConnection(loc);

            conn.Open();

            cmd = new SqlCommand("select * from tblCustomer", conn);

            DReader = cmd.ExecuteReader();

            tbl.Load(DReader);

            conn.Close();


            for (x = 0; x < tbl.Rows.Count; x++)
            {
                DataTable tblrentl = new DataTable();

                conn = new SqlConnection(loc);

                conn.Open();

                cmd = new SqlCommand("select * from tblBooking where cID=" + Convert.ToInt32(tbl.Rows[x]["cID"]) + "", conn);

                DReader = cmd.ExecuteReader();

                tblrentl.Load(DReader);

                conn.Close();
                if (tblrentl.Rows.Count > cunt)
                {

                    Name = tbl.Rows[x]["Name"].ToString();
                    cunt = tblrentl.Rows.Count;

                }

            }


            MessageBox.Show("Best Customer Name  is ==" + Name);




        }

        // showing best video  

        public void bestVideo() {

            int x = 0, y = 0, cunt = 0;
            String Name = "";




            DataTable tbl = new DataTable();

            conn = new SqlConnection(loc);

            conn.Open();

            cmd = new SqlCommand("select * from tblVideo", conn);

            DReader = cmd.ExecuteReader();

            tbl.Load(DReader);

            conn.Close();


            for (x = 0; x < tbl.Rows.Count; x++)
            {
                DataTable tblrentl = new DataTable();

                conn = new SqlConnection(loc);

                conn.Open();

                cmd = new SqlCommand("select * from tblBooking where vID=" + Convert.ToInt32(tbl.Rows[x]["vID"]) + "", conn);

                DReader = cmd.ExecuteReader();

                tblrentl.Load(DReader);

                conn.Close();
                if (tblrentl.Rows.Count > cunt)
                {

                    Name = tbl.Rows[x]["title"].ToString();
                    cunt = tblrentl.Rows.Count;

                }

            }


            MessageBox.Show("Best Video Name  is ==" + Name);





        }

    }
}
