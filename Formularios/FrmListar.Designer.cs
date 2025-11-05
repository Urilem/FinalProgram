using System.Windows.Forms;
using System.Drawing;
namespace FinalProgram.Formularios
{
  partial class FrmListar
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

      gridProductos = new DataGridView();
      lblListar = new Label();
      btnVolver = new Button();
      ((System.ComponentModel.ISupportInitialize)gridProductos).BeginInit();
      SuspendLayout();
      // 
      // gridProductos
      // 
      gridProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      gridProductos.Location = new Point(12, 73);
      gridProductos.Name = "gridProductos";
      gridProductos.Size = new Size(776, 304);
      gridProductos.TabIndex = 0;
      gridProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      // 
      // lblListar
      // 
      lblListar.AutoSize = true;
      lblListar.Font = new Font("Segoe UI", 20F);
      lblListar.Location = new Point(321, 9);
      lblListar.Name = "lblListar";
      lblListar.Size = new Size(136, 37);
      lblListar.TabIndex = 1;
      lblListar.Text = "Productos";
      // 
      // btnVolver
      // 
      btnVolver.Font = new Font("Segoe UI", 15F);
      btnVolver.Location = new Point(611, 395);
      btnVolver.Name = "btnVolver";
      btnVolver.Size = new Size(118, 43);
      btnVolver.TabIndex = 2;
      btnVolver.Text = "Volver";
      btnVolver.UseVisualStyleBackColor = true;
      // 
      // FrmListar
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(128, 255, 255);
      ClientSize = new Size(800, 450);
      Controls.Add(btnVolver);
      Controls.Add(lblListar);
      Controls.Add(gridProductos);
      Name = "FrmListar";
      Text = "Listar";
      ((System.ComponentModel.ISupportInitialize)gridProductos).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private DataGridView gridProductos;
    private Label lblListar;
    private Button btnVolver;
  }
}
