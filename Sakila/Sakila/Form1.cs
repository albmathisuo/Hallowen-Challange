using MySql.Data.MySqlClient;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sakila
{
    public partial class Form1 : Form
    {
        private const string connectionString = "Server=localhost;Database=sakila;Uid=staff;Pwd=$up3r$3cr3t";
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Members> users = new List<Members>();
            MySqlConnection con = new MySqlConnection(connectionString);
            string sql = $"SELECT username FROM film WHERE username LIKE '{UserText.Text}' AND WHERE password LIKE '{PasswdText.Text}'";
            // La string es un SELECT en la base de datos donde se busca por el campo del nombre, el qual se le introduce en el formDesign.
            users = con.Query<Members>(sql).ToList(); // Coje los datos i los pone en la lista users
            UsernameBox.DataSource = users;
            UsernameBox.DisplayMember = "Fullinfo";  //Expone los datoss en el ListBox de una tabla en el FormDesign.
            con.Close();

            /*if (users.Contains) // Username
            {
                pictureBox1.Hide();
            }
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                List<User> users = new List<User>();
                MySqlConnection con = new MySqlConnection(connectionString);
                string sql = $"SELECT film_id, title FROM film WHERE title LIKE '%{SearchText.Text} %'";
                // La string es un SELECT en la base de datos donde se busca por el campo del nombre, el qual se le introduce en el formDesign.
                users = con.Query<User>(sql).ToList(); // Coje los datos i los pone en la lista users
                ListBox.DataSource = users;
                ListBox.DisplayMember = "Fullinfo";  //Expone los datoss en el ListBox de una tabla en el FormDesign.
                con.Close();
                // Cierra la conexión.
            }
            else
            {
                List<User> users = new List<User>();
                MySqlConnection con = new MySqlConnection(connectionString);
                string sql = $"SELECT film_id, title FROM film WHERE title LIKE '%{SearchText.Text}%'";
                // La string es un SELECT en la base de datos donde se busca por el campo del nombre, el qual se le introduce en el formDesign.
                users = con.Query<User>(sql).ToList(); // Coje los datos i los pone en la lista users
                ListBox.DataSource = users;
                ListBox.DisplayMember = "Fullinfo";  //Expone los datoss en el ListBox de una tabla en el FormDesign.
                con.Close();
                // Cierra la conexión.
            }

        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            User selectedBook = ListBox.SelectedItem as User;
            FormFilms bookDetailsForm =
                new FormFilms(selectedBook);

            //Button prop DialogResult

            DialogResult result = bookDetailsForm.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                //this.txtResult.Text = testDialog.TextBox1.Text;
            }
            else if (result == DialogResult.Cancel)
            {
                //this.txtResult.Text = "Cancelled";

            }
            bookDetailsForm.Dispose();
        }
    }
}
