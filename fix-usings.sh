#!/bin/bash
echo "🔧 Agregando using directives a todos los archivos..."

# Agregar a Program.cs
if ! grep -q "using System.Windows.Forms;" Program.cs; then
    sed -i '1s/^/using System.Windows.Forms;\n/' Program.cs
fi

# Agregar a FrmBase.cs
if ! grep -q "using System.Windows.Forms;" FrmBase.cs; then
    sed -i '1s/^/using System.Windows.Forms;\n/' FrmBase.cs
fi

# Agregar a Producto.cs
if ! grep -q "using System;" Producto.cs; then
    sed -i '1s/^/using System;\n/' Producto.cs
fi

# Agregar a todos los archivos .Designer.cs
for file in *.Designer.cs; do
    if ! grep -q "using System.Windows.Forms;" "$file"; then
        sed -i '1s/^/using System.Windows.Forms;\nusing System.Drawing;\n/' "$file"
        echo "✅ $file - corregido"
    else
        echo "✅ $file - ya tiene usings"
    fi
done

# Agregar a archivos .cs principales de forms
for file in FrmInicio.cs FrmAgregar.cs FrmListar.cs FrmModificar.cs FrmVender.cs; do
    if [ -f "$file" ] && ! grep -q "using System.Windows.Forms;" "$file"; then
        sed -i '1s/^/using System.Windows.Forms;\n/' "$file"
        echo "✅ $file - corregido"
    fi
done

echo "🎉 Todas las using directives agregadas"
