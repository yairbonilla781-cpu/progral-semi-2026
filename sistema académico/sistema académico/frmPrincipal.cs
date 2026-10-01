using sistema_académico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miPrimerProyectoCsharp
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 objAlumnos = new Form1();
            objAlumnos.MdiParent = this;
            objAlumnos.Show();
        }
        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaterias objMaterias = new frmMaterias();
            objMaterias.MdiParent = this;
            objMaterias.Show();
        }
        private void periodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeriodos objPeriodo = new frmPeriodos();
            objPeriodo.MdiParent = this;
            objPeriodo.Show();
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void notasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotas objNota = new frmNotas();
            objNota.MdiParent = this;
            objNota.Show();
        }
    }
}