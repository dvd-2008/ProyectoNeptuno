using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoNeptuno
{
    public partial class Form3 : Form
        
    {
        int posi = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Listar();
        }
        public void Listar()
        {
            DataNeptunoDataContext tablas = new DataNeptunoDataContext();
            dataGridView1.DataSource = tablas.Empleados;

        }

        public void Limpiar()
        {
            textApe.Text = "";
            textCargo.Text = "";
            textCiu.Text = "";
            textCod.Text = "";
            textDir.Text = "";
            textExt.Text = "";
            textFechC.Text = "";
            textFechN.Text = "";
            textNombre.Text = "";
            textNots.Text = "";
            textPais.Text = "";
            textReg.Text = "";
            textSueld.Text = "";
            textTelf.Text = "";
            textTrata.Text = "";


        }
        private void label12_Click(object sender, EventArgs e)
        {
     
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           


            textApe.Text = GetCellValue("Apellidos");
            textNombre.Text = GetCellValue("Nombre");
            textCargo.Text = GetCellValue("cargo");
            textTrata.Text = GetCellValue("Tratamiento");
            textFechN.Text = GetCellValue("FechaNacimiento");
            textFechC.Text = GetCellValue("FechaContratacion");
            textDir.Text = GetCellValue("direccion");
            textCiu.Text = GetCellValue("ciudad");
            textReg.Text = GetCellValue("region");
            textCod.Text = GetCellValue("codPostal");
            textPais.Text = GetCellValue("pais");
            textTelf.Text = GetCellValue("telDomicilio");
            textExt.Text = GetCellValue("Extension");
            textNots.Text = GetCellValue("Notas");
            textSueld.Text = GetCellValue("SueldoBasico");

            posi = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdEmpleado"].Value.ToString());
        }


        private string GetCellValue(string columnName)
        {
            object cellValue = dataGridView1.CurrentRow.Cells[columnName].Value;

            if (cellValue != null && cellValue != DBNull.Value)
            {
                return cellValue.ToString();
            }
            else
            {
                return string.Empty; 
            }
        }
        // agregar
        private void button1_Click(object sender, EventArgs e)
        {
            using (DataNeptunoDataContext tablas = new DataNeptunoDataContext())
            {
                Empleados emp = new Empleados
                {




                   

                    Apellidos = string.IsNullOrEmpty(textApe.Text) ? null : textApe.Text,
                    Nombre = string.IsNullOrEmpty(textNombre.Text) ? null : textNombre.Text,
                    cargo = string.IsNullOrEmpty(textCargo.Text) ? null : textCargo.Text,
                    Tratamiento = string.IsNullOrEmpty(textTrata.Text) ? null : textTrata.Text,
                    FechaNacimiento = DateTime.Now.Date,
                    FechaContratacion = DateTime.Now.Date,
                    direccion = string.IsNullOrEmpty(textDir.Text) ? null : textDir.Text,
                    ciudad = string.IsNullOrEmpty(textCiu.Text) ? null : textCiu.Text,
                    region = string.IsNullOrEmpty(textReg.Text) ? null : textReg.Text,
                    codPostal = string.IsNullOrEmpty(textCod.Text) ? null : textCod.Text,
                    pais = string.IsNullOrEmpty(textPais.Text) ? null : textPais.Text,
                    TelDomicilio = string.IsNullOrEmpty(textTelf.Text) ? null : textTelf.Text,
                    Extension = string.IsNullOrEmpty(textExt.Text) ? null : textExt.Text,
                    notas = string.IsNullOrEmpty(textNots.Text) ? null : textNots.Text,
                    sueldoBasico = string.IsNullOrEmpty(textSueld.Text) ? (decimal?)null : Convert.ToDecimal(textSueld.Text)




                };
                tablas.Empleados.InsertOnSubmit(emp);
                tablas.SubmitChanges();


            }
            Listar();
            Limpiar();
            
        }
        // editar

        private void button2_Click(object sender, EventArgs e)
        {
            using (DataNeptunoDataContext tablas = new DataNeptunoDataContext())
            {
                Empleados emp = tablas.Empleados.SingleOrDefault(x => x.IdEmpleado == posi);

                emp.Apellidos = string.IsNullOrEmpty(textApe.Text) ? null : textApe.Text;
                emp.Nombre = string.IsNullOrEmpty(textNombre.Text) ? null : textNombre.Text;
                emp.cargo = string.IsNullOrEmpty(textCargo.Text) ? null : textCargo.Text;
                emp.Tratamiento = string.IsNullOrEmpty(textTrata.Text) ? null : textTrata.Text;
                emp.FechaNacimiento = DateTime.Now.Date; 
                emp.FechaContratacion = DateTime.Now.Date; 
                emp.direccion = string.IsNullOrEmpty(textDir.Text) ? null : textDir.Text;
                emp.ciudad = string.IsNullOrEmpty(textCiu.Text) ? null : textCiu.Text;
                emp.region = string.IsNullOrEmpty(textReg.Text) ? null : textReg.Text;
                emp.codPostal = string.IsNullOrEmpty(textCod.Text) ? null : textCod.Text;
                emp.pais = string.IsNullOrEmpty(textPais.Text) ? null : textPais.Text;
                emp.TelDomicilio = string.IsNullOrEmpty(textTelf.Text) ? null : textTelf.Text;
                emp.Extension = string.IsNullOrEmpty(textExt.Text) ? null : textExt.Text;
                emp.notas = string.IsNullOrEmpty(textNots.Text) ? null : textNots.Text;
                emp.sueldoBasico = string.IsNullOrEmpty(textSueld.Text) ? (decimal?)null : Convert.ToDecimal(textSueld.Text);

                tablas.SubmitChanges(); 
            }
            Listar();
            Limpiar();
        }
        // eliminar

        private void button3_Click(object sender, EventArgs e)
        {
            using (DataNeptunoDataContext tablas = new DataNeptunoDataContext())
            {
                Empleados emp = tablas.Empleados.SingleOrDefault(x => x.IdEmpleado == posi);
                tablas.Empleados.DeleteOnSubmit(emp);
                tablas.SubmitChanges();

            }
            Listar();
            Limpiar();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 VEN1 = new Form1();
            this.Hide();
            VEN1.Show();
        }
    }
}
