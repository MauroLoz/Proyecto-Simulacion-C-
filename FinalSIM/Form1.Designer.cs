namespace FinalSIM
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_hasta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_desde = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_cant_sim = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_demoraPedidoB = new System.Windows.Forms.TextBox();
            this.txt_demoraPedidoA = new System.Windows.Forms.TextBox();
            this.txt_demoraAtencionB = new System.Windows.Forms.TextBox();
            this.txt_demoraAtencionA = new System.Windows.Forms.TextBox();
            this.txt_llegada_cliente = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.groupBox1.Controls.Add(this.txt_hasta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_desde);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_cant_sim);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Simulaciones";
            // 
            // txt_hasta
            // 
            this.txt_hasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_hasta.Location = new System.Drawing.Point(297, 74);
            this.txt_hasta.Name = "txt_hasta";
            this.txt_hasta.Size = new System.Drawing.Size(55, 29);
            this.txt_hasta.TabIndex = 5;
            this.txt_hasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_sim_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(245, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hasta";
            // 
            // txt_desde
            // 
            this.txt_desde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_desde.Location = new System.Drawing.Point(297, 39);
            this.txt_desde.Name = "txt_desde";
            this.txt_desde.Size = new System.Drawing.Size(55, 29);
            this.txt_desde.TabIndex = 3;
            this.txt_desde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_sim_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(243, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Desde";
            // 
            // txt_cant_sim
            // 
            this.txt_cant_sim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_cant_sim.Location = new System.Drawing.Point(159, 40);
            this.txt_cant_sim.Name = "txt_cant_sim";
            this.txt_cant_sim.Size = new System.Drawing.Size(55, 29);
            this.txt_cant_sim.TabIndex = 1;
            this.txt_cant_sim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_cant_sim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_sim_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cant. Simulaciones";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.groupBox2.Controls.Add(this.txt_demoraPedidoB);
            this.groupBox2.Controls.Add(this.txt_demoraPedidoA);
            this.groupBox2.Controls.Add(this.txt_demoraAtencionB);
            this.groupBox2.Controls.Add(this.txt_demoraAtencionA);
            this.groupBox2.Controls.Add(this.txt_llegada_cliente);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(12, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(581, 159);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametros";
            // 
            // txt_demoraPedidoB
            // 
            this.txt_demoraPedidoB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_demoraPedidoB.Location = new System.Drawing.Point(505, 108);
            this.txt_demoraPedidoB.Name = "txt_demoraPedidoB";
            this.txt_demoraPedidoB.Size = new System.Drawing.Size(50, 29);
            this.txt_demoraPedidoB.TabIndex = 17;
            // 
            // txt_demoraPedidoA
            // 
            this.txt_demoraPedidoA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_demoraPedidoA.Location = new System.Drawing.Point(449, 108);
            this.txt_demoraPedidoA.Name = "txt_demoraPedidoA";
            this.txt_demoraPedidoA.Size = new System.Drawing.Size(50, 29);
            this.txt_demoraPedidoA.TabIndex = 16;
            // 
            // txt_demoraAtencionB
            // 
            this.txt_demoraAtencionB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_demoraAtencionB.Location = new System.Drawing.Point(505, 68);
            this.txt_demoraAtencionB.Name = "txt_demoraAtencionB";
            this.txt_demoraAtencionB.Size = new System.Drawing.Size(50, 29);
            this.txt_demoraAtencionB.TabIndex = 15;
            // 
            // txt_demoraAtencionA
            // 
            this.txt_demoraAtencionA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_demoraAtencionA.Location = new System.Drawing.Point(449, 68);
            this.txt_demoraAtencionA.Name = "txt_demoraAtencionA";
            this.txt_demoraAtencionA.Size = new System.Drawing.Size(50, 29);
            this.txt_demoraAtencionA.TabIndex = 14;
            this.txt_demoraAtencionA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // txt_llegada_cliente
            // 
            this.txt_llegada_cliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_llegada_cliente.Location = new System.Drawing.Point(449, 33);
            this.txt_llegada_cliente.Name = "txt_llegada_cliente";
            this.txt_llegada_cliente.Size = new System.Drawing.Size(50, 29);
            this.txt_llegada_cliente.TabIndex = 6;
            this.txt_llegada_cliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_sim_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(209, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "Uniformemente distribuido";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(209, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "Uniformemente distribuido";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(209, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(226, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Distribucion exponencial negativa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(21, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Demora Pedido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(21, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Demora Atencion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(21, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Llegada Cliente";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(464, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 136);
            this.button1.TabIndex = 2;
            this.button1.Text = "Simular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(609, 352);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txt_hasta;
        private Label label3;
        private TextBox txt_desde;
        private Label label2;
        private TextBox txt_cant_sim;
        private Label label1;
        private GroupBox groupBox2;
        private TextBox txt_demoraPedidoB;
        private TextBox txt_demoraPedidoA;
        private TextBox txt_demoraAtencionB;
        private TextBox txt_demoraAtencionA;
        private TextBox txt_llegada_cliente;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button button1;
    }
}