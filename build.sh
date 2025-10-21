#!/bin/bash
echo "Compilando Casa de Comida Casera..."
echo "======================================"

# Verificar y corregir Program.cs si es necesario
if grep -q "ApplicationConfiguration.Initialize()" Program.cs; then
    echo "🔧 Corrigiendo Program.cs para .NET Framework..."
    sed -i 's/ApplicationConfiguration.Initialize();/Application.EnableVisualStyles();\n            Application.SetCompatibleTextRenderingDefault(false);/g' Program.cs
    echo "Program.cs corregido"
fi

# Verificar configuración de base de datos
echo "🔍 Verificando configuración..."
if [ -f "config.txt" ]; then
    REPOSITORY_TYPE=$(grep -E "^RepositoryType=" config.txt | cut -d'=' -f2)
    if [ "$REPOSITORY_TYPE" = "SQL" ]; then
        echo "📊 Modo: Base de Datos SQL"
        echo "🔗 Verificando conexión a SQL Server..."
        
        # Verificar si Docker está ejecutándose
        if ! docker ps > /dev/null 2>&1; then
            echo "❌ Docker no está ejecutándose"
            echo "💡 Ejecuta: sudo systemctl start docker"
            exit 1
        fi
        
        # Verificar si el contenedor de SQL Server está saludable
        if docker ps --format "table {{.Names}}\t{{.Status}}" | grep -q "sqlserver-dev.*healthy"; then
            echo "✅ SQL Server está conectado y saludable"
        elif docker ps | grep -q "sqlserver-dev"; then
            echo "⚠️  SQL Server está ejecutándose pero no saludable (puede estar iniciando)"
            echo "💡 Espera unos segundos y vuelve a intentar"
        else
            echo "❌ Contenedor de SQL Server no encontrado"
            echo "💡 Ejecuta: docker-compose up -d"
            exit 1
        fi
    else
        echo "📝 Modo: Memoria (sin base de datos)"
    fi
else
    echo "📝 Modo: Memoria (config.txt no encontrado)"
fi

echo ""
echo "🧹 Limpiando builds anteriores..."
rm -rf bin/ obj/

echo "🔨 Compilando proyecto..."
msbuild FinalProgram.csproj /p:Configuration=Debug /verbosity:minimal

if [ $? -eq 0 ]; then
    echo ""
    echo "✅ ¡COMPILACIÓN EXITOSA!"
    if [ "$REPOSITORY_TYPE" = "SQL" ]; then
        echo "📊 Conectado a Base de Datos SQL Server"
    else
        echo "📝 Usando almacenamiento en Memoria"
    fi
    echo ""
    echo "🚀 Para ejecutar: ./run.sh"
    echo ""
else
    echo "❌ Error en la compilación"
    exit 1
fi
