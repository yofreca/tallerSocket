using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servidor.presentacion
{
    public partial class Vista : Form
    {

        private Controlador control;
        private Modelo modelo;
        StatusBar mainStatusBar;
        StatusBarPanel statusPanel;


        public Vista(Modelo m)
        {
            modelo = m;
            InitializeComponent();
            getControl();
            IniciarStatusBar();
        }


        public Controlador getControl()
        {
            if (control == null)
            {
                control = new Controlador(this);
            }
            return control;
        }

        public Modelo getModelo()
        {
            return modelo;
        }


        public TextBox getTxtLog()
        {
            return txtLog;
        }

        public Button getBtnIniciar()
        {
            return btnIniciar;
        }

        public StatusBar GetStatusBar()
        {
            return mainStatusBar;
        }

        public Label getNoClientes()
        {
            return lblNoClientes;
        }

        public DataGridView getGrilla()
        {
            return dgvDetalle;
        }


      

        private void IniciarStatusBar()
        {
            mainStatusBar = new StatusBar();
            statusPanel = new StatusBarPanel();
            statusPanel.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            statusPanel.Text = string.Empty;
            statusPanel.ToolTipText = String.Empty;
            statusPanel.AutoSize = StatusBarPanelAutoSize.Spring;
            mainStatusBar.Panels.Add(statusPanel);
            mainStatusBar.ShowPanels = true;
            Controls.Add(mainStatusBar);
        }

    }
}
