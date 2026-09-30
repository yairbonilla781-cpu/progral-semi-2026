namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbdatos = new System.Windows.Forms.GroupBox();
            this.txtEmailAlumno = new System.Windows.Forms.TextBox();
            this.lblEmailAlumno = new System.Windows.Forms.Label();
            this.lbltelefonoAlumno = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblnombreAlumno = new System.Windows.Forms.Label();
            this.txttelefonoAlumno = new System.Windows.Forms.TextBox();
            this.txtDireccionAlumno = new System.Windows.Forms.TextBox();
            this.txtnombreAlumno = new System.Windows.Forms.TextBox();
            this.lblcodigo = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.Label();
            this.grbNavegacion = new System.Windows.Forms.GroupBox();
            this.lblRegistroAlumno = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnprimeroAlumno = new System.Windows.Forms.Button();
            this.grbEdicion = new System.Windows.Forms.GroupBox();
            this.btnmodificarAlumno = new System.Windows.Forms.Button();
            this.btnAgregarAlumno = new System.Windows.Forms.Button();
            this.grbdatos.SuspendLayout();
            this.grbNavegacion.SuspendLayout();
            this.grbEdicion.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbdatos
            // 
            this.grbdatos.Controls.Add(this.txtEmailAlumno);
            this.grbdatos.Controls.Add(this.lblEmailAlumno);
            this.grbdatos.Controls.Add(this.lbltelefonoAlumno);
            this.grbdatos.Controls.Add(this.lblDireccion);
            this.grbdatos.Controls.Add(this.lblnombreAlumno);
            this.grbdatos.Controls.Add(this.txttelefonoAlumno);
            this.grbdatos.Controls.Add(this.txtDireccionAlumno);
            this.grbdatos.Controls.Add(this.txtnombreAlumno);
            this.grbdatos.Controls.Add(this.lblcodigo);
            this.grbdatos.Controls.Add(this.txtCodigo);
            this.grbdatos.Location = new System.Drawing.Point(12, 13);
            this.grbdatos.Name = "grbdatos";
            this.grbdatos.Size = new System.Drawing.Size(394, 283);
            this.grbdatos.TabIndex = 0;
            this.grbdatos.TabStop = false;
            this.grbdatos.Text = "Datos";
            // 
            // txtEmailAlumno
            // 
            this.txtEmailAlumno.Location = new System.Drawing.Point(94, 211);
            this.txtEmailAlumno.Name = "txtEmailAlumno";
            this.txtEmailAlumno.Size = new System.Drawing.Size(100, 20);
            this.txtEmailAlumno.TabIndex = 9;
            // 
            // lblEmailAlumno
            // 
            this.lblEmailAlumno.AutoSize = true;
            this.lblEmailAlumno.Location = new System.Drawing.Point(27, 212);
            this.lblEmailAlumno.Name = "lblEmailAlumno";
            this.lblEmailAlumno.Size = new System.Drawing.Size(32, 13);
            this.lblEmailAlumno.TabIndex = 8;
            this.lblEmailAlumno.Text = "Email";
            // 
            // lbltelefonoAlumno
            // 
            this.lbltelefonoAlumno.AutoSize = true;
            this.lbltelefonoAlumno.Location = new System.Drawing.Point(27, 172);
            this.lbltelefonoAlumno.Name = "lbltelefonoAlumno";
            this.lbltelefonoAlumno.Size = new System.Drawing.Size(45, 13);
            this.lbltelefonoAlumno.TabIndex = 7;
            this.lbltelefonoAlumno.Text = "telefono";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(21, 128);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 6;
            this.lblDireccion.Text = "Direccion";
            // 
            // lblnombreAlumno
            // 
            this.lblnombreAlumno.AutoSize = true;
            this.lblnombreAlumno.Location = new System.Drawing.Point(24, 79);
            this.lblnombreAlumno.Name = "lblnombreAlumno";
            this.lblnombreAlumno.Size = new System.Drawing.Size(45, 13);
            this.lblnombreAlumno.TabIndex = 5;
            this.lblnombreAlumno.Text = "nombre:";
            // 
            // txttelefonoAlumno
            // 
            this.txttelefonoAlumno.Location = new System.Drawing.Point(94, 165);
            this.txttelefonoAlumno.Name = "txttelefonoAlumno";
            this.txttelefonoAlumno.Size = new System.Drawing.Size(100, 20);
            this.txttelefonoAlumno.TabIndex = 4;
            // 
            // txtDireccionAlumno
            // 
            this.txtDireccionAlumno.Location = new System.Drawing.Point(95, 125);
            this.txtDireccionAlumno.Multiline = true;
            this.txtDireccionAlumno.Name = "txtDireccionAlumno";
            this.txtDireccionAlumno.Size = new System.Drawing.Size(100, 20);
            this.txtDireccionAlumno.TabIndex = 3;
            // 
            // txtnombreAlumno
            // 
            this.txtnombreAlumno.Location = new System.Drawing.Point(95, 79);
            this.txtnombreAlumno.Name = "txtnombreAlumno";
            this.txtnombreAlumno.Size = new System.Drawing.Size(159, 20);
            this.txtnombreAlumno.TabIndex = 2;
            // 
            // lblcodigo
            // 
            this.lblcodigo.Location = new System.Drawing.Point(94, 25);
            this.lblcodigo.Name = "lblcodigo";
            this.lblcodigo.Size = new System.Drawing.Size(100, 20);
            this.lblcodigo.TabIndex = 1;
            // 
            // txtCodigo
            // 
            this.txtCodigo.AutoSize = true;
            this.txtCodigo.Location = new System.Drawing.Point(21, 26);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(43, 13);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.Text = "Codigo:";
            // 
            // grbNavegacion
            // 
            this.grbNavegacion.Controls.Add(this.lblRegistroAlumno);
            this.grbNavegacion.Controls.Add(this.button3);
            this.grbNavegacion.Controls.Add(this.button2);
            this.grbNavegacion.Controls.Add(this.button1);
            this.grbNavegacion.Controls.Add(this.btnprimeroAlumno);
            this.grbNavegacion.Location = new System.Drawing.Point(12, 302);
            this.grbNavegacion.Name = "grbNavegacion";
            this.grbNavegacion.Size = new System.Drawing.Size(219, 54);
            this.grbNavegacion.TabIndex = 1;
            this.grbNavegacion.TabStop = false;
            this.grbNavegacion.Text = "Navegacion";
            this.grbNavegacion.Enter += new System.EventHandler(this.grbNavegacion_Enter);
            // 
            // lblRegistroAlumno
            // 
            this.lblRegistroAlumno.AutoSize = true;
            this.lblRegistroAlumno.Location = new System.Drawing.Point(107, 25);
            this.lblRegistroAlumno.Name = "lblRegistroAlumno";
            this.lblRegistroAlumno.Size = new System.Drawing.Size(36, 13);
            this.lblRegistroAlumno.TabIndex = 4;
            this.lblRegistroAlumno.Text = "x de n";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(177, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = ">|";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(148, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnprimeroAlumno
            // 
            this.btnprimeroAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprimeroAlumno.Location = new System.Drawing.Point(12, 19);
            this.btnprimeroAlumno.Name = "btnprimeroAlumno";
            this.btnprimeroAlumno.Size = new System.Drawing.Size(52, 23);
            this.btnprimeroAlumno.TabIndex = 0;
            this.btnprimeroAlumno.Text = "|<";
            this.btnprimeroAlumno.UseVisualStyleBackColor = true;
            this.btnprimeroAlumno.Click += new System.EventHandler(this.btnprimeroAlumno_Click);
            // 
            // grbEdicion
            // 
            this.grbEdicion.Controls.Add(this.btnmodificarAlumno);
            this.grbEdicion.Controls.Add(this.btnAgregarAlumno);
            this.grbEdicion.Location = new System.Drawing.Point(288, 302);
            this.grbEdicion.Name = "grbEdicion";
            this.grbEdicion.Size = new System.Drawing.Size(186, 54);
            this.grbEdicion.TabIndex = 2;
            this.grbEdicion.TabStop = false;
            this.grbEdicion.Text = "Edicion";
            // 
            // btnmodificarAlumno
            // 
            this.btnmodificarAlumno.Location = new System.Drawing.Point(105, 19);
            this.btnmodificarAlumno.Name = "btnmodificarAlumno";
            this.btnmodificarAlumno.Size = new System.Drawing.Size(75, 23);
            this.btnmodificarAlumno.TabIndex = 1;
            this.btnmodificarAlumno.Text = "modificar";
            this.btnmodificarAlumno.UseVisualStyleBackColor = true;
            this.btnmodificarAlumno.Click += new System.EventHandler(this.btnmodificarAlumno_Click_1);
            // 
            // btnAgregarAlumno
            // 
            this.btnAgregarAlumno.Location = new System.Drawing.Point(7, 19);
            this.btnAgregarAlumno.Name = "btnAgregarAlumno";
            this.btnAgregarAlumno.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarAlumno.TabIndex = 0;
            this.btnAgregarAlumno.Text = "Agregar";
            this.btnAgregarAlumno.UseVisualStyleBackColor = true;
            this.btnAgregarAlumno.Click += new System.EventHandler(this.btnAgregarAlumno_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grbEdicion);
            this.Controls.Add(this.grbNavegacion);
            this.Controls.Add(this.grbdatos);
            this.Name = "Form1";
            this.Text = "Administracion de Alumnos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbdatos.ResumeLayout(false);
            this.grbdatos.PerformLayout();
            this.grbNavegacion.ResumeLayout(false);
            this.grbNavegacion.PerformLayout();
            this.grbEdicion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbdatos;
        private System.Windows.Forms.GroupBox grbNavegacion;
        private System.Windows.Forms.GroupBox grbEdicion;
        private System.Windows.Forms.Label txtCodigo;
        private System.Windows.Forms.TextBox txtEmailAlumno;
        private System.Windows.Forms.Label lblEmailAlumno;
        private System.Windows.Forms.Label lbltelefonoAlumno;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblnombreAlumno;
        private System.Windows.Forms.TextBox txttelefonoAlumno;
        private System.Windows.Forms.TextBox txtDireccionAlumno;
        private System.Windows.Forms.TextBox txtnombreAlumno;
        private System.Windows.Forms.TextBox lblcodigo;
        private System.Windows.Forms.Button btnprimeroAlumno;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnmodificarAlumno;
        private System.Windows.Forms.Button btnAgregarAlumno;
        private System.Windows.Forms.Label lblRegistroAlumno;
    }
}

