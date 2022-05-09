using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace TallerMecanica.Repositories
{
    class Exportar
    {
		//Exporta Datagridview a archivo de excel
		public void ExportarDataGridViewExcel(DataGridView grd)
		{
			try
			{
				SaveFileDialog fichero = new SaveFileDialog();
				fichero.Filter = "Excel (*.xls)|*.xls";
				fichero.FileName = "ArchivoExportado";

				if (fichero.ShowDialog() == DialogResult.OK)
				{
					Excel.Application aplicacion;
					Excel.Workbook libros_trabajo;
					Excel.Worksheet hoja_trabajo;

					aplicacion = new Excel.Application();
					libros_trabajo = aplicacion.Workbooks.Add();
					hoja_trabajo = (Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

					//Recorremos el DataGRidView rellenando la hoja de trabajo
					for (int i = 0; i < grd.Rows.Count; i++)
					{
						for (int j = 0; j < grd.Columns.Count; j++)
						{
							if ((grd.Rows[i].Cells[j].Value == null) == false)
							{
								hoja_trabajo.Cells[i + 1, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
							}
						}
					}
					libros_trabajo.SaveAs(fichero.FileName, Excel.XlFileFormat.xlWorkbookNormal);
					libros_trabajo.Close(true);
					aplicacion.Quit();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al exportar la información debido a: " + ex.ToString());
			}
		}
	}
}
