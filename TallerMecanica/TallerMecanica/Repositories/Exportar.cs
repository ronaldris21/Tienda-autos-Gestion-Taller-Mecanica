using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Reflection;
using TallerMecanica.Models;
using System.Globalization;

namespace TallerMecanica.Repositories
{
    class Exportar
    {
		//Exporta Datagridview a archivo de excel
		public void ExportarDataGridViewExcel(DataGridView grd, ProductoComprado producto, string preciototal)
		{
			try
			{
				
				SaveFileDialog fichero = new SaveFileDialog();
				fichero.Filter = "Excel (*.xlsx)|*.xlsx";
				fichero.FileName = "ArchivoExportado";

				if (fichero.ShowDialog() == DialogResult.OK)
				{
					Excel.Application aplicacion;
					Excel.Workbook libros_trabajo;
					Excel.Worksheet hoja_trabajo;

					aplicacion = new Excel.Application();
					libros_trabajo = aplicacion.Workbooks.Add();
					hoja_trabajo = (Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

					aplicacion.Cells[1, 2] = "Taller Mécánica";
					aplicacion.Cells[2, 2] = "Teléfono: 78945612";
					aplicacion.Cells[3, 2] = "Calle de los Molinos Nº2 CP: 30009";
					aplicacion.Cells[4, 2] = "Cliente: "  +producto.Cliente.nombreCompleto;

					aplicacion.Cells[5, 1] = "ID";
					aplicacion.Cells[6, 1] = producto.idProductoComprado;

					aplicacion.Cells[5, 2] = "Descripción";
					aplicacion.Cells[6, 2] = producto.descripcion.Trim();

					aplicacion.Cells[5, 3] = "Fecha de Compra";
					aplicacion.Cells[6, 3] = producto.fechaCompra;

					aplicacion.Cells[5, 4] = "Pedido Confirmado";
					aplicacion.Cells[6, 4] = producto.pedidoConfirmado;

					aplicacion.Cells[5, 5] = "Coste Ensamblado";
					aplicacion.Cells[6, 5] = producto.costoEnsamblado.ToString("N2") + " €";

					aplicacion.Cells[5, 6] = "Precio Total";
					aplicacion.Cells[6, 6] = preciototal ;

					//Recorremos el DataGRidView rellenando la hoja de trabajo
					for (int i = 1; i < grd.Columns.Count + 1; i++)
					{
						aplicacion.Cells[8, i] = grd.Columns[i - 1].HeaderText;
					}
					int ultimafila=10;
					for (int i = 0; i < grd.Rows.Count; i++)
                    {
						for (int j = 0; j < grd.Columns.Count; j++)
                        {
							ultimafila = i + 9;

							aplicacion.Cells[ultimafila, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                        }
                    }
					ultimafila++;
					aplicacion.Cells[ultimafila, 6] = "Precio Total";
					aplicacion.Cells[ultimafila, 7] = preciototal;



					aplicacion.Columns.AutoFit();
					aplicacion.Visible = true;
					libros_trabajo.SaveAs(Filename: fichero.FileName);
				}
			}
			catch (Exception ex)
			{
                Console.WriteLine("Error al exportar la información debido a: " + ex.ToString());
			}
		}
	}
}
