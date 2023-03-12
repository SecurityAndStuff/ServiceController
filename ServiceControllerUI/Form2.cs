namespace ServiceController
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Shown += Form2_Shown;
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            this.name_text.Text = Guid.NewGuid().ToString();
            this.start_type_combo.SelectedItem = "Demand start";
            this.service_type_combo.SelectedItem = "Driver";
            this.account_text.Text = "LocalSystem";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void DllBrowseClick(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                service_dll_text.Text = openFileDialog1.FileName;
            }
        }

        private void BinaryBrowseClick(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                binary_text.Text = openFileDialog1.FileName;
            }
        }

        private void createServiceClick(object sender, EventArgs e)
        {
            var service = new ServiceManager();
            MessageBox.Show(service.CreateService(name_text.Text,
                name_text.Text,
                Pinvoke.SERVICE_ACCESS.SERVICE_ALL_ACCESS,
                Pinvoke.ServiceType.SERVICE_KERNEL_DRIVER,
                0x00000003,
                0,
                binary_text.Text,
                null,
                null,
                service_dll_text.Text,
                "NT AUTHORITY\\LocalService",
                null)
                ? "Service was created"
                : $"There was an error: {Pinvoke.GetLastError()}", "Service creation", MessageBoxButtons.OK);
        }
    }
}
