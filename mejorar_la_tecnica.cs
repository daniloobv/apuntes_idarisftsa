using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USUARIO
{  
    public partial class ASIGNACIONCREDENCIALES : Form
    {   
        //--------------------------------------------------------------------------------------------------------
        //-------------------------------START FUNCIONES FUNCIONES START------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        bool editar = false;
        string tabla = "asignacion_credenciales";
        string dato00 = ""; string campo00 = "codigo";
        string dato01 = ""; string campo01 = "departamento";
        string dato02 = ""; string campo02 = "cedula";
        string dato03 = ""; string campo03 = "nombre";
        string dato04 = ""; string campo04 = "correo";
        string dato05 = ""; string campo05 = "usuario";
        string dato06 = ""; string campo06 = "pass";
        string dato07 = ""; string campo07 = "";
        string dato08 = ""; string campo08 = "";
        string dato09 = ""; string campo09 = "";
        string dato10 = ""; string campo10 = "";
        string dato11 = ""; string campo11 = "";
        string dato12 = ""; string campo12 = "";
        string dato13 = ""; string campo13 = "";
        string dato14 = ""; string campo14 = "";
        private void setear_controles()
        {
            txtdepartamento.Text = dato01;
            txtcedularegistrousuario.Text = dato02;
            txtnombreregistrousuario.Text = dato03;
            txtcorreoempregistrousuario.Text = dato04;
            txtusuarioregistrousuario.Text = dato05;
            txtcontraseñaregistrousuario.Text = dato06;
        }
        private void setear_variables()
        {
            dato01 = txtdepartamento.Text;
            dato02 = txtcedularegistrousuario.Text;
            dato03 = txtnombreregistrousuario.Text;
            dato04 = txtcorreoempregistrousuario.Text;
            dato05 = txtusuarioregistrousuario.Text;
            dato06 = txtcontraseñaregistrousuario.Text;
        }  

        private string instrucciones_update(DataGridView datagridview)
        {
            dato00 = datagridview.CurrentRow.Cells[0].Value.ToString();
            setear_variables();
            string instrucciones = "update " + tabla + " set " +
            campo01 + " = '" + dato01 + "', " +
            campo02 + " = '" + dato02 + "', " +
            campo03 + " = '" + dato03 + "', " +
            campo04 + " = '" + dato04 + "', " +
            campo05 + " = '" + dato05 + "', " +
            campo06 + " = '" + dato06 + "'  " +
            " where " + campo00 + " = '" + dato00 + "'";
            return instrucciones;
        }

        private string instrucciones_save_insert()
        {
            setear_variables();
            string instrucciones = "insert into "+
                tabla + "(" +
                campo01 + "," +
                campo02 + "," +
                campo03 + "," +
                campo04 + "," +
                campo05 + "," +
                campo06 + "" +
                ")values('" +
                dato01 + "','" +
                dato02 + "','" +
                dato03 + "','" +
                dato04 + "','" +
                dato05 + "','" +
                dato06 + "') ";
            return instrucciones;           
        }

        private void cargar_datos_en_controles()
        {
            editar = true;
            if (dataGridView1.Rows.Count > 0)
            {
                dato00 = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                label3.Text = dato00;
                dato01 = tools.unDatoToString("select " + campo01 + " from " + tabla + " where " + campo00 + " = " + dato00 + "");
                dato02 = tools.unDatoToString("select " + campo02 + " from " + tabla + " where " + campo00 + " = " + dato00 + "");
                dato03 = tools.unDatoToString("select " + campo03 + " from " + tabla + " where " + campo00 + " = " + dato00 + "");
                dato04 = tools.unDatoToString("select " + campo04 + " from " + tabla + " where " + campo00 + " = " + dato00 + "");
                dato05 = tools.unDatoToString("select " + campo05 + " from " + tabla + " where " + campo00 + " = " + dato00 + "");
                dato06 = tools.unDatoToString("select " + campo06 + " from " + tabla + " where " + campo00 + " = " + dato00 + "");
                setear_controles();
            }

        }

        private void limpiar()
        {
            dato01 = "";
            dato02 = "";
            dato03 = "";
            dato04 = "";
            dato05 = "";
            dato06 = "";
            setear_controles();
            label3.Text = "";
            editar = false;
        }





        private void cargar_modulo()
        {
            tools.conectar();
            llenar_datagrid(dataGridView1);
        }
        private void llenar_datagrid(DataGridView datagrid)
        {
            datagrid.DataSource = tools.obtenerDatosTabla("select * from " + tabla);
        }
        private void llenar_datagrid(DataTable datos)
        {
            dataGridView1.DataSource = datos;
            limpiar();
        }
        private void eliminar_registro()
        {
            llenar_datagrid(tools.eliminar_registro(dataGridView1, tabla, campo00));
        }
        private void seleccionar_id_del_registro()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dato00 = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
        }
        private void guardar_o_actualizar()
        {
            if (editar == true)
            {
                llenar_datagrid(tools.actualizar_registro(dataGridView1, tabla, campo00, instrucciones_update(dataGridView1)));
            }
            else
            {
                llenar_datagrid(tools.guardar_registro(dataGridView1, tabla, instrucciones_save_insert()));
            }
        }
        //--------------------------------------------------------------------------------------------------------
        //-------------------------------END FUNCIONES FUNCIONES END----------------------------------------------
        //-----------------------------------por fin jejeje -------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------



        public ASIGNACIONCREDENCIALES()
        {
            InitializeComponent();
        }
        private void REGISTRODEUSUARIO_Load(object sender, EventArgs e)
        {
            cargar_modulo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar_o_actualizar();
        }
        
              

        private void dgvasigancioncredenciales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionar_id_del_registro();
        }

 

        private void button1_Click_1(object sender, EventArgs e)
        {
            cargar_datos_en_controles();
        }

        

        private void buttcancelarasignacreden_Click(object sender, EventArgs e)
        {
            eliminar_registro();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {            
            limpiar();
        }
           



    }

}
