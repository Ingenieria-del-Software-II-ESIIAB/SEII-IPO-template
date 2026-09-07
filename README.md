# Instalación de VS Code y herramientas relacionadas

## Instalación VS Code
Descargar e instalar (VS Code)[https://code.visualstudio.com/download?_exp_download=fb315fc982]

## Control de Versiones

### Instalar Git 
Descargar e instalar Git for Windows (Mac o Linux dependiendo de tu máquina) usando las opciones por defecto (GIT) [https://git-scm.com/install/windows]

### Instalar las siguientes extensiones en VS Code para Git:
- GitHub Pull Requests: para control de versiones
- Git Graph: Git Graph del repositorio
- Git History: ver el log e historia de los archivos.

## Instalar para desarrollo

Descargar e instalar en tu máquina [.NET10](https://dotnet.microsoft.com/en-us/download/dotnet/10.0).

Descargar e instalar en tu máquina SQL Server 2025 Express Edition [SQL Server 2025 Express Edition] (https://learn.microsoft.com/es-es/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver17#install-localdb)

Instalar en VS Code las extensiones:
- C#: de Microsoft para soporte al lenguaje
- C# Namespace autocompletion
- C# Dev Kit: de Microsoft para soporte a desarrollo
- .NET Install Tool
- .Net Maui
- Microsoft.AspNetCore.Razor.VSCode.BlazorWasmDebuggingExtension
- MSSQL: para gestión de la BD en local
- Open in Browser: para abrir archivos .html
- PlantUML: para generar los diagramas a partir del código

## Para aquellos equipos que vayan a desarrollar su proyecto con MAUI para la asignatura de IPO:
Seguir las instrucciones que se indican en el siguiente enlace [MAUI](https://learn.microsoft.com/es-es/dotnet/maui/get-started/installation?view=net-maui-10.0&tabs=visual-studio-code#connect-your-account-to-c-dev-kit)
Ya se proporciona un proyecto para desarrollo AppForSEII.MAUI por lo que no es necesario su creación.


## Instalar para testing

Instalar extensiones:

- .Net Core Test Explorer
- Coverage Gutters para visualización de la cobertura de código. 

Instalar en el terminal:

- ReportGenerator como herramienta .NET:

```bash
dotnet tool install --global dotnet-reportgenerator-globaltool
```

# Preparar el proyecto para iniciar el desarrollo

## Crea el proyecto
Clona la plantilla del proyecto

## Instala las herramientas para Entity Framework en el proyecto:

```bash
dotnet tool install --global dotnet-ef
```

## Instala las herramientas para generación de modelos UML a partir de código en tu proyecto:

```bash
dotnet tool install --global PlantUmlClassDiagramGenerator
```

## Instala las herramientas Roslynator para refactoring:

```bash
dotnet add package Roslynator.Analyzers
dotnet add package Roslynator.CodeAnalysis.Analyzer
dotnet add package Roslynator.Formatting.Analyzers
dotnet add package Roslynator.CodeFixes
```

# Desarrolla tu proyecto 

## Compilar, limpiar y depurar

1. Abre el terminal integrado en VS Code Menú: View → Terminal (o Ctrl + ñ en teclado español). 
2. Situate en la carpeta del proyecto con el que quieres trabajar (.csproj).
3. Compilar. Si estas en la carpeta de un proyecto, compilará ese proyecto, si estás en la carpeta de la solución, compilará todos los proyectos:

```bash
dotnet build
```

Para compilar en modo release:

```bash
dotnet build -c Release
```

Esto:
        Compila el código
        Restaura paquetes NuGet si es necesario
        Genera la salida en bin/Debug/net10.0/
4.  Restaurar paquetes antes de compilar (por si hay dependencias nuevas):
    dotnet restore
5.  Ejecutar la aplicación (si estas en la carpeta de la Web API):

```bash
dotnet run
```

Puedes especificar un proyecto si estás en la raíz de la solución:

```bash
dotnet run --project MyApi/MyApi.csproj
```

6. En caso de necesitar limpiar el proyecto o la solución:

```bash
dotnet clean
```

## Ejecutar tareas

CTRL+Shift+p: Ejecutar tareas: Depurar, Build, etc.

## Refactorización

Ctrl+shift+r: refactorizaciones soportadas por Roslynator.
Ctrl+.: Genera código: Selecciona atributos para generar constructores y método equals.

## Trabajar con migraciones:

En el terminal integrado de VS Code, sitúate en la carpeta que contiene el .csproj donde están las clases de modelo:

```bash
cd ruta/de/tu/proyecto
```

- Crear la migración en la carpeta Migrations/ con los archivos necesarios:

```bash
dotnet ef migrations add CreateIdentitySchema
```

- Ver el estado actual del modelo:

```bash
dotnet ef migrations list
```

- Eliminar la última migración:

```bash
dotnet ef migrations remove
```

- Aplicar la migración a la BD

```bash
dotnet ef database update
```

## Generar diagramas desde código

Al ejecutar el siguiente comando desde la carpeta de la solución:

```bash
puml-gen ./src/Examenes.API/Models/Hogwarts  ./docs/uml -dir -excludePaths **/bin,**/obj,**/Migrations  -createAssociation  -allInOne
```

cuyas opciones son:

- dir procesa directorios de entrada/salida.
- excludePaths evita ruido de bin/ y obj/.
- createAssociation detecta asociaciones desde campos/props.
- allInOne crea un include.puml para agrupar todo. [github.com], [deepwiki.com]

Se generan .puml (y un include.puml si usas -allInOne) que puedes abrir y previsualizar en VS Code con la extensión PlantUML. La extensión recomienda el render por servidor (evita instalar Java/Graphviz), y soporta exportación a PNG/SVG. [marketplac...studio.com]

Para ver el diagrama, abrir include.puml y pulsar Alt+d


## Testing: Usar coverlet collector

1. Añade el paquete coverlet.collector a tu proyecto de pruebas y ejecuta:

```bash
dotnet add <TU_PROYECTO_TEST>.csproj package coverlet.collector
```

2. Ejecuta la **generación de cobertura**.

Genera Cobertura bajo TestResults/<GUID>/coverage.cobertura.xml. Coverlet está integrado con VSTest, y esta es la forma recomendada para recoger cobertura en proyectos .NET (funciona con MSTest, xUnit, NUnit):

```bash
dotnet test --collect:"XPlat Code Coverage"
```

3. Genera el informe

```bash
reportgenerator   -reports:"TestResults/**/coverage.cobertura.xml"   -targetdir:"coverage-report"   -reporttypes:Html
```

4. Visualiza la cobertura de las pruebas

Con **Coverage Gutters**: CTRL+SHIT+P: Coverage Gutter: Display.