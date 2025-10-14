#!/bin/bash
echo "🧹 LIMPIEZA COMPLETA Y CONSTRUCCIÓN"
echo "==================================="

# Limpiar archivos de compilación anteriores
echo "🗑️  Eliminando bin y obj..."
rm -rf bin obj

# Limpiar backups temporales
echo "🗑️  Limpiando archivos temporales..."
find . -name "*.backup.*" -delete
find . -name "*.tmp" -delete

# Verificar que los archivos nuevos están en el .csproj
echo "📋 Verificando archivos en el proyecto..."
if grep -q "FrmTicket.cs" FinalProgram.csproj; then
    echo "✅ FrmTicket.cs está en el proyecto"
else
    echo "❌ FrmTicket.cs NO está en el proyecto - agregando..."
    sed -i '/<Compile Include="FrmVender.Designer.cs" \/>/a\    <Compile Include="FrmTicket.cs" \/>' FinalProgram.csproj
fi

if grep -q "FrmTicket.Designer.cs" FinalProgram.csproj; then
    echo "✅ FrmTicket.Designer.cs está en el proyecto"
else
    echo "❌ FrmTicket.Designer.cs NO está en el proyecto - agregando..."
    sed -i '/<Compile Include="FrmTicket.cs" \/>/a\    <Compile Include="FrmTicket.Designer.cs" \/>' FinalProgram.csproj
fi

# Reconstruir
echo "🔨 Compilando proyecto..."
msbuild FinalProgram.csproj /p:Configuration=Debug

# Verificar resultado
if [ $? -eq 0 ]; then
    echo "🎉 ¡COMPILACIÓN EXITOSA!"
    echo "🚀 Ejecuta: ./run.sh"
else
    echo "❌ Error en la compilación"
    echo "📝 Revisa los mensajes de error arriba"
fi
