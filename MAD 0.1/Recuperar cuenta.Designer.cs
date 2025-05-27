namespace MAD_0._1
{
    partial class Recuperar_cuenta
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
            panel1 = new Panel();
            label4 = new Label();
            button1 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox3 = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkRed;
            panel1.Controls.Add(label4);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(267, 48);
            panel1.TabIndex = 1;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(12, 9);
            label4.Name = "label4";
            label4.Size = new Size(242, 30);
            label4.TabIndex = 4;
            label4.Text = "Recuperacion de cuenta";
            label4.Click += label4_Click;
            label4.MouseMove += label4_MouseMove;
            // 
            // button1
            // 
            button1.BackColor = Color.SteelBlue;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.DarkRed;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(16, 301);
            button1.Name = "button1";
            button1.Size = new Size(80, 43);
            button1.TabIndex = 22;
            button1.Text = "Volver";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.SteelBlue;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = Color.DeepSkyBlue;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(102, 301);
            button3.Name = "button3";
            button3.Size = new Size(150, 43);
            button3.TabIndex = 21;
            button3.Text = "Recuperar cuenta";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click_1;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.PapayaWhip;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(10, 88);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(242, 29);
            textBox1.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(10, 64);
            label2.Name = "label2";
            label2.Size = new Size(151, 21);
            label2.TabIndex = 15;
            label2.Text = "Correo Electronico:";
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.PapayaWhip;
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox4.Location = new Point(12, 241);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(242, 29);
            textBox4.TabIndex = 24;
            textBox4.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 217);
            label5.Name = "label5";
            label5.Size = new Size(143, 21);
            label5.TabIndex = 23;
            label5.Text = "Contraseña nueva:";
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.PapayaWhip;
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(12, 165);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(242, 29);
            textBox3.TabIndex = 26;
            textBox3.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 141);
            label1.Name = "label1";
            label1.Size = new Size(195, 21);
            label1.TabIndex = 25;
            label1.Text = "Codigo de Recuperacion:";
            // 
            // Recuperar_cuenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(266, 355);
            Controls.Add(textBox3);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Recuperar_cuenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recuperar_cuenta";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Label label4;
        private Button button1;
        private Button button3;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox3;
        private Label label1;
    }
}