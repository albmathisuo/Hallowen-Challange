using Dapper;
using MySql.Data.MySqlClient;
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
    public partial class FormFilms : Form
    {
        User _selectedBook;

        private const string connectionString = "Server=localhost;Database=sakila;Uid=staff;Pwd=$up3r$3cr3t";
        public FormFilms(User selectedBook)
        {
            InitializeComponent();
            // TODO: Connect to database,
            // get details of book and show them in form
            // SELECT category.name, language.name, film.description  
            // FROM sakila.film JOIN language ON film.language_id = language.language_id 
            // JOIN film_category ON film.film_id = film_category.film_id 
            // JOIN category ON film_category.category_id = category.category_id;
            MySqlConnection con = new MySqlConnection(connectionString);
            string sql = $"SELECT film.title, category.name, language.name, film.description  FROM sakila.film JOIN language ON film.language_id = language.language_id JOIN film_category ON film.film_id = film_category.film_id JOIN category ON film_category.category_id = category.category_id;";
            // La string es un SELECT en la base de datos donde se busca por el campo del nombre, el qual se le introduce en el formDesign.
            selectedBook = con.Query<User>(sql).ToList(); // Coje los datos i los pone en la lista users
            FilmDescription.DataSource = selectedBook;
            FilmDescription.DisplayMember = "FullinfoDescription";  //Expone los datoss en el ListBox de una tabla en el FormDesign.
            con.Close();
        }
    }
}
