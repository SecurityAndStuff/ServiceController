namespace ServiceController
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            delete_driver = new Button();
            create_service = new Button();
            restart_service = new Button();
            stop_service = new Button();
            start_service = new Button();
            serviceDataGrid = new DataGridView();
            tabPage2 = new TabPage();
            driverDataGrid = new DataGridView();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)serviceDataGrid).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)driverDataGrid).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(952, 563);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(delete_driver);
            tabPage1.Controls.Add(create_service);
            tabPage1.Controls.Add(restart_service);
            tabPage1.Controls.Add(stop_service);
            tabPage1.Controls.Add(start_service);
            tabPage1.Controls.Add(serviceDataGrid);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(944, 535);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Services";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // delete_driver
            // 
            delete_driver.Location = new Point(769, 194);
            delete_driver.Name = "delete_driver";
            delete_driver.Size = new Size(172, 41);
            delete_driver.TabIndex = 5;
            delete_driver.Text = "Delete Driver";
            delete_driver.UseVisualStyleBackColor = true;
            delete_driver.Click += delete_driver_Click;
            // 
            // create_service
            // 
            create_service.Location = new Point(769, 147);
            create_service.Name = "create_service";
            create_service.Size = new Size(172, 41);
            create_service.TabIndex = 4;
            create_service.Text = "Create Service";
            create_service.UseVisualStyleBackColor = true;
            create_service.Click += create_service_Click;
            // 
            // restart_service
            // 
            restart_service.Location = new Point(769, 100);
            restart_service.Name = "restart_service";
            restart_service.Size = new Size(172, 41);
            restart_service.TabIndex = 3;
            restart_service.Text = "Restart Service";
            restart_service.UseVisualStyleBackColor = true;
            restart_service.Click += restart_service_Click;
            // 
            // stop_service
            // 
            stop_service.Location = new Point(769, 53);
            stop_service.Name = "stop_service";
            stop_service.Size = new Size(172, 41);
            stop_service.TabIndex = 2;
            stop_service.Text = "Stop Service";
            stop_service.UseVisualStyleBackColor = true;
            stop_service.Click += stop_service_Click;
            // 
            // start_service
            // 
            start_service.Location = new Point(766, 6);
            start_service.Name = "start_service";
            start_service.Size = new Size(172, 41);
            start_service.TabIndex = 1;
            start_service.Text = "Start Service";
            start_service.UseVisualStyleBackColor = true;
            start_service.Click += start_service_Click;
            // 
            // serviceDataGrid
            // 
            serviceDataGrid.AllowUserToAddRows = false;
            serviceDataGrid.AllowUserToDeleteRows = false;
            serviceDataGrid.AllowUserToOrderColumns = true;
            serviceDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            serviceDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            serviceDataGrid.Location = new Point(6, 6);
            serviceDataGrid.Name = "serviceDataGrid";
            serviceDataGrid.ReadOnly = true;
            serviceDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            serviceDataGrid.RowTemplate.Height = 25;
            serviceDataGrid.Size = new Size(754, 533);
            serviceDataGrid.TabIndex = 0;
            serviceDataGrid.CellClick += driverDataGrid_CellClick;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(driverDataGrid);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(944, 535);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Drivers";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // driverDataGrid
            // 
            driverDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            driverDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            driverDataGrid.Location = new Point(0, 0);
            driverDataGrid.Name = "driverDataGrid";
            driverDataGrid.RowTemplate.Height = 25;
            driverDataGrid.Size = new Size(935, 523);
            driverDataGrid.TabIndex = 0;
            driverDataGrid.CellClick += driverDataGrid_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(976, 578);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Service Controller";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)serviceDataGrid).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)driverDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private DataGridView serviceDataGrid;
        private DataGridView driverDataGrid;
        private Button delete_driver;
        private Button create_service;
        private Button restart_service;
        private Button stop_service;
        private Button start_service;
    }
}