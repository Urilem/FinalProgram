using System.Windows.Forms;
using System.Drawing;
namespace FinalProgram.Formularios
{
  partial class FrmModificar
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
      lblModificar = new Label();
      lblid = new Label();
      lblNombre = new Label();
      lblPrecio = new Label();
      lblStock = new Label();
      txtID = new TextBox();
      txtNombre = new TextBox();
      txtPrecio = new TextBox();
      txtStock = new TextBox();
      btnCancelar = new Button();
      btnConfirmar = new Button();
      SuspendLayout();
      // 
      // lblModificar
      // 
      lblModificar.AutoSize = true;
      lblModificar.Font = new Font("Segoe UI", 20F);
      lblModificar.Location = new Point(309, 9);
      lblModificar.Name = "lblModificar";
      lblModificar.Size = new Size(130, 37);
      lblModificar.TabIndex = 0;
      lblModificar.Text = "Modificar";
      // 
      // lblid
      // 
      lblid.AutoSize = true;
      lblid.Font = new Font("Segoe UI", 15F);
      lblid.Location = new Point(56, 82);
      lblid.Name = "lblid";
      lblid.Size = new Size(35, 28);
      lblid.TabIndex = 1;
      lblid.Text = "ID:";
      // 
      // lblNombre
      // 
      lblNombre.AutoSize = true;
      lblNombre.Font = new Font("Segoe UI", 15F);
      lblNombre.Location = new Point(56, 145);
      lblNombre.Name = "lblNombre";
      lblNombre.Size = new Size(89, 28);
      lblNombre.TabIndex = 2;
      lblNombre.Text = "Nombre:";
      // 
      // lblPrecio
      // 
      lblPrecio.AutoSize = true;
      lblPrecio.Font = new Font("Segoe UI", 15F);
      lblPrecio.Location = new Point(56, 216);
      lblPrecio.Name = "lblPrecio";
      lblPrecio.Size = new Size(70, 28);
      lblPrecio.TabIndex = 3;
      lblPrecio.Text = "Precio:";
      // 
      // lblStock
      // 
      lblStock.AutoSize = true;
      lblStock.Font = new Font("Segoe UI", 15F);
      lblStock.Location = new Point(56, 293);
      lblStock.Name = "lblStock";
      lblStock.Size = new Size(64, 28);
      lblStock.TabIndex = 4;
      lblStock.Text = "Stock:";
      // 
      // txtID
      // 
      txtID.Location = new Point(436, 87);
      txtID.Name = "txtID";
      txtID.Size = new Size(226, 23);
      txtID.TabIndex = 5;
      // 
      // txtNombre
      // 
      txtNombre.Location = new Point(436, 150);
      txtNombre.Name = "txtNombre";
      txtNombre.Size = new Size(226, 23);
      txtNombre.TabIndex = 6;
      // 
      // txtPrecio
      // 
      txtPrecio.Location = new Point(436, 221);
      txtPrecio.Name = "txtPrecio";
      txtPrecio.Size = new Size(226, 23);
      txtPrecio.TabIndex = 7;
      // 
      // txtStock
      // 
      txtStock.Location = new Point(436, 298);
      txtStock.Name = "txtStock";
      txtStock.Size = new Size(226, 23);
      txtStock.TabIndex = 8;
      // 
      // btnCancelar
      // 
      btnCancelar.Font = new Font("Segoe UI", 15F);
      btnCancelar.Location = new Point(611, 395);
      btnCancelar.Name = "btnCancelar";
      btnCancelar.Size = new Size(118, 43);
      btnCancelar.TabIndex = 9;
      btnCancelar.Text = "Cancelar";
      btnCancelar.UseVisualStyleBackColor = true;
      // 
      // btnConfirmar
      // 
      btnConfirmar.Font = new Font("Segoe UI", 15F);
      btnConfirmar.Location = new Point(463, 395);
      btnConfirmar.Name = "btnConfirmar";
      btnConfirmar.Size = new Size(118, 43);
      btnConfirmar.TabIndex = 10;
      btnConfirmar.Text = "Confirmar";
      btnConfirmar.UseVisualStyleBackColor = true;
      // 
      // FrmModificar
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(128, 255, 255);
      ClientSize = new Size(800, 450);
      Controls.Add(btnConfirmar);
      Controls.Add(btnCancelar);
      Controls.Add(txtStock);
      Controls.Add(txtPrecio);
      Controls.Add(txtNombre);
      Controls.Add(txtID);
      Controls.Add(lblStock);
      Controls.Add(lblPrecio);
      Controls.Add(lblNombre);
      Controls.Add(lblid);
      Controls.Add(lblModificar);
      Name = "FrmModificar";
      Text = "Modificar";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Label lblModificar;
    private Label lblid;
    private Label lblNombre;
    private Label lblPrecio;
    private Label lblStock;
    private TextBox txtID;
    private TextBox txtNombre;
    private TextBox txtPrecio;
    private TextBox txtStock;
    private Button btnCancelar;
    private Button btnConfirmar;
  }
}
