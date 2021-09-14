
        //--------------------------------------------------------------------------------------------------------
        //-------------------------------START FUNCIONES FUNCIONES START----------------------------------------------
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
        
        

        private void cargar_modulo()
        {
            tools.conectar();
            llenar_datagrid(dataGridView1);
        }

        private void llenar_datagrid(DataGridView datagrid)
        {
            datagrid.DataSource = tools.obtenerDatosTabla("select * from "+tabla);
        }

        private void llenar_datagrid(DataTable datos)
        {
            dataGridView1.DataSource = datos;
            limpiar();
        }      

        private string instrucciones_update(DataGridView datagridview)
        {
            dato00 = datagridview.CurrentRow.Cells[0].Value.ToString();
            dato01 = txtdepartamento.Text;
            dato02 = txtcedularegistrousuario.Text;
            dato03 = txtnombreregistrousuario.Text;
            dato04 = txtcorreoempregistrousuario.Text;
            dato05 = txtusuarioregistrousuario.Text;
            dato06 = txtcontraseñaregistrousuario.Text;
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
            dato01 = txtdepartamento.Text;
            dato02 = txtcedularegistrousuario.Text;
            dato03 = txtnombreregistrousuario.Text;
            dato04 = txtcorreoempregistrousuario.Text;
            dato05 = txtusuarioregistrousuario.Text;
            dato06 = txtcontraseñaregistrousuario.Text;

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


        private void cargar_datos_en_controles(DataGridView datagrid)
        {
            editar = true;
            if (datagrid.Rows.Count > 0)
            {
                dato00 = datagrid.CurrentRow.Cells[0].Value.ToString();
                label3.Text = dato00;

                dato01 = tools.unDatoToString("select " + campo01 + " from " + tabla + " where " + campo00 + " = " + dato00 + "");
                dato02 = tools.unDatoToString("select " + campo02 + " from " + tabla + " where " + campo00 + " = " + dato00 + "");
                dato03 = tools.unDatoToString("select " + campo03 + " from " + tabla + " where " + campo00 + " = " + dato00 + "");
                dato04 = tools.unDatoToString("select " + campo04 + " from " + tabla + " where " + campo00 + " = " + dato00 + "");
                dato05 = tools.unDatoToString("select " + campo05 + " from " + tabla + " where " + campo00 + " = " + dato00 + "");
                dato06 = tools.unDatoToString("select " + campo06 + " from " + tabla + " where " + campo00 + " = " + dato00 + "");

                txtdepartamento.Text = dato01;
                txtcedularegistrousuario.Text = dato02;
                txtnombreregistrousuario.Text = dato03;
                txtcorreoempregistrousuario.Text = dato04;
                txtusuarioregistrousuario.Text = dato05;
                txtcontraseñaregistrousuario.Text = dato06;
            }

        }


        private void eliminar_registro(DataGridView datagrid)
        {
            llenar_datagrid(tools.eliminar_registro(datagrid, tabla, campo00));
        }


        private void limpiar()
        {
            dato01 = "";
            dato02 = "";
            dato03 = "";
            dato04 = "";
            dato05 = "";
            dato06 = "";
            txtdepartamento.Text = dato01;
            txtcedularegistrousuario.Text = dato02;
            txtnombreregistrousuario.Text = dato03;
            txtcorreoempregistrousuario.Text = dato04;
            txtusuarioregistrousuario.Text = dato05;
            txtcontraseñaregistrousuario.Text = dato06;
            label3.Text = "";
            editar = false;
        }


        private void seleccionar_id_del_registro(DataGridView datagrid)
        {
            if (datagrid.Rows.Count > 0)
            {
                dato00 = datagrid.CurrentRow.Cells[0].Value.ToString();
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
        //-----------------------------------por fin jejeje ------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------

