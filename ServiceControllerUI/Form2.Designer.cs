namespace ServiceController
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            service_type_combo = new ComboBox();
            label1 = new Label();
            start_type_combo = new ComboBox();
            label2 = new Label();
            service_dll_text = new TextBox();
            label3 = new Label();
            account_text = new TextBox();
            label4 = new Label();
            label5 = new Label();
            name_text = new TextBox();
            label7 = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog2 = new FolderBrowserDialog();
            binary_text = new TextBox();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(762, 199);
            button1.Name = "button1";
            button1.Size = new Size(118, 48);
            button1.TabIndex = 0;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = true;
            button1.Click += createServiceClick;
            // 
            // button2
            // 
            button2.Location = new Point(18, 199);
            button2.Name = "button2";
            button2.Size = new Size(118, 48);
            button2.TabIndex = 1;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // service_type_combo
            // 
            service_type_combo.FormattingEnabled = true;
            service_type_combo.Items.AddRange(new object[] { "Driver", "FS Driver", "Own process" });
            service_type_combo.Location = new Point(115, 88);
            service_type_combo.Name = "service_type_combo";
            service_type_combo.Size = new Size(222, 23);
            service_type_combo.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(18, 88);
            label1.Name = "label1";
            label1.Size = new Size(42, 21);
            label1.TabIndex = 3;
            label1.Text = "Type";
            // 
            // start_type_combo
            // 
            start_type_combo.FormattingEnabled = true;
            start_type_combo.Items.AddRange(new object[] { "Disabled", "Boot start", "System start", "Auto start", "Demand start" });
            start_type_combo.Location = new Point(115, 55);
            start_type_combo.Name = "start_type_combo";
            start_type_combo.Size = new Size(222, 23);
            start_type_combo.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(18, 55);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 5;
            label2.Text = "Start type";
            // 
            // service_dll_text
            // 
            service_dll_text.Location = new Point(115, 150);
            service_dll_text.Name = "service_dll_text";
            service_dll_text.Size = new Size(222, 23);
            service_dll_text.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(18, 150);
            label3.Name = "label3";
            label3.Size = new Size(91, 21);
            label3.TabIndex = 7;
            label3.Text = "Service DLL";
            // 
            // account_text
            // 
            account_text.Location = new Point(115, 117);
            account_text.Name = "account_text";
            account_text.Size = new Size(222, 23);
            account_text.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(18, 117);
            label4.Name = "label4";
            label4.Size = new Size(66, 21);
            label4.TabIndex = 9;
            label4.Text = "Account";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(18, 20);
            label5.Name = "label5";
            label5.Size = new Size(52, 21);
            label5.TabIndex = 10;
            label5.Text = "Name";
            // 
            // name_text
            // 
            name_text.Location = new Point(115, 20);
            name_text.Name = "name_text";
            name_text.Size = new Size(222, 23);
            name_text.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(386, 24);
            label7.Name = "label7";
            label7.Size = new Size(89, 21);
            label7.TabIndex = 16;
            label7.Text = "Binary path";
            // 
            // binary_text
            // 
            binary_text.Location = new Point(481, 22);
            binary_text.Name = "binary_text";
            binary_text.Size = new Size(318, 23);
            binary_text.TabIndex = 17;
            // 
            // button3
            // 
            button3.Location = new Point(805, 22);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 18;
            button3.Text = "Browse";
            button3.UseVisualStyleBackColor = true;
            button3.Click += BinaryBrowseClick;
            // 
            // button4
            // 
            button4.Location = new Point(343, 148);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 19;
            button4.Text = "Browse";
            button4.UseVisualStyleBackColor = true;
            button4.Click += DllBrowseClick;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 273);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(binary_text);
            Controls.Add(label7);
            Controls.Add(name_text);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(account_text);
            Controls.Add(label3);
            Controls.Add(service_dll_text);
            Controls.Add(label2);
            Controls.Add(start_type_combo);
            Controls.Add(label1);
            Controls.Add(service_type_combo);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Create Service";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private ComboBox service_type_combo;
        private Label label1;
        private ComboBox start_type_combo;
        private Label label2;
        private TextBox service_dll_text;
        private Label label3;
        private TextBox account_text;
        private Label label4;
        private Label label5;
        private TextBox name_text;
        private Label label7;
        private FolderBrowserDialog folderBrowserDialog1;
        private FolderBrowserDialog folderBrowserDialog2;
        private TextBox binary_text;
        private Button button3;
        private Button button4;
    }
}