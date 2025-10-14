using System.Windows.Forms;
using System.Drawing;
﻿namespace FinalProgram
{
    partial class FrmVender
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
            lblVender = new Label();
            lblProducto = new Label();
            lblid = new Label();
            lblPrecioU = new Label();
            txtProducto = new TextBox();
            txtid = new TextBox();
            lblPrecio = new Label();
            lblCantidad = new Label();
            lblPrecioF = new Label();
            label1 = new Label();
            txtCantidad = new TextBox();
            tblProductos = new DataGridView();
            Producto = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Subtotal = new DataGridViewTextBoxColumn();
            btnCancelar = new Button();
            btnVender = new Button();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)tblProductos).BeginInit();
            SuspendLayout();
            // 
            // lblVender
            // 
            lblVender.AutoSize = true;
            lblVender.Font = new Font("Segoe UI", 20F);
            lblVender.Location = new Point(339, 9);
            lblVender.Name = "lblVender";
            lblVender.Size = new Size(100, 37);
            lblVender.TabIndex = 0;
            lblVender.Text = "Vender";
            lblVender.Click += label1_Click;
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Font = new Font("Segoe UI", 15F);
            lblProducto.Location = new Point(29, 75);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(97, 28);
            lblProducto.TabIndex = 1;
            lblProducto.Text = "Producto:";
            // 
            // lblid
            // 
            lblid.AutoSize = true;
            lblid.Font = new Font("Segoe UI", 15F);
            lblid.Location = new Point(29, 130);
            lblid.Name = "lblid";
            lblid.Size = new Size(35, 28);
            lblid.TabIndex = 2;
            lblid.Text = "ID:";
            // 
            // lblPrecioU
            // 
            lblPrecioU.AutoSize = true;
            lblPrecioU.Font = new Font("Segoe UI", 15F);
            lblPrecioU.Location = new Point(29, 191);
            lblPrecioU.Name = "lblPrecioU";
            lblPrecioU.Size = new Size(143, 28);
            lblPrecioU.TabIndex = 3;
            lblPrecioU.Text = "Precio unitario:";
            // 
            // txtProducto
            // 
            txtProducto.Location = new Point(164, 80);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(196, 23);
            txtProducto.TabIndex = 4;
            txtProducto.Text = "Escribe aquí...";
            // 
            // txtid
            // 
            txtid.Location = new Point(164, 135);
            txtid.Name = "txtid";
            txtid.Size = new Size(196, 23);
            txtid.TabIndex = 5;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 15F);
            lblPrecio.Location = new Point(300, 191);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(60, 28);
            lblPrecio.TabIndex = 6;
            lblPrecio.Text = "$0,00";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 15F);
            lblCantidad.Location = new Point(428, 72);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(95, 28);
            lblCantidad.TabIndex = 7;
            lblCantidad.Text = "Cantidad:";
            // 
            // lblPrecioF
            // 
            lblPrecioF.AutoSize = true;
            lblPrecioF.Font = new Font("Segoe UI", 15F);
            lblPrecioF.Location = new Point(428, 191);
            lblPrecioF.Name = "lblPrecioF";
            lblPrecioF.Size = new Size(112, 28);
            lblPrecioF.TabIndex = 8;
            lblPrecioF.Text = "Precio final:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(695, 191);
            label1.Name = "label1";
            label1.Size = new Size(60, 28);
            label1.TabIndex = 9;
            label1.Text = "$0,00";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(655, 77);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(100, 23);
            txtCantidad.TabIndex = 10;
            // 
            // tblProductos
            // 
            tblProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tblProductos.Columns.AddRange(new DataGridViewColumn[] { Producto, Cantidad, Subtotal });
            tblProductos.Location = new Point(29, 288);
            tblProductos.Name = "tblProductos";
            tblProductos.Size = new Size(344, 150);
            tblProductos.TabIndex = 11;
            tblProductos.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Producto
            // 
            Producto.HeaderText = "Producto";
            Producto.Name = "Producto";
            Producto.ReadOnly = true;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            // 
            // Subtotal
            // 
            Subtotal.HeaderText = "Subtotal";
            Subtotal.Name = "Subtotal";
            Subtotal.ReadOnly = true;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Transparent;
            btnCancelar.Font = new Font("Segoe UI", 15F);
            btnCancelar.Location = new Point(637, 395);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(118, 43);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnVender
            // 
            btnVender.Font = new Font("Segoe UI", 15F);
            btnVender.Location = new Point(498, 395);
            btnVender.Name = "btnVender";
            btnVender.Size = new Size(118, 43);
            btnVender.TabIndex = 13;
            btnVender.Text = "Vender";
            btnVender.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(680, 246);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 14;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // FrmVender
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 255, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(btnAgregar);
            Controls.Add(btnVender);
            Controls.Add(btnCancelar);
            Controls.Add(tblProductos);
            Controls.Add(txtCantidad);
            Controls.Add(label1);
            Controls.Add(lblPrecioF);
            Controls.Add(lblCantidad);
            Controls.Add(lblPrecio);
            Controls.Add(txtid);
            Controls.Add(txtProducto);
            Controls.Add(lblPrecioU);
            Controls.Add(lblid);
            Controls.Add(lblProducto);
            Controls.Add(lblVender);
            Name = "FrmVender";
            Text = "Vender";
            ((System.ComponentModel.ISupportInitialize)tblProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblVender;
        private Label lblProducto;
        private Label lblid;
        private Label lblPrecioU;
        private TextBox txtProducto;
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
    }
}
