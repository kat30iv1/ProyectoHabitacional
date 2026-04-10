using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectosHabitacionalesInterfaz;

public partial class Form1 : Form
{
    string conexionSQL = "Server=localhost;Database=ProyectosHabitacionales;Integrated Security=True;TrustServerCertificate=True;";

    public Form1()
    {
        InitializeComponent();
        ConfigurarMenuPrincipal();
    }

    private void ConfigurarMenuPrincipal()
    {
        this.Text = "Sistema de Gestion - Proyectos Habitacionales";
        this.Size = new System.Drawing.Size(900, 600);

        // Título
        Label lblTitulo = new Label();
        lblTitulo.Text = "FORMULARIOS DE CONSULTA";
        lblTitulo.Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);
        lblTitulo.Location = new System.Drawing.Point(300, 20);
        lblTitulo.Size = new System.Drawing.Size(300, 30);
        this.Controls.Add(lblTitulo);

        // Instrucciones
        Label lblInfo = new Label();
        lblInfo.Text = "Seleccione el tipo de consulta que desea realizar:";
        lblInfo.Location = new System.Drawing.Point(50, 70);
        lblInfo.Size = new System.Drawing.Size(400, 20);
        this.Controls.Add(lblInfo);

        // Botones para los 6 formularios
        Button btnVista1 = CrearBoton("1. Lotes Disponibles (Vista)", 50, 120, 350);
        Button btnVista2 = CrearBoton("2. Clientes con Ventas (Vista)", 50, 160, 350);
        Button btnSP1 = CrearBoton("3. Buscar Cliente por ID (SP)", 50, 200, 350);
        Button btnSP2 = CrearBoton("4. Plan de Pagos por Venta (SP)", 50, 240, 350);
        Button btnFuncion1 = CrearBoton("5. Cuotas por Cliente (Funcion Tabla)", 50, 280, 350);
        Button btnFuncion2 = CrearBoton("6. Pagos por Fecha (Funcion Tabla)", 50, 320, 350);

        // Botón para probar conexión
        Button btnTest = CrearBoton("Probar Conexion a BD", 500, 500, 200);
        btnTest.BackColor = System.Drawing.Color.LightGreen;
        btnTest.Click += BtnTest_Click;

        this.Controls.Add(btnVista1);
        this.Controls.Add(btnVista2);
        this.Controls.Add(btnSP1);
        this.Controls.Add(btnSP2);
        this.Controls.Add(btnFuncion1);
        this.Controls.Add(btnFuncion2);
        this.Controls.Add(btnTest);
    }

    private Button CrearBoton(string texto, int x, int y, int ancho)
    {
        Button btn = new Button();
        btn.Text = texto;
        btn.Location = new System.Drawing.Point(x, y);
        btn.Size = new System.Drawing.Size(ancho, 35);
        btn.Font = new System.Drawing.Font("Arial", 10);
        return btn;
    }

    private void BtnTest_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection conexion = new SqlConnection(conexionSQL))
            {
                conexion.Open();
                MessageBox.Show("¡Conectado a SQL Server exitosamente!", "Conexion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error de conexion:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}