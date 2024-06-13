using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoNeptuno
{
    public partial class Form2 : Form
    {
        int posi = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listar();
        }
        public void listar()
        {
            DataNeptunoDataContext tablas = new DataNeptunoDataContext();
            dataGridView1.DataSource = tablas.categorias;

        }

        public void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["nombrecategoria"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
            posi = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idcategoria"].Value.ToString());
        }
        // agregar 
        private void button1_Click(object sender, EventArgs e)
        {
            using (DataNeptunoDataContext tablas = new DataNeptunoDataContext())
            {
                categorias cate = new categorias
                {
                    nombrecategoria = textBox1.Text,
                    descripcion = textBox2.Text
                };

                tablas.categorias.InsertOnSubmit(cate);
                tablas.SubmitChanges();
            }
            listar();
            limpiar();
        }
        // editar
        private void button2_Click(object sender, EventArgs e)
        {
            using (DataNeptunoDataContext tablas = new DataNeptunoDataContext())
            {
                categorias cate = tablas.categorias.SingleOrDefault(x=>x.idcategoria==posi);
                cate.nombrecategoria = textBox1.Text;
                cate.descripcion = textBox2.Text;
                tablas.SubmitChanges();
            }

            listar();
            limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (DataNeptunoDataContext tablas = new DataNeptunoDataContext())
            {
                categorias cate = tablas.categorias.SingleOrDefault(x => x.idcategoria == posi);
                tablas.categorias.DeleteOnSubmit(cate);
                tablas.SubmitChanges();
            }
            listar();
            limpiar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 VEN1 = new Form1();
            this.Hide();
            VEN1.Show();
        }
    }
}
