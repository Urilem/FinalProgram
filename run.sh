#!/bin/bash
if [ ! -f "bin/Debug/FinalProgram.exe" ]; then
    echo "Ejecutable no encontrado. Ejecuta ./build.sh primero."
    exit 1
fi

echo "======================================"
echo "Iniciando aplicación..."
echo "======================================"

mono bin/Debug/FinalProgram.exe
