#!/bin/bash
echo "Compilando Casa de Comida Casera..."
echo "======================================"

# Verificar y corregir Program.cs si es necesario
if grep -q "ApplicationConfiguration.Initialize()" Program.cs; then
    echo "🔧 Corrigiendo Program.cs para .NET Framework..."
    sed -i 's/ApplicationConfiguration.Initialize();/Application.EnableVisualStyles();\n            Application.SetCompatibleTextRenderingDefault(false);/g' Program.cs
    echo "Program.cs corregido"
fi

echo "Limpiando builds anteriores..."
rm -rf bin/ obj/

echo "Compilando proyecto..."
msbuild FinalProgram.csproj /p:Configuration=Debug /verbosity:minimal

if [ $? -eq 0 ]; then
    echo ""
    echo "¡COMPILACIÓN EXITOSA!"
    echo "Para ejecutar: mono bin/Debug/FinalProgram.exe"
    echo ""
else
    echo "❌ Error en la compilación"
    exit 1
fi
