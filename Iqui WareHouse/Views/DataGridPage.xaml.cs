using System.Windows.Controls;

using Iqui_WareHouse.ViewModels;

using System.Data;

using System.Data.OleDb;

using Microsoft.Win32;


namespace Iqui_WareHouse.Views
{
    public partial class DataGridPage : Page
    {
        public DataGridPage ( DataGridViewModel viewModel )
        {
            InitializeComponent ();
            DataContext = viewModel;
        }

        // Método para importar archivos 

        DataGridViewModel ImportarDatos ( string nombreArchivo )
        {
            string conexion = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Extended Properties = 'Excel 12.0;' ", nombreArchivo);
            OleDbConnection conector = new OleDbConnection (conexion);
            conector.Open();
            OleDbCommand consulta = new OleDbCommand("select * from [Hoja1$]", conector);
            OleDbDataAdapter adapatador = new OleDbDataAdapter
            {
                SelectCommand = consulta
            };

            DataSet ds = new DataSet();
            adapatador.Fill(ds);
            conector.Close();
           // return ds.Tables[0].DefaultView;

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
           
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel | *.xls;*.xlsx;",
                Title = "Seleccionar Archivo"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataDetalles.DataSource = ImportarDatos(openFileDialog.FileName);
            }
        }
    }
}
