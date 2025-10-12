namespace FinalProgram
{
    partial class FrmInicio
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
            lblBienvenido = new Label();
            btnVender = new Button();
            btnAgregar = new Button();
            btnListar = new Button();
            btnSalir = new Button();
            btnModificar = new Button();
            SuspendLayout();
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.Font = new Font("Segoe UI", 20F);
            lblBienvenido.Location = new Point(316, 9);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(149, 37);
            lblBienvenido.TabIndex = 0;
            lblBienvenido.Text = "Bienvenido";
            lblBienvenido.Click += label1_Click;
            // 
            // btnVender
            // 
            btnVender.Font = new Font("Segoe UI", 15F);
            btnVender.Location = new Point(279, 76);
            btnVender.Name = "btnVender";
            btnVender.Size = new Size(214, 48);
            btnVender.TabIndex = 1;
            btnVender.Text = "Vender";
            btnVender.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 15F);
            btnAgregar.Location = new Point(279, 138);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(214, 48);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar producto";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnListar
            // 
            btnListar.Font = new Font("Segoe UI", 15F);
            btnListar.Location = new Point(279, 201);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(214, 48);
            btnListar.TabIndex = 3;
            btnListar.Text = "Listar productos";
            btnListar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 15F);
            btnSalir.Location = new Point(279, 330);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(214, 48);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Segoe UI", 15F);
            btnModificar.Location = new Point(279, 265);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(214, 48);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar producto";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // FrmInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 255, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(btnModificar);
            Controls.Add(btnSalir);
            Controls.Add(btnListar);
            Controls.Add(btnAgregar);
            Controls.Add(btnVender);
            Controls.Add(lblBienvenido);
            Name = "FrmInicio";
            Text = "Inicio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBienvenido;
        private Button btnVender;
        private Button btnAgregar;
        private Button btnListar;
        private Button btnSalir;
        private Button btnModificar;
    }
}