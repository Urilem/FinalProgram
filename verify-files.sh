#!/bin/bash
echo "🔍 Verificación detallada de archivos..."
echo ""

echo "=== USING DIRECTIVES ==="
for file in *.cs; do
    if [ -f "$file" ]; then
        usings=$(grep -c "^using" "$file" || echo "0")
        echo "📄 $file: $usings using directives"
    fi
done

echo ""
echo "=== ERRORES COMUNES ==="
# Verificar STAThread en Program.cs
if grep -q "STAThread" Program.cs; then
    echo "✅ Program.cs tiene STAThread"
else
    echo "❌ Program.cs NO tiene STAThread"
fi

# Verificar Form en FrmBase.cs
if grep -q "class FrmBase : Form" FrmBase.cs; then
    echo "✅ FrmBase hereda de Form"
else
    echo "❌ FrmBase NO hereda de Form"
fi

# Verificar TimeSpan en Producto.cs
if grep -q "TimeSpan" Producto.cs; then
    echo "✅ Producto.cs usa TimeSpan"
else
    echo "❌ Producto.cs NO usa TimeSpan"
fi
