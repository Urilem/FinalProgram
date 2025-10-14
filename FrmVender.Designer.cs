using System.Windows.Forms;
using System.Drawing;

namespace FinalProgram
{
    partial class FrmVender
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblVender;
        private Label lblProducto;
        private Label lblid;
        private Label lblPrecioU;
        private Label lblNombreProducto;  // Cambiado de txtProducto
        private TextBox txtid;
        private Label lblPrecio;
        private Label lblCantidad;
        private Label lblPrecioF;
        private Label label1;
        private TextBox txtCantidad;
        private DataGridView tblProductos;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Subtotal;
        private Button btnCancelar;
        private Button btnVender;
        private Button btnAgregar;

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
            this.lblVender = new Label();
            this.lblProducto = new Label();
            this.lblid = new Label();
            this.lblPrecioU = new Label();
            this.lblNombreProducto = new Label();  // Cambiado de txtProducto
            this.txtid = new TextBox();
            this.lblPrecio = new Label();
            this.lblCantidad = new Label();
            this.lblPrecioF = new Label();
            this.label1 = new Label();
            this.txtCantidad = new TextBox();
            this.tblProductos = new DataGridView();
            this.Producto = new DataGridViewTextBoxColumn();
            this.Cantidad = new DataGridViewTextBoxColumn();
            this.Subtotal = new DataGridViewTextBoxColumn();
            this.btnCancelar = new Button();
            this.btnVender = new Button();
            this.btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.tblProductos).BeginInit();
            this.SuspendLayout();

            // lblVender
            this.lblVender.AutoSize = true;
            this.lblVender.Font = new Font("Segoe UI", 20F);
            this.lblVender.Location = new Point(339, 9);
            this.lblVender.Name = "lblVender";
            this.lblVender.Size = new Size(100, 37);
            this.lblVender.TabIndex = 0;
            this.lblVender.Text = "Vender";
            this.lblVender.Click += new System.EventHandler(this.label1_Click);

            // lblProducto
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new Font("Segoe UI", 15F);
            this.lblProducto.Location = new Point(29, 75);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new Size(97, 28);
            this.lblProducto.TabIndex = 1;
            this.lblProducto.Text = "Producto:";

            // lblid
            this.lblid.AutoSize = true;
            this.lblid.Font = new Font("Segoe UI", 15F);
            this.lblid.Location = new Point(29, 130);
            this.lblid.Name = "lblid";
            this.lblid.Size = new Size(35, 28);
            this.lblid.TabIndex = 2;
            this.lblid.Text = "ID:";

            // lblPrecioU
            this.lblPrecioU.AutoSize = true;
            this.lblPrecioU.Font = new Font("Segoe UI", 15F);
            this.lblPrecioU.Location = new Point(29, 191);
            this.lblPrecioU.Name = "lblPrecioU";
            this.lblPrecioU.Size = new Size(143, 28);
            this.lblPrecioU.TabIndex = 3;
            this.lblPrecioU.Text = "Precio unitario:";

            // lblNombreProducto (CAMBIO PRINCIPAL)
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Font = new Font("Segoe UI", 10F);
            this.lblNombreProducto.Location = new Point(164, 80);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new Size(196, 19);
            // this.lblNombreProducto.TabIndex = 4;
            // this.lblNombreProducto.Text = "Ingrese ID para buscar producto";
            // this.lblNombreProducto.BorderStyle = BorderStyle.FixedSingle;
            // this.lblNombreProducto.BackColor = Color.White;
            this.lblNombreProducto.Padding = new Padding(3);

            // txtid
            this.txtid.Location = new Point(164, 135);
            this.txtid.Name = "txtid";
            this.txtid.Size = new Size(196, 23);
            this.txtid.TabIndex = 5;

            // lblPrecio
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new Font("Segoe UI", 15F);
            this.lblPrecio.Location = new Point(300, 191);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new Size(60, 28);
            this.lblPrecio.TabIndex = 6;
            this.lblPrecio.Text = "$0,00";

            // lblCantidad
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new Font("Segoe UI", 15F);
            this.lblCantidad.Location = new Point(428, 72);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new Size(95, 28);
            this.lblCantidad.TabIndex = 7;
            this.lblCantidad.Text = "Cantidad:";

            // lblPrecioF
            this.lblPrecioF.AutoSize = true;
            this.lblPrecioF.Font = new Font("Segoe UI", 15F);
            this.lblPrecioF.Location = new Point(428, 191);
            this.lblPrecioF.Name = "lblPrecioF";
            this.lblPrecioF.Size = new Size(112, 28);
            this.lblPrecioF.TabIndex = 8;
            this.lblPrecioF.Text = "Precio final:";

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 15F);
            this.label1.Location = new Point(695, 191);
            this.label1.Name = "label1";
            this.label1.Size = new Size(60, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "$0,00";

            // txtCantidad
            this.txtCantidad.Location = new Point(655, 77);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new Size(100, 23);
            this.txtCantidad.TabIndex = 10;

            // tblProductos
            this.tblProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblProductos.Columns.AddRange(new DataGridViewColumn[] { this.Producto, this.Cantidad, this.Subtotal });
            this.tblProductos.Location = new Point(29, 288);
            this.tblProductos.Name = "tblProductos";
            this.tblProductos.Size = new Size(344, 150);
            this.tblProductos.TabIndex = 11;
            this.tblProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblProductos_CellContentClick);
            // Producto
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;

            // Cantidad
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;

            // Subtotal
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;

            // btnCancelar
            this.btnCancelar.BackColor = Color.Transparent;
            this.btnCancelar.Font = new Font("Segoe UI", 15F);
            this.btnCancelar.Location = new Point(637, 395);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(118, 43);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";

            // btnVender
            this.btnVender.Font = new Font("Segoe UI", 15F);
            this.btnVender.Location = new Point(498, 395);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new Size(118, 43);
            this.btnVender.TabIndex = 13;
            this.btnVender.Text = "Vender";

            // btnAgregar
            this.btnAgregar.Location = new Point(680, 246);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(75, 23);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "Agregar";

            // FrmVender
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(128, 255, 255);
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnVender);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.tblProductos);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPrecioF);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.lblNombreProducto);  // Cambiado de txtProducto
            this.Controls.Add(this.lblPrecioU);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.lblVender);
            this.Name = "FrmVender";
            this.Text = "Vender";
            ((System.ComponentModel.ISupportInitialize)this.tblProductos).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
