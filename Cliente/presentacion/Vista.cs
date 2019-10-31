using Cliente.Logica;
using System.Drawing;
using System.Windows.Forms;

namespace Cliente.presentacion
{
    public partial class Vista : Form
    {
        StatusBar mainStatusBar;
        StatusBarPanel statusPanel;
        public bool blnEncendido { get; set; }


        private Controlador control;
        private Modelo modelo;

        public Modelo getModelo()
        {
            return modelo;
        }

        public Controlador getControl()
        {
            if (control == null)
            {
                control = new Controlador(this);
            }
            return control;
        }

        public Vista(Modelo m)
        {
            modelo = m;
            InitializeComponent();
            getControl();
            InciarSemaforo();
            IniciarStatusBar();
            blnEncendido = false;
        }


        public void InciarSemaforo()
        {
            pcbSemaforo.Image = Image.FromFile(Application.StartupPath + @"\img\apagado.png");
        }




        public PictureBox getImgSemaforo()
        {
            return pcbSemaforo;
        }
        
        public CheckBox getCkbRojo()
        {
            return ckbRojo;
        }


        public CheckBox getCkbApagado()
        {
            return ckbApagado;
        }

        public CheckBox getCkbAmarillo()
        {
            return ckbAmarillo;
        }

        public CheckBox getCkbVerde()
        {
            return ckbVerde;
        }

        public CheckBox getCkbRojoIntermitente()
        {
            return ckbRojoIntermitente;
        }

        public CheckBox getCkbAmarilloIntermitente()
        {
            return ckbAmarilloIntermitente;
        }

        public CheckBox getCkbVerdeIntermitente()
        {
            return ckbVerdeIntermitente;
        }

        public TextBox getTxtNombre()
        {
            return txtNombre;
        }

        public TextBox getTxtID()
        {
            return txtID;
        }

        public TextBox getTxtServidor()
        {
            return txtServidor;
        }


        public TextBox getTxtLog()
        {
            return txtLog;
        }

        public Timer getTimer()
        {
            return timer1;
        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        public Button getBtnConectar()
        {
            return btnConectar;
        }

        public ErrorProvider GetErrorProvider()
        {
            return errorProvider1;
        }

        private void IniciarStatusBar()
        {
            mainStatusBar = new StatusBar();
            statusPanel = new StatusBarPanel();
            statusPanel.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            statusPanel.Text = Util.DesConectado.getText();
            statusPanel.ToolTipText = Util.DesConectado.getText(); 
            statusPanel.AutoSize = StatusBarPanelAutoSize.Spring;
            mainStatusBar.Panels.Add(statusPanel);
            mainStatusBar.ShowPanels = true;
            Controls.Add(mainStatusBar);
        }

       
    }
}
