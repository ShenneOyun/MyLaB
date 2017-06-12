using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace MainForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeTable();
        }

        private List<ISource>
            Sources = new List<ISource>();
        private DataTable SourceTable = new DataTable();
        ///<summary>
        /// Создание таблицы
        ///    </summary>
        private void InitializeTable()
        {
            var columnAuthor = new DataColumn("Author");
            columnAuthor.ReadOnly = true;
            columnAuthor.DataType = typeof(string);
            SourceTable.Columns.Add(columnAuthor);
            var columnTitle = new DataColumn("Title");
            columnTitle.ReadOnly = true;
            columnTitle.DataType = typeof(string);
            SourceTable.Columns.Add(columnTitle);
            var columnDescription = new DataColumn("Description");
            columnDescription.ReadOnly = true;
            columnDescription.DataType = typeof(string);
            SourceTable.Columns.Add(columnDescription);
            dataGridView1.DataSource = SourceTable;
            dataGridView1.Update();
           
        }

        private void AddRow(ISource source)
        {
            Sources.Add(source);
            var row = SourceTable.NewRow();
            row[0] = source.Author;
            row[1] = source.Title;
            row[2] = source.GetDescription();
            SourceTable.Rows.Add(row);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var form = new SourceForm();
            if (form.ShowDialog()==DialogResult.OK);
            {
                var source = form.Sourse;
                AddRow(source);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }






        ///<summary>
        /// Кнопка удаления строки из таблицы
        ///    </summary>
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int removeIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(removeIndex);
            Sources.RemoveAt(removeIndex);
        }




        ///<summary>
        /// Кнопка поиска в таблице
        ///    </summary>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBoxSearch.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }
    }
}
