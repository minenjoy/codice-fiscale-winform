using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Reflection;

namespace cod_fiscale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = "";
            string cfnome = "";
            string cognome = "";
            string cfcognome = "";
            string data = "";
            string[] arrdatastring = new string[3];
            int[] arrdata = new int[3];
            bool d = false;
            bool y = false;
            string cfgiorno = "";
            string cfmese = "";
            string cfanno = "";
            string sesso = "";
            string cfcomune = "";
            string ver = "";
            string cf = "";
            string path = Environment.CurrentDirectory;
            DataRow[] finddata;


            if (textBox1.Text==""|| textBox2.Text == ""|| textBox3.Text == "")
            {
                MessageBox.Show("compila tutti i campi");
            }
            
            
            
            nome = textBox2.Text;

            nome = nome.ToUpper();
            string[] arrnome = new string[nome.Length];
            string[] consnome = new string[nome.Length];
            int count = 0;
            int countvoc = 0;

            for (int i = 0; i < nome.Length; i++)
            {
                arrnome[i] = nome.Substring(i, 1);
                if (arrnome[i] != "A" && arrnome[i] != "E" && arrnome[i] != "I" && arrnome[i] != "O" && arrnome[i] != "U" && arrnome[i] != " " && arrnome[i] != "'")
                {
                    consnome[count] = arrnome[i];
                    //Console.WriteLine(consnome[count]);
                    count = count + 1;
                }
            }
            Array.Resize(ref consnome, count);
            //Console.WriteLine(consnome.Length);
            if (consnome.Length >= 4)
            {
                cfnome = consnome[0] + consnome[2] + consnome[3];
                //   Console.WriteLine(cfnome);
            }
            else if (consnome.Length == 3)
            {
                cfnome = consnome[0] + consnome[1] + consnome[2];
                //  Console.WriteLine(cfnome);
            }
            else
            {
                for (int i = 0; i < consnome.Length; i++)
                {
                    cfnome += consnome[i];
                    countvoc = countvoc + 1;

                }

                for (int i = 0; i < arrnome.Length; i++)
                {
                    if (arrnome[i] == "A" || arrnome[i] == "E" || arrnome[i] == "I" || arrnome[i] == "O" || arrnome[i] == "U")
                    {
                        cfnome += arrnome[i];
                        countvoc = countvoc + 1;

                    }
                    if (countvoc == 3)
                    {
                        break;
                    }
                }


            }

                    cognome = textBox1.Text;

            cognome = cognome.ToUpper();
            string[] arrcogn = new string[cognome.Length];
            string[] conscogn = new string[cognome.Length];
            count = 0;
            countvoc = 0;

            for (int i = 0; i < cognome.Length; i++)
            {
                arrcogn[i] = cognome.Substring(i, 1);
                if (arrcogn[i] != "A" && arrcogn[i] != "E" && arrcogn[i] != "I" && arrcogn[i] != "O" && arrcogn[i] != "U" && arrcogn[i] != " " && arrcogn[i] != "'")
                {
                    conscogn[count] = arrcogn[i];

                    count = count + 1;
                }
            }
            Array.Resize(ref conscogn, count);

            if (conscogn.Length >= 3)
            {
                cfcognome = conscogn[0] + conscogn[1] + conscogn[2];

            }
            else
            {
                for (int i = 0; i < conscogn.Length; i++)
                {
                    cfcognome += conscogn[i];
                    countvoc = countvoc + 1;

                }

                for (int i = 0; i < arrcogn.Length; i++)
                {
                    if (arrcogn[i] == "A" || arrcogn[i] == "E" || arrcogn[i] == "I" || arrcogn[i] == "O" || arrcogn[i] == "U")
                    {
                        cfcognome += arrcogn[i];
                        countvoc = countvoc + 1;

                    }
                    if (countvoc == 3)
                    {
                        break;
                    }
                }


            }

            if (radioButton1.Checked)
            {
                sesso = "M";
            }
            else if (radioButton2.Checked)
            {
                sesso = "F";
            }
            else
            {
                MessageBox.Show("indica il tuo sesso");
            }



            do
            {

                data = dateTimePicker1.Text;
                arrdatastring = data.Split(new char[] { '/' });
                arrdata[0] = Int32.Parse(arrdatastring[0]);
                arrdata[1] = Int32.Parse(arrdatastring[1]);
                arrdata[2] = Int32.Parse(arrdatastring[2]);

               

                if (arrdata[1] == 11 || arrdata[1] == 4 || arrdata[1] == 6 || arrdata[1] == 9)
                {
                    if (arrdata[0] > 0 && arrdata[0] <= 30)
                    {
                        d = true;
                    }
                }
                else if (arrdata[1] == 2)
                {
                    if (arrdata[0] > 0 && arrdata[0] <= 28)
                    {
                        d = true;
                    }
                }
                else if (arrdata[1] == 1 || arrdata[1] == 3 || arrdata[1] == 5 || arrdata[1] == 7 || arrdata[1] == 8 || arrdata[1] == 12)
                {
                    if (arrdata[0] > 0 && arrdata[0] <= 31)
                    {
                        d = true;
                    }
                }
                if (arrdata[2] > 1910 && arrdata[2] <= 2023)
                {
                    y = true;
                }
            } while (d == false && y == false);
            
            if (sesso == "M")
            {
                cfgiorno = arrdatastring[0];
            }
            else if (sesso == "F")
            {
                arrdata[0] = arrdata[0] + 40;
                cfgiorno = arrdata[0].ToString();
            }

         
            

            switch (arrdata[1])
            {
                case 1:
                    cfmese = "A";
                    break;
                case 2:
                    cfmese = "B";
                    break;
                case 3:
                    cfmese = "C";
                    break;
                case 4:
                    cfmese = "D";
                    break;
                case 5:
                    cfmese = "E";
                    break;
                case 6:
                    cfmese = "H";
                    break;
                case 7:
                    cfmese = "L";
                    break;
                case 8:
                    cfmese = "M";
                    break;
                case 9:
                    cfmese = "P";
                    break;
                case 10:
                    cfmese = "R";
                    break;
                case 11:
                    cfmese = "S";
                    break;
                case 12:
                    cfmese = "T";
                    break;
            }

            cfanno = arrdatastring[2];

            OleDbConnection oleDbConnection = null;
            oleDbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+path+@"\comuni.accdb;Persist Security Info=True");
            DataTable dt = new DataTable();
            OleDbDataReader reader = null;
            reader = null;
            OleDbCommand cmd = null;
                cmd =new OleDbCommand ("SELECT Campo2 FROM Comuni WHERE Campo1='"+textBox3.Text+"'" ,oleDbConnection);
            oleDbConnection.Open ();

            try
            {
            reader=cmd.ExecuteReader ();

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                MessageBox.Show("errore inaspettato");
                oleDbConnection.Close();
                return;
            }
            
            
            dt.Clear();
            dt.Load (reader);


            finddata = dt.Select();

            try 
                { 
                    cfcomune = finddata[0][0].ToString();

                }
                catch (Exception)
                {
                    MessageBox.Show("comune errato, riprova");
                oleDbConnection.Close ();
                return;
                  
                }
           
            oleDbConnection.Close();

            //ultima cifra
        
        string cfparziale = cfcognome + cfnome + cfanno + cfmese + cfgiorno + cfcomune;

            string query;
            string[] arrdispari =new string[8];
            string[] arrpari = new string[7];
            string[] cfarrparziale = new string[cfparziale.Length]; 
            int countverpari = 0;
            int countverdispari = 0;
            int pari = 0;
            int dispari = 0;
            int resto = 0;
            SqlCommand sqlcmd;
            for (int i = 0; i < cfparziale.Length; i++)
            {


                cfarrparziale[i]=cfparziale.Substring(i, 1);
                if (i%2==0)
                {
                    arrdispari[countverdispari] = cfarrparziale[i];
                //    MessageBox.Show(arrdispari[countverdispari]);
                    countverdispari=countverdispari+1;
                }else if (i%2==1)
                {
                    arrpari[countverpari] = cfarrparziale[i];
                  //  MessageBox.Show(arrpari[countverpari]);
                    countverpari = countverpari + 1;
                }


            }    
            SqlConnection sqlConnection=new SqlConnection (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+path+@"\Database1.mdf;Integrated Security=True");
            SqlDataReader sqlreader = null;
            DataTable sqldt = new DataTable ();
            sqlConnection.Open ();
            for (int i = 0; i < arrdispari.Length; i++)
            {
                query = "SELECT numero FROM dispari WHERE lettera='" + arrdispari[i]+"'";
                sqlcmd = new SqlCommand(query,sqlConnection);
                sqlreader = sqlcmd.ExecuteReader();
                sqldt.Clear();
                sqldt.Load(sqlreader);
                
                finddata = sqldt.Select();
                arrdispari[i] = finddata[0][0].ToString();
                dispari = dispari + Int32.Parse(arrdispari[i]);



            }
            for (int i = 0; i < arrpari.Length; i++)
            {
                query = "SELECT numero FROM pari WHERE lettera='" + arrpari[i]+"' ";
                sqlcmd = new SqlCommand(query, sqlConnection);
                sqlreader = sqlcmd.ExecuteReader();
                sqldt.Clear();
                sqldt.Load(sqlreader);
                finddata = sqldt.Select();
                arrpari[i] = finddata[0][0].ToString();
                pari = pari + Int32.Parse(arrpari[i]);
            }

            resto = (pari+dispari) % 26;
            query = "SELECT lettere FROM [Table] WHERE numero='" + resto.ToString()+"'";
            sqlcmd = new SqlCommand(query, sqlConnection);
            DataTable sqlresult = new DataTable();
            sqlreader = sqlcmd.ExecuteReader();
            sqlresult.Clear();
            sqlresult.Load(sqlreader);

            finddata = sqlresult.Select();
            ver = finddata[0][0].ToString();
            sqlConnection.Close ();
            cf = cfparziale + ver;
            label5.Text = cf; 
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || (textBox1.Text.Contains("!") || textBox1.Text.Contains("=") || textBox1.Text.Contains("|") || textBox1.Text.Contains("£") || textBox1.Text.Contains("$") || textBox1.Text.Contains("%") || textBox1.Text.Contains("&") || textBox1.Text.Contains("/") || textBox1.Text.Contains("(") || textBox1.Text.Contains(")") || textBox1.Text.Contains("'") || textBox1.Text.Contains("?") || textBox1.Text.Contains("^") || textBox1.Text.Contains("1") || textBox1.Text.Contains("2") || textBox1.Text.Contains("3") || textBox1.Text.Contains("4") || textBox1.Text.Contains("5") || textBox1.Text.Contains("6") || textBox1.Text.Contains("7") || textBox1.Text.Contains("8") || textBox1.Text.Contains("9") || textBox1.Text.Contains("0") || textBox1.Text.Contains("#") || textBox1.Text.Contains("@") || textBox1.Text.Contains("*") || textBox1.Text.Contains("+") || textBox1.Text.Contains("}") || textBox1.Text.Contains("]") || textBox1.Text.Contains("[") || textBox1.Text.Contains("{") || textBox1.Text.Contains(",") || textBox1.Text.Contains(";") || textBox1.Text.Contains(".") || textBox1.Text.Contains(":") || textBox1.Text.Contains("-") || textBox1.Text.Contains("_") || textBox1.Text.Contains("€")))
            {
                MessageBox.Show("Il cognome è errato, riprova");
                this.ActiveControl = textBox1;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || (textBox2.Text.Contains("!") || textBox2.Text.Contains("=") || textBox2.Text.Contains("|") || textBox2.Text.Contains("£") || textBox2.Text.Contains("$") || textBox2.Text.Contains("%") || textBox2.Text.Contains("&") || textBox2.Text.Contains("/") || textBox2.Text.Contains("(") || textBox2.Text.Contains(")") || textBox2.Text.Contains("'") || textBox2.Text.Contains("?") || textBox2.Text.Contains("^") || textBox2.Text.Contains("1") || textBox2.Text.Contains("2") || textBox2.Text.Contains("3") || textBox2.Text.Contains("4") || textBox2.Text.Contains("5") || textBox2.Text.Contains("6") || textBox2.Text.Contains("7") || textBox2.Text.Contains("8") || textBox2.Text.Contains("9") || textBox2.Text.Contains("0") || textBox2.Text.Contains("#") || textBox2.Text.Contains("@") || textBox2.Text.Contains("*") || textBox2.Text.Contains("+") || textBox2.Text.Contains("}") || textBox2.Text.Contains("]") || textBox2.Text.Contains("[") || textBox2.Text.Contains("{") || textBox2.Text.Contains(",") || textBox2.Text.Contains(";") || textBox2.Text.Contains(".") || textBox2.Text.Contains(":") || textBox2.Text.Contains("-") || textBox2.Text.Contains("_") || textBox2.Text.Contains("€")))
            {
                MessageBox.Show("Il nome è errato, riprova");
                this.ActiveControl = textBox2;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || (textBox3.Text.Contains("!") || textBox3.Text.Contains("=") || textBox3.Text.Contains("|") || textBox3.Text.Contains("£") || textBox3.Text.Contains("$") || textBox3.Text.Contains("%") || textBox3.Text.Contains("&") || textBox3.Text.Contains("/") || textBox3.Text.Contains("(") || textBox3.Text.Contains(")") || textBox3.Text.Contains("?") || textBox3.Text.Contains("^") || textBox3.Text.Contains("1") || textBox3.Text.Contains("2") || textBox3.Text.Contains("3") || textBox3.Text.Contains("4") || textBox3.Text.Contains("5") || textBox3.Text.Contains("6") || textBox3.Text.Contains("7") || textBox3.Text.Contains("8") || textBox3.Text.Contains("9") || textBox3.Text.Contains("0") || textBox3.Text.Contains("#") || textBox3.Text.Contains("@") || textBox3.Text.Contains("*") || textBox3.Text.Contains("+") || textBox3.Text.Contains("}") || textBox3.Text.Contains("]") || textBox3.Text.Contains("[") || textBox3.Text.Contains("{") || textBox3.Text.Contains(",") || textBox3.Text.Contains(";") || textBox3.Text.Contains(".") || textBox3.Text.Contains(":") || textBox3.Text.Contains("-") || textBox3.Text.Contains("_") || textBox3.Text.Contains("€")))
            {
                MessageBox.Show("Il comune è errato, riprova");
                this.ActiveControl = textBox3;
            }
        }
    }
}
