using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using System.IO;

namespace AppAct3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Files CSV (*.csv)|*.csv|Files JSON (*.json)|*.json|Files XML (*.xml)|*.xml";
            openFileDialog.Title = "Select Files";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePathCsv = openFileDialog.FileName;
                string filePathXml = openFileDialog.FileName;
                string filePathJson = openFileDialog.FileName;
                string fileExtension = Path.GetExtension(filePathCsv);

                switch (fileExtension)
                {
                    case ".csv":
                        filePathCsv = openFileDialog.FileName;
                        LoadCsv(filePathCsv);
                        break;
                    case ".json":
                        try
                        {
                            string jsonContent = File.ReadAllText(filePathJson);
                            richTextBox1.Text = jsonContent;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR" + ex.Message);
                        }
                        break;
                    case ".xml":
                        try
                        {
                            string xmlContent = File.ReadAllText(filePathXml);
                            richTextBox1.Text = xmlContent;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR" + ex.Message);
                        }
                        break;
                    default:
                        MessageBox.Show("PLEASE SELECT THE CORRECT FILE");
                    break;
                }
            }
        }
        private void LoadCsv(string filePath)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            string[] lines = File.ReadAllLines(filePath);
            // Add columns
            string[] headers = lines[0].Split(',');
            foreach (string header in headers)
            {
                dataGridView1.Columns.Add(header, header);
            }
            // Add rows
            for (int i = 1; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');
                dataGridView1.Rows.Add(fields);
            }
        }
        private void btnConvertCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Files JSON (*.json)|*.json|Files XML (*.xml)|*.xml";
            openFileDialog.Title = "Select Files";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileExtension = Path.GetExtension(filePath);

                switch (fileExtension)
                {
                    case ".json":
                        ConvertJSONtoCSV(filePath);
                        break;
                    case ".xml":
                        ConvertXMLtoCSV(filePath);
                        break;
                    default:
                        MessageBox.Show("PLEASE SELECT THE CORRECT FILE");
                    break;
                }
            }
        }
        private void ConvertJSONtoCSV(string FilePathJson)
        {
            string FilePathCsv = Path.ChangeExtension(FilePathJson, ".csv");

            using (StreamReader reader = new StreamReader(FilePathJson))
            {
                string json = reader.ReadToEnd();
                DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(json);

                using (StreamWriter writer = new StreamWriter(FilePathCsv))
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                        writer.WriteLine(string.Join(",", fields));
                    }
                }
            }MessageBox.Show("GENERATED CSV FILE" + FilePathCsv);
        }
        private void ConvertXMLtoCSV(string FilePathXml)
        {
            string FilePathCsv = Path.ChangeExtension(FilePathXml, ".csv");

            DataSet dataSet = new DataSet();
            dataSet.ReadXml(FilePathXml);

            using (StreamWriter writer = new StreamWriter(FilePathCsv))
            {
                foreach (DataTable table in dataSet.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                        writer.WriteLine(string.Join(",", fields));
                    }
                }
            }MessageBox.Show("GENERATED CSV FILE" + FilePathCsv);
        }
        private void btnConvertJSON_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Files CSV (*.csv)|*.csv|Files XML (*.xml)|*.xml";
            openFileDialog.Title = "Select Files";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileExtension = Path.GetExtension(filePath);

                switch (fileExtension)
                {
                    case ".csv":
                        ConvertCSVtoJSON(filePath);
                        break;
                    case ".xml":
                        ConvertXMLtoJSON(filePath);
                        break;
                    default:
                        MessageBox.Show("PLEASE SELECT THE CORRECT FILE");
                    break;
                }
            }
        }
        private void ConvertCSVtoJSON(string filePath)
        {
            DataTable dataTable = new DataTable();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string[] headers = reader.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header);
                }
                while (!reader.EndOfStream)
                {
                    string[] rows = reader.ReadLine().Split(',');
                    DataRow dataRow = dataTable.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dataRow[i] = rows[i];
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }
            string json = JsonConvert.SerializeObject(dataTable, Newtonsoft.Json.Formatting.Indented);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Files JSON (*.json)|*.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string FilePathJson = saveFileDialog.FileName;
                File.WriteAllText(FilePathJson, json);
            }
        }
        private void ConvertXMLtoJSON(string filePath)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(filePath);
            string json = JsonConvert.SerializeObject(dataSet, Newtonsoft.Json.Formatting.Indented);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Files JSON (*.json)|*.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string FilePathJson = saveFileDialog.FileName;
                File.WriteAllText(FilePathJson, json);
            }
        }
        private void btnConvertXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Files CSV (*.csv)|*.csv|Files JSON (*.json)|*.json";
            openFileDialog.Title = "Select Files";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileExtension = Path.GetExtension(filePath);

                string FilePathXml = Path.ChangeExtension(filePath, ".xml");

                switch (fileExtension)
                {
                    case ".csv":
                        ConvertCSVtoXML(filePath, FilePathXml);
                        break;
                    case ".json":
                        ConvertJSONtoXML(filePath, FilePathXml);
                        break;
                    default:
                        MessageBox.Show("PLEASE SELECT THE CORRECT FILE");
                    break;
                }
            }
        }
        private void ConvertCSVtoXML(string FilePathCsv, string FilePathXml)
        {
            DataTable dataTable = ReadCSV(FilePathCsv);
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            dataSet.WriteXml(FilePathXml);
        }
        private void ConvertJSONtoXML(string FilePathJson, string FilePathXml)
        {
            string json = File.ReadAllText(FilePathJson);
            DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(json);
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            dataSet.WriteXml(FilePathXml);
        }
        private DataTable ReadCSV(string filePath)
        {
            DataTable dataTable = new DataTable();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string[] headers = reader.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header);
                }
                while (!reader.EndOfStream)
                {
                    string[] rows = reader.ReadLine().Split(',');
                    DataRow dataRow = dataTable.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dataRow[i] = rows[i];
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }return dataTable;
        }
    }








}

