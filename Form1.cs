using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pdf2MusicXmlBatch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblStatus.Text = "Listo.";
        }

        private void InitializeComponent()
        {
            this.lblFolder = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnSelectOutput = new System.Windows.Forms.Button();
            this.lblAudiveris = new System.Windows.Forms.Label();
            this.txtAudiveris = new System.Windows.Forms.TextBox();
            this.btnSelectAudiveris = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(20, 20);
            this.lblFolder.Text = "Carpeta de PDFs:";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(150, 18);
            this.txtFolder.Width = 600;
            this.txtFolder.ReadOnly = true;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Text = "Seleccionar...";
            this.btnSelectFolder.Location = new System.Drawing.Point(770, 16);
            this.btnSelectFolder.Size = new System.Drawing.Size(140, 30);
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(20, 55);
            this.lblOutput.Text = "Carpeta de salida:";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(150, 53);
            this.txtOutput.Width = 600;
            this.txtOutput.ReadOnly = true;
            // 
            // btnSelectOutput
            // 
            this.btnSelectOutput.Text = "Elegir...";
            this.btnSelectOutput.Location = new System.Drawing.Point(770, 51);
            this.btnSelectOutput.Size = new System.Drawing.Size(140, 30);
            this.btnSelectOutput.Click += new System.EventHandler(this.btnSelectOutput_Click);
            // 
            // lblAudiveris
            // 
            this.lblAudiveris.AutoSize = true;
            this.lblAudiveris.Location = new System.Drawing.Point(20, 90);
            this.lblAudiveris.Text = "Ruta de Audiveris (.bat):";
            // 
            // txtAudiveris
            // 
            this.txtAudiveris.Location = new System.Drawing.Point(150, 88);
            this.txtAudiveris.Width = 600;
            this.txtAudiveris.ReadOnly = true;
            // 
            // btnSelectAudiveris
            // 
            this.btnSelectAudiveris.Text = "Seleccionar...";
            this.btnSelectAudiveris.Location = new System.Drawing.Point(770, 86);
            this.btnSelectAudiveris.Size = new System.Drawing.Size(140, 30);
            this.btnSelectAudiveris.Click += new System.EventHandler(this.btnSelectAudiveris_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.Location = new System.Drawing.Point(23, 130);
            this.lstFiles.Size = new System.Drawing.Size(887, 260);
            // 
            // btnConvert
            // 
            this.btnConvert.Text = "Convertir todo";
            this.btnConvert.Location = new System.Drawing.Point(23, 410);
            this.btnConvert.Size = new System.Drawing.Size(140, 35);
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(180, 410);
            this.progressBar.Size = new System.Drawing.Size(730, 25);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 455);
            this.lblStatus.Width = 600;
            this.lblStatus.Text = "Estado: Listo.";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(950, 520);
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnSelectOutput);
            this.Controls.Add(this.lblAudiveris);
            this.Controls.Add(this.txtAudiveris);
            this.Controls.Add(this.btnSelectAudiveris);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblStatus);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Text = "PDF → MusicXML Batch Converter (Audiveris)";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ---- Controles ----
        private Label lblFolder;
        private TextBox txtFolder;
        private Button btnSelectFolder;
        private Label lblOutput;
        private TextBox txtOutput;
        private Button btnSelectOutput;
        private Label lblAudiveris;
        private TextBox txtAudiveris;
        private Button btnSelectAudiveris;
        private ListBox lstFiles;
        private Button btnConvert;
        private ProgressBar progressBar;
        private Label lblStatus;

        // ---- Selección de carpetas ----
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = dlg.SelectedPath;
                lstFiles.Items.Clear();
                var pdfs = Directory.GetFiles(dlg.SelectedPath, "*.pdf");
                foreach (var file in pdfs)
                    lstFiles.Items.Add(Path.GetFileName(file));
                lblStatus.Text = $"{pdfs.Length} PDFs encontrados.";
            }
        }

        private void btnSelectOutput_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtOutput.Text = dlg.SelectedPath;
                lblStatus.Text = "Carpeta de salida seleccionada.";
            }
        }

        private void btnSelectAudiveris_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog();
            dlg.Filter = "Archivo por lotes de Audiveris (*.bat)|*.bat|Todos los archivos|*.*";
            dlg.Title = "Seleccionar audiveris.bat";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtAudiveris.Text = dlg.FileName;
                lblStatus.Text = "Audiveris configurado.";
            }
        }

        // ---- Conversión ----
        private async void btnConvert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFolder.Text) || !Directory.Exists(txtFolder.Text))
            {
                MessageBox.Show("Selecciona una carpeta válida con archivos PDF.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtOutput.Text))
            {
                MessageBox.Show("Selecciona una carpeta de salida.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAudiveris.Text) || !File.Exists(txtAudiveris.Text))
            {
                MessageBox.Show("Selecciona la ruta del archivo audiveris.bat.");
                return;
            }

            var pdfs = Directory.GetFiles(txtFolder.Text, "*.pdf");
            if (pdfs.Length == 0)
            {
                MessageBox.Show("No se encontraron archivos PDF en la carpeta.");
                return;
            }

            Directory.CreateDirectory(txtOutput.Text);
            lblStatus.Text = "Iniciando conversión...";
            progressBar.Value = 0;

            int total = pdfs.Length;
            int ok = 0, fail = 0;
            int count = 0;

            foreach (var pdf in pdfs)
            {
                string name = Path.GetFileName(pdf);
                lblStatus.Text = $"Procesando {name} ({++count}/{total})...";
                bool success = await ConvertSingle(pdf, txtOutput.Text, txtAudiveris.Text);

                lstFiles.Items.Remove(name);
                lstFiles.Items.Add($"{name}  {(success ? "✔ OK" : "❌ Error")}");
                if (success) ok++; else fail++;

                progressBar.Value = (int)((count / (double)total) * 100);
            }

            lblStatus.Text = $"Finalizado: {ok} correctos, {fail} con error.";
            MessageBox.Show($"Conversión terminada.\n✔ OK: {ok}\n❌ Error: {fail}");
        }

        // ---- Ejecución de Audiveris ----
        private async Task<bool> ConvertSingle(string pdfPath, string outputDir, string audiverisBatPath)
        {
            try
            {
                string args = $"-batch -export -output \"{outputDir}\" \"{pdfPath}\"";

                var psi = new ProcessStartInfo
                {
                    FileName = audiverisBatPath,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                var proc = Process.Start(psi);
                if (proc == null) return false;

                string output = await proc.StandardOutput.ReadToEndAsync();
                string error = await proc.StandardError.ReadToEndAsync();
                await proc.WaitForExitAsync();

                // Espera 3 segundos por si Audiveris guarda después del cierre
                await Task.Delay(3000);

                string xmlName = Path.GetFileNameWithoutExtension(pdfPath) + ".musicxml";
                bool exists = Directory.GetFiles(outputDir, "*.musicxml", SearchOption.AllDirectories)
                    .Any(f => Path.GetFileName(f).Equals(xmlName, StringComparison.OrdinalIgnoreCase));

                if (!exists)
                {
                    string logPath = Path.Combine(outputDir, "audiveris_log.txt");
                    await File.AppendAllTextAsync(logPath,
                        $"[{DateTime.Now}] Error con {pdfPath}\nSTDOUT:\n{output}\nSTDERR:\n{error}\n\n");
                }

                return exists;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar Audiveris: {ex.Message}");
                return false;
            }
        }
    }
}
