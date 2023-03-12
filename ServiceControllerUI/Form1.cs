namespace ServiceController
{
    public partial class Form1 : Form
    {
        private readonly ServiceManager _serviceManager;
        private readonly DriverManager _driverManager;
        private IEnumerable<Service> _currentServiceRows;
        private IEnumerable<Driver> _currentDriverRows;
        private int _lasRowIndexClicked = -1;
        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
            _serviceManager = new ServiceManager();
            _driverManager = new DriverManager();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            serviceDataGrid.Columns.Add("Name", "Name");
            serviceDataGrid.Columns.Add("Display Name", "Display Name");
            driverDataGrid.Columns.Add("Name", "Name");
            driverDataGrid.Columns.Add("Base Address", "Base Address");
            driverDataGrid.Columns.Add("Path", "Path");
            _currentServiceRows = _serviceManager.EnumServices();
            _currentDriverRows = _driverManager.EnumDrivers();

            foreach (var service in _currentServiceRows)
            {
                serviceDataGrid.Rows.Add(service.Name, service.DisplayName);
            }

            foreach (var driver in _currentDriverRows)
            {
                driverDataGrid.Rows.Add(driver.Name, driver.BaseAddress, driver.Path);
            }
        }

        private void start_service_Click(object sender, EventArgs e)
        {
            if (_lasRowIndexClicked < 0) return;
            var serviceName = serviceDataGrid.Rows[_lasRowIndexClicked].Cells[0].FormattedValue.ToString();
            if (MessageBox.Show($@"Do you want to start service {serviceName}", "Service Controller",
                    MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            if (!string.IsNullOrEmpty(serviceName))
            {
                _serviceManager.StartService(serviceName);
            }
        }

        private void stop_service_Click(object sender, EventArgs e)
        {
            if (_lasRowIndexClicked < 0) return;
            var serviceName = serviceDataGrid.Rows[_lasRowIndexClicked].Cells[0].FormattedValue.ToString();
            if (MessageBox.Show($@"Do you want to stop service {serviceName}", "Service Controller",
                    MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            if (!string.IsNullOrEmpty(serviceName))
            {
                _serviceManager.StopService(serviceName);
            }
        }

        private void restart_service_Click(object sender, EventArgs e)
        {
            if (_lasRowIndexClicked < 0) return;
            var serviceName = serviceDataGrid.Rows[_lasRowIndexClicked].Cells[0].FormattedValue.ToString();
            if (MessageBox.Show($@"Do you want to restart service {serviceName}", "Service Controller",
                    MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            if (string.IsNullOrEmpty(serviceName)) return;
            _serviceManager.StopService(serviceName);
            _serviceManager.StartService(serviceName);
        }

        private void create_service_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.ShowDialog();
        }

        private void delete_driver_Click(object sender, EventArgs e)
        {
            if (_lasRowIndexClicked < 0) return;
            var serviceName = serviceDataGrid.Rows[_lasRowIndexClicked].Cells[0].FormattedValue.ToString();
            if (MessageBox.Show($@"Do you want to delete service {serviceName}", "Service Controller",
                    MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            if (!string.IsNullOrEmpty(serviceName))
            {
                _serviceManager.DeleteService(serviceName);
            }
        }

        private void driverDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _lasRowIndexClicked = e.RowIndex;
        }
    }
}