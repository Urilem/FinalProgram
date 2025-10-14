#!/bin/bash
echo "🔧 CORRECCIÓN DE ApplicationConfiguration"
echo "========================================"

# Verificar que el archivo existe
if [ ! -f "Program.cs" ]; then
    echo "❌ Error: No se encuentra Program.cs"
    exit 1
fi

# Crear backup
BACKUP_FILE="Program.cs.backup.$(date +%Y%m%d_%H%M%S)"
cp Program.cs "$BACKUP_FILE"
echo "📁 Backup creado: $BACKUP_FILE"

# Reemplazar ApplicationConfiguration.Initialize() con las líneas compatibles
sed -i 's/ApplicationConfiguration.Initialize();/Application.EnableVisualStyles();\n            Application.SetCompatibleTextRenderingDefault(false);/g' Program.cs

echo "✅ Program.cs corregido para .NET Framework"
echo ""
echo "📋 Cambios realizados:"
echo "   - Reemplazado: ApplicationConfiguration.Initialize();"
echo "   - Por: Application.EnableVisualStyles();"
echo "         Application.SetCompatibleTextRenderingDefault(false);"

# Verificar que la corrección fue exitosa
if grep -q "Application.EnableVisualStyles();" Program.cs && grep -q "Application.SetCompatibleTextRenderingDefault(false);" Program.cs; then
    echo "✅ Corrección verificada"
else
    echo "❌ Error en la corrección"
    echo "🔁 Restaurando backup..."
    cp "$BACKUP_FILE" Program.cs
    exit 1
fi
