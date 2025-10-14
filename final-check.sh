#!/bin/bash
echo "🔍 VERIFICACIÓN FINAL COMPLETA"
echo "=============================="

echo "=== ARCHIVOS CRÍTICOS ==="
critical_files=("Program.cs" "FrmBase.cs" "FrmAgregar.cs" "Producto.cs")
for file in "${critical_files[@]}"; do
    if [ -f "$file" ]; then
        status="✅"
        # Verificar using directives
        if [ "$file" = "Producto.cs" ]; then
            if ! grep -q "using System" "$file"; then
                status="❌"
            fi
        else
            if ! grep -q "using System.Windows.Forms" "$file"; then
                status="❌"
            fi
        fi
        # Verificar constructores duplicados
        if [ "$file" = "FrmAgregar.cs" ]; then
            constructors=$(grep -c "public FrmAgregar()" "$file")
            if [ "$constructors" -gt 1 ]; then
                status="❌"
            fi
        fi
        echo "$status $file"
    else
        echo "❌ $file - NO ENCONTRADO"
    fi
done

echo ""
echo "=== EJECUTABLE ==="
if [ -f "bin/Debug/FinalProgram.exe" ]; then
    echo "✅ bin/Debug/FinalProgram.exe - EXISTE"
    echo "   Tamaño: $(ls -lh bin/Debug/FinalProgram.exe | awk '{print $5}')"
else
    echo "❌ bin/Debug/FinalProgram.exe - NO ENCONTRADO"
fi

echo ""
echo "=== RESUMEN ==="
if [ -f "bin/Debug/FinalProgram.exe" ]; then
    echo "🎉 ¡LA APLICACIÓN ESTÁ LISTA!"
    echo "🚀 Ejecuta: ./run.sh"
else
    echo "📝 Ejecuta: ./build-optimized.sh"
fi
