namespace FinalProgram
{
    partial class FrmCargaRapida
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            btnCargarEjemplos = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            listProductos = new ListBox();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(250, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(300, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Carga Rápida de Productos";
            // 
            // btnCargarEjemplos
            // 
            btnCargarEjemplos.Font = new Font("Segoe UI", 12F);
            btnCargarEjemplos.Location = new Point(200, 350);
            btnCargarEjemplos.Name = "btnCargarEjemplos";
            btnCargarEjemplos.Size = new Size(180, 40);
            btnCargarEjemplos.TabIndex = 1;
            btnCargarEjemplos.Text = "Cargar Ejemplos";
            btnCargarEjemplos.UseVisualStyleBackColor = true;
            btnCargarEjemplos.Click += btnCargarEjemplos_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 12F);
            btnCancelar.Location = new Point(420, 350);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(180, 40);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(50, 60);
            label1.Name = "label1";
            label1.Size = new Size(700, 40);
            label1.TabIndex = 3;
            label1.Text = "Esta acción cargará productos de ejemplo para que puedas probar la aplicación.\r\nLos productos incluyen entradas, platos principales, postres y bebidas.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listProductos
            // 
            listProductos.Font = new Font("Segoe UI", 10F);
            listProductos.FormattingEnabled = true;
            listProductos.ItemHeight = 17;
            listProductos.Items.AddRange(new object[] {
            "🍕 Empanada Jamón y Queso - $150.00",
            "🍖 Milanesa Napolitana - $1,350.00", 
            "🍝 Fideos con Tuco - $850.00",
            "🥗 Ensalada Mixta - $650.00",
            "🍮 Flan con Dulce - $480.00",
            "🥤 Coca-Cola 500ml - $280.00",
            "☕ Café Cortado - $180.00",
            "🥐 Medialuna Dulce - $120.00"});
            listProductos.Location = new Point(200, 120);
            listProductos.Name = "listProductos";
            listProductos.Size = new Size(400, 191);
            listProductos.TabIndex = 4;
            // 
            // FrmCargaRapida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 420);
            Controls.Add(listProductos);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnCargarEjemplos);
            Controls.Add(lblTitulo);
            Name = "FrmCargaRapida";
            Text = "Carga Rápida de Datos";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitulo;
        private Button btnCargarEjemplos;
        private Button btnCancelar;
        private Label label1;
        private ListBox listProductos;
    }
}
