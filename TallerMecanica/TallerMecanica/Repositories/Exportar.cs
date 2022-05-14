using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Reflection;

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

					//Recorremos el DataGRidView rellenando la hoja de trabajo
					for (int i = 1; i < grd.Columns.Count + 1; i++)
					{
						aplicacion.Cells[1, i] = grd.Columns[i - 1].HeaderText;
					}

					for (int i = 0; i < grd.Rows.Count; i++)
                    {
						for (int j = 0; j < grd.Columns.Count; j++)
                        {
							aplicacion.Cells[i + 2, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                        }
                    }
					aplicacion.Columns.AutoFit();
					aplicacion.Visible = true;
					libros_trabajo.SaveAs(Filename: fichero.FileName);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al exportar la información debido a: " + ex.ToString());
			}
		}
	}
}
