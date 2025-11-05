using System.Drawing;
using System.Windows.Forms;

namespace FinalProgram.Formularios
{
  partial class FrmAgregar
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
      lblAgregar = new Label();
      lblNombre = new Label();
      txtNombre = new TextBox();
      txtPrecio = new TextBox();
      txtCantidad = new TextBox();
      lblPrecio = new Label();
      lblCantidad = new Label();
      btnCancelar = new Button();
      btnAgregar = new Button();
      SuspendLayout();
      // 
      // lblAgregar
      // 
      lblAgregar.AutoSize = true;
      lblAgregar.Font = new Font("Segoe UI", 20F);
      lblAgregar.Location = new Point(279, 9);
      lblAgregar.Name = "lblAgregar";
      lblAgregar.Size = new Size(228, 37);
      lblAgregar.TabIndex = 0;
      lblAgregar.Text = "Agregar producto";
      // 
      // lblNombre
      // 
      lblNombre.AutoSize = true;
      lblNombre.Font = new Font("Segoe UI", 15F);
      lblNombre.Location = new Point(40, 95);
      lblNombre.Name = "lblNombre";
      lblNombre.Size = new Size(89, 28);
      lblNombre.TabIndex = 1;
      lblNombre.Text = "Nombre:";
      // 
      // txtNombre
      // 
      txtNombre.Location = new Point(279, 100);
      txtNombre.Name = "txtNombre";
      txtNombre.Size = new Size(228, 23);
      txtNombre.TabIndex = 2;
      // 
      // txtPrecio
      // 
      txtPrecio.Location = new Point(279, 158);
      txtPrecio.Name = "txtPrecio";
      txtPrecio.Size = new Size(228, 23);
      txtPrecio.TabIndex = 3;
      // 
      // txtCantidad
      // 
      txtCantidad.Location = new Point(279, 212);
      txtCantidad.Name = "txtCantidad";
      txtCantidad.Size = new Size(228, 23);
      txtCantidad.TabIndex = 4;
      // 
      // lblPrecio
      // 
      lblPrecio.AutoSize = true;
      lblPrecio.Font = new Font("Segoe UI", 15F);
      lblPrecio.Location = new Point(40, 153);
      lblPrecio.Name = "lblPrecio";
      lblPrecio.Size = new Size(70, 28);
      lblPrecio.TabIndex = 5;
      lblPrecio.Text = "Precio:";
      // 
      // lblCantidad
      // 
      lblCantidad.AutoSize = true;
      lblCantidad.Font = new Font("Segoe UI", 15F);
      lblCantidad.Location = new Point(40, 207);
      lblCantidad.Name = "lblCantidad";
      lblCantidad.Size = new Size(95, 28);
      lblCantidad.TabIndex = 6;
      lblCantidad.Text = "Cantidad:";
      // 
      // btnCancelar
      // 
      btnCancelar.Font = new Font("Segoe UI", 15F);
      btnCancelar.Location = new Point(624, 395);
      btnCancelar.Name = "btnCancelar";
      btnCancelar.Size = new Size(118, 43);
      btnCancelar.TabIndex = 7;
      btnCancelar.Text = "Cancelar";
      btnCancelar.UseVisualStyleBackColor = true;
      btnCancelar.Click += btnCancelar_Click;
      // 
      // btnAgregar
      // 
      btnAgregar.Font = new Font("Segoe UI", 15F);
      btnAgregar.Location = new Point(478, 395);
      btnAgregar.Name = "btnAgregar";
      btnAgregar.Size = new Size(118, 43);
      btnAgregar.TabIndex = 8;
      btnAgregar.Text = "Agregar";
      btnAgregar.UseVisualStyleBackColor = true;
      // 
      // FrmAgregar
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(128, 255, 255);
      ClientSize = new Size(800, 450);
      Controls.Add(btnAgregar);
      Controls.Add(btnCancelar);
      Controls.Add(lblCantidad);
      Controls.Add(lblPrecio);
      Controls.Add(txtCantidad);
      Controls.Add(txtPrecio);
      Controls.Add(txtNombre);
      Controls.Add(lblNombre);
      Controls.Add(lblAgregar);
      Name = "FrmAgregar";
      Text = "Agregar";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Label lblAgregar;
    private Label lblNombre;
    private TextBox txtNombre;
    private TextBox txtPrecio;
    private TextBox txtCantidad;
    private Label lblPrecio;
    private Label lblCantidad;
    private Button btnCancelar;
    private Button btnAgregar;
  }
}
