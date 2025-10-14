#!/bin/bash
echo "🔧 CONVIRTIENDO A BÚSQUEDA POR ID"
echo "================================"

# Crear backup
cp FrmVender.Designer.cs FrmVender.Designer.cs.backup.id
cp FrmVender.cs FrmVender.cs.backup.id

# 1. Reemplazar txtProducto por lblNombreProducto en el diseñador
sed -i 's/private System.Windows.Forms.TextBox txtProducto;/private System.Windows.Forms.Label lblNombreProducto;/g' FrmVender.Designer.cs

# 2. Reemplazar la inicialización del TextBox por Label
sed -i '/txtProducto = new System.Windows.Forms.TextBox();/,/this.txtProducto.TabIndex = 4;/c\
this.lblNombreProducto = new System.Windows.Forms.Label();\
this.lblNombreProducto.AutoSize = true;\
this.lblNombreProducto.Font = new System.Drawing.Font("Segoe UI", 10F);\
this.lblNombreProducto.Location = new System.Drawing.Point(164, 80);\
this.lblNombreProducto.Name = "lblNombreProducto";\
this.lblNombreProducto.Size = new System.Drawing.Size(196, 19);\
this.lblNombreProducto.TabIndex = 4;\
this.lblNombreProducto.Text = "Ingrese ID para buscar producto";\
this.lblNombreProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;\
this.lblNombreProducto.BackColor = System.Drawing.Color.White;\
this.lblNombreProducto.Padding = new System.Windows.Forms.Padding(3);' FrmVender.Designer.cs

# 3. Reemplazar en los controles
sed -i 's/this.Controls.Add(this.txtProducto);/this.Controls.Add(this.lblNombreProducto);/g' FrmVender.Designer.cs

# 4. Reemplazar en el código C#
sed -i 's/txtProducto.Text/lblNombreProducto.Text/g' FrmVender.cs
sed -i 's/txtProducto.Clear()/lblNombreProducto.Text = "Ingrese ID para buscar producto"/g' FrmVender.cs

echo "✅ Conversión completada"
echo "🔨 Compilando..."
msbuild FinalProgram.csproj /p:Configuration=Debug

if [ $? -eq 0 ]; then
    echo "🎉 ¡COMPILACIÓN EXITOSA!"
    echo "🚀 La búsqueda ahora es solo por ID"
else
    echo "❌ Error en la compilación"
    echo "🔁 Restaurando backups..."
    cp FrmVender.Designer.cs.backup.id FrmVender.Designer.cs
    cp FrmVender.cs.backup.id FrmVender.cs
fi
