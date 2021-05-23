using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoRentalAssignmentNww
{
    public partial class Form1 : Form
    {
        ControllerTask task = new ControllerTask();
        int ID = 0, show = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // user user or admin click on update customer button

        private void update_customer_button_Click(object sender, EventArgs e)
        {
            if (!rental_cus_ID.Text.Equals("") && !name_c.Text.Equals("") && !email_c.Text.Equals("") && !phone_c.Text.Equals("") && !address_c.Text.Equals(""))
            {
                task.editCustomer(Convert.ToInt32(rental_cus_ID.Text.ToString()),name_c.Text, email_c.Text, phone_c.Text, address_c.Text);
                rental_cus_ID.Text = "";
                name_c.Text = "";
                email_c.Text = "";
                phone_c.Text = "";
                address_c.Text = "";
            }
            else
            {
                MessageBox.Show("Need to fill all details ");
            }

        }

        // user user or admin click on add customer button

        private void add_customer_button_Click(object sender, EventArgs e)
        {
            if (!name_c.Text.Equals("") && !email_c.Text.Equals("") && !phone_c.Text.Equals("") && !address_c.Text.Equals("")) {
                task.registerCustomer(name_c.Text, email_c.Text, phone_c.Text, address_c.Text);
                name_c.Text = "";
                email_c.Text = "";
                phone_c.Text = "";
                address_c.Text = "";
            }
            else {
                MessageBox.Show("Need to fill all details ");
            }
        }


        // user user or admin click on delete customer button
        private void delete_customer_button_Click(object sender, EventArgs e)
        {
            if (!rental_cus_ID.Text.Equals("") && !name_c.Text.Equals("") && email_c.Text.Equals("") && phone_c.Text.Equals("") && address_c.Text.Equals(""))
            {
                task.DelCustomer(Convert.ToInt32(rental_cus_ID.Text.ToString()));
                rental_cus_ID.Text = "";
                name_c.Text = "";
                email_c.Text = "";
                phone_c.Text = "";
                address_c.Text = "";
            }
            else
            {
                MessageBox.Show("Need to fill all details ");
            }
        }

        // user user or admin click on update Issue Movie 
        private void Issue_movie_btn_Click(object sender, EventArgs e)
        {
            if (!Rental_V_ID.Text.Equals("") && !rental_cus_ID.Text.Equals(""))
            {
                task.registerBooking(Rental_V_ID.Text, rental_cus_ID.Text, dateTimePicker1.Text, "Booked");
                rental_cus_ID.Text = "";
               
                rental_cus_ID.Text = "";
                name_c.Text = "";
                email_c.Text = "";
                phone_c.Text = "";
                address_c.Text = "";

                Rental_V_ID.Text = "";
                title_v.Text = "";
                rating_v.Text = "";
                year_v.Text = "";
                copy_v.Text = "";
                price_v.Text = "";
                genre_v.Text = "";
                plot_v.Text = "";



            }
            else {
                MessageBox.Show("you need to select the video or customer ");
            }
        }

        // it will return movie and update record to database

        private void return_movie_btn_Click(object sender, EventArgs e)
        {

            if ( ID>0 && !Rental_V_ID.Text.Equals("") && !rental_cus_ID.Text.Equals(""))
            {
                task.returnBooking(ID,Rental_V_ID.Text, rental_cus_ID.Text, dateTimePicker1.Text,dateTimePicker2.Text);
                rental_cus_ID.Text = "";

                rental_cus_ID.Text = "";
                name_c.Text = "";
                email_c.Text = "";
                phone_c.Text = "";
                address_c.Text = "";

                Rental_V_ID.Text = "";
                title_v.Text = "";
                rating_v.Text = "";
                year_v.Text = "";
                copy_v.Text = "";
                price_v.Text = "";
                genre_v.Text = "";
                plot_v.Text = "";



            }
            else
            {
                MessageBox.Show("you need to select the video or customer ");
            }

        }

        // delete movie from database

        private void del_btn_rental_movie_Click(object sender, EventArgs e)
        {

            if (ID > 0 && !Rental_V_ID.Text.Equals("") && !rental_cus_ID.Text.Equals(""))
            {
                task.DelIssuedMovie(ID);
                rental_cus_ID.Text = "";

                rental_cus_ID.Text = "";
                name_c.Text = "";
                email_c.Text = "";
                phone_c.Text = "";
                address_c.Text = "";

                Rental_V_ID.Text = "";
                title_v.Text = "";
                rating_v.Text = "";
                year_v.Text = "";
                copy_v.Text = "";
                price_v.Text = "";
                genre_v.Text = "";
                plot_v.Text = "";



            }
            else
            {
                MessageBox.Show("you need to select the video or customer ");
            }


        }

        //  user  or admin click on add Video button

        private void Video_add_button_Click(object sender, EventArgs e)
        {
            if (!title_v.Text.Equals("") && !rating_v.Text.Equals("") && !year_v.Text.Equals("") && !copy_v.Text.Equals("") && !price_v.Text.Equals("") && !genre_v.Text.Equals("") && !plot_v.Text.Equals(""))
            {
                task.registerMovie(title_v.Text,rating_v.Text,year_v.Text,copy_v.Text,price_v.Text,genre_v.Text,plot_v.Text);
            
                title_v.Text = "";
                rating_v.Text = "";
                year_v.Text = "";
                copy_v.Text = "";
                price_v.Text = "";
                genre_v.Text = "";
                plot_v.Text = "";
                Rental_V_ID.Text = "";


            }
            else {
                MessageBox.Show("Movie record need to fill ");
            }

        }

        // user user or admin click on update Video button

        private void video_update_button_Click(object sender, EventArgs e)
        {
            if (!Rental_V_ID.Text.Equals("") && !title_v.Text.Equals("") && !rating_v.Text.Equals("") && !year_v.Text.Equals("") && !copy_v.Text.Equals("") && !price_v.Text.Equals("") && !genre_v.Text.Equals("") && !plot_v.Text.Equals(""))
            {
                task.editMovie(Convert.ToInt32(Rental_V_ID.Text),title_v.Text, rating_v.Text, year_v.Text, copy_v.Text, price_v.Text, genre_v.Text, plot_v.Text);
                title_v.Text = "";
                rating_v.Text = "";
                year_v.Text = "";
                copy_v.Text = "";
                price_v.Text = "";
                genre_v.Text = "";
                plot_v.Text = "";
                Rental_V_ID.Text = "";


            }
            else
            {
                MessageBox.Show("Movie record need to fill ");
            }

        }

        // user user or admin click on delete video button

        private void video_delete_button_Click(object sender, EventArgs e)
        {
            if (Rental_V_ID.Text.Equals("") )
            {
                task.DelMovie(Convert.ToInt32(Rental_V_ID.Text));
                title_v.Text = "";
                rating_v.Text = "";
                year_v.Text = "";
                copy_v.Text = "";
                price_v.Text = "";
                genre_v.Text = "";
                plot_v.Text = "";
                Rental_V_ID.Text = "";


            }
            else
            {
                MessageBox.Show("Movie record need to fill ");
            }
        }

        // when user or admin click on customer data show button
        private void show_custumer_Click(object sender, EventArgs e)
        {
            show = 1;
            DataTable tbl = new DataTable();

            task.conn = new SqlConnection(task.loc);

            task.conn.Open();

            task.cmd = new SqlCommand("select * from tblCustomer", task.conn);

            task.DReader = task.cmd.ExecuteReader();

            tbl.Load(task.DReader);

            task.conn.Close();

            data_grid.DataSource = tbl;
        }

        // show video details on clicking show videos button

        private void show_video_Click(object sender, EventArgs e)
        {
            show = 2;
            DataTable tbl = new DataTable();

            task.conn = new SqlConnection(task.loc);

            task.conn.Open();

            task.cmd = new SqlCommand("select * from tblVideo", task.conn);

            task.DReader = task.cmd.ExecuteReader();

            tbl.Load(task.DReader);

            task.conn.Close();

            data_grid.DataSource = tbl;
        }

        private void data_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (show == 1) {
                rental_cus_ID.Text = data_grid.CurrentRow.Cells[0].Value.ToString();
                name_c.Text = data_grid.CurrentRow.Cells[1].Value.ToString();
                email_c.Text = data_grid.CurrentRow.Cells[2].Value.ToString();
                phone_c.Text = data_grid.CurrentRow.Cells[3].Value.ToString();
                address_c.Text = data_grid.CurrentRow.Cells[4].Value.ToString();
            }


            else if (show == 2) {

                Rental_V_ID.Text = data_grid.CurrentRow.Cells[0].Value.ToString();
                title_v.Text = data_grid.CurrentRow.Cells[1].Value.ToString();
                rating_v.Text = data_grid.CurrentRow.Cells[2].Value.ToString();
                year_v.Text = data_grid.CurrentRow.Cells[3].Value.ToString();
                copy_v.Text = data_grid.CurrentRow.Cells[4].Value.ToString();
                price_v.Text = data_grid.CurrentRow.Cells[5].Value.ToString();
                genre_v.Text = data_grid.CurrentRow.Cells[6].Value.ToString();
                plot_v.Text = data_grid.CurrentRow.Cells[7].Value.ToString();
            }
            else if (show==3) {
                ID = Convert.ToInt32( data_grid.CurrentRow.Cells[0].Value.ToString());
                Rental_V_ID.Text = data_grid.CurrentRow.Cells[1].Value.ToString();
                rental_cus_ID.Text = data_grid.CurrentRow.Cells[2].Value.ToString();
                dateTimePicker1.Text = data_grid.CurrentRow.Cells[3].Value.ToString();
            }
            show = 0;
        }

        private void year_v_TextChanged(object sender, EventArgs e)
        {
            try {
                DateTime dateNow = DateTime.Now;

                int Currentyear = dateNow.Year;

                int diffYear = Currentyear - Convert.ToInt32(year_v.Text);
                int cost = 0;
                // MessageBox.Show(diff.ToString());
                if (diffYear >= 5)
                {
                    cost = 2;
                }
                if (diffYear >= 0 && diffYear < 5)
                {
                    cost = 5;
                }

                price_v.Text = "" + cost;
            }
            catch (Exception ex) { 
            
            }
            
        }

        private void good_customer_Click(object sender, EventArgs e)
        {
            task.bestCustomer();
        }

        private void high_ratted_videos_Click(object sender, EventArgs e)
        {
            task.bestVideo();
        }

        private void show_rental_Click(object sender, EventArgs e)
        {
            show = 3;
            DataTable tbl = new DataTable();

            task.conn = new SqlConnection(task.loc);

            task.conn.Open();

            task.cmd = new SqlCommand("select * from tblBooking", task.conn);

            task.DReader = task.cmd.ExecuteReader();

            tbl.Load(task.DReader);

            task.conn.Close();

            data_grid.DataSource = tbl;
        }
    }
}
