Tree de los archivos

FinalProgram/
├── Models/           # Entidades del dominio
├── Data/            # Acceso a datos (DAL)
├── Services/        # Lógica de negocio (BLL)
├── Forms/           # Formularios
├── Helpers/         # Utilidades
└── app.config       # Configuración



FLUJO PRINCIPAL DE DATOS:

1. INICIO:
   Program.cs → Crea ProductoService → Inyecta ProductoRepositorySQL → Abre FrmInicio

2. OPERACIONES CRUD:
   FrmAgregar/FrmModificar/FrmListar → ProductoService → ProductoRepositorySQL → Base de Datos

3. PROCESO DE VENTA:
   FrmVender → ProductoService (validar stock) → ProductoRepositorySQL (actualizar) → FrmTicket

4. MODELOS DE DATOS:
   Producto (Id, Nombre, Precio, Stock)
   DetalleVenta (Producto, Cantidad, PrecioUnitario, Subtotal)

Explicación para exposición oral:

    CAPA DE PRESENTACIÓN (UI)

        FrmInicio: Menú principal que coordina toda la aplicación

        FrmAgregar: Formulario para crear nuevos productos

        FrmListar: Muestra listado completo de productos

        FrmModificar: Permite editar productos existentes

        FrmVender: Gestiona el proceso completo de venta

        FrmTicket: Genera comprobante de venta con formato

    CAPA DE SERVICIO (Lógica de Negocio)

        Program.cs: Punto de entrada, configura la inyección de dependencias

        ProductoService: Orquesta las operaciones y aplica validaciones de negocio

    CAPA DE PERSISTENCIA (Datos)

        IProductoRepository: Define el contrato para operaciones de datos

        ProductoRepositorySQL: Implementación concreta para SQL Server

        App.config: Almacena la cadena de conexión a la base de datos

    MODELOS (Entidades)

        Producto: Representa un producto en el sistema

        DetalleVenta: Representa un ítem en una venta

Flujo de una Venta:

    Usuario ingresa ID y cantidad en FrmVender

    Sistema valida stock disponible via ProductoService

    Se agrega a la lista temporal de DetalleVenta

    Al confirmar: se actualiza stock y se genera ticket

    FrmTicket muestra el comprobante formateado

Patrones Utilizados:

    Repository Pattern: Abstracción del acceso a datos

    Service Layer: Separa lógica de negocio de la presentación

    Dependency Injection: En Program.cs se inyecta el repositorio

Este diseño permite:

    Mantener separación de responsabilidades

    Facilita el mantenimiento y testing

    Permite cambiar la base de datos sin afectar otras capas

    Centraliza la lógica de negocio en ProductoService

