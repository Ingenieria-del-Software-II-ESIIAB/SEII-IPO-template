# Instalación de VS Code y herramientas relacionadas

## Instalación VS Code
Descargar e instalar [VS Code](https://code.visualstudio.com/download?_exp_download=fb315fc982)

## Control de Versiones: Instalar Git 
Descargar e instalar Git for Windows (Mac o Linux dependiendo de tu máquina) usando las opciones por defecto [GIT](https://git-scm.com/install/windows)

## Instalar para desarrollo

Descargar e instalar en tu máquina [.NET10](https://dotnet.microsoft.com/en-us/download/dotnet/10.0).

Descargar e instalar en tu máquina SQL Server 2025 Express Edition [SQL Server 2025 Express Edition](https://learn.microsoft.com/es-es/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver17#install-localdb)

## Instalar extensiones en VS Code

Abre la vista de extensiones (ctrl+shift+x).

Instalar en VS Code las extensiones para desarrollo:
- C#
- C# Namespace autocompletion
- C# Dev Kit
- .NET Install Tool
- .Net Maui
- Microsoft.AspNetCore.Razor.VSCode.BlazorWasmDebuggingExtension
- MSSQL
- Open in Browser
- PlantUML

Instalar para testing las siguientes extensiones:
- .Net Core Test Explorer
- Coverage Gutters 

Instalar las siguientes extensiones en VS Code para Git:
- GitHub Pull Requests: para control de versiones
- Git Graph: Git Graph del repositorio
- Git History: ver el log e historia de los archivos.

Alternativamente puedes **instalar todas las extensiones** de la siguiente forma:
1. abre una terminal
2. cambia a la raiz de la solución donde está el archivo **extensions4VSCode.txt**
3. ejecuta el siguiente comando:

```bash
Get-Content extensions.txt | ForEach-Object { code --install-extension $_ }
```

## Para aquellos equipos que vayan a desarrollar su proyecto con MAUI para la asignatura de IPO:
Seguir las instrucciones que se indican en el siguiente enlace [MAUI](https://learn.microsoft.com/es-es/dotnet/maui/get-started/installation?view=net-maui-10.0&tabs=visual-studio-code#connect-your-account-to-c-dev-kit)
Ya se proporciona un proyecto para desarrollo AppForSEII.MAUI por lo que no es necesario su creación.



# Preparar el proyecto para iniciar el desarrollo

## Crea el repositorio:
Clona la plantilla del proyecto

## Instala las herramientas para Entity Framework en el proyecto ejecutando en el terminal el siguiente comando (View\Terminal):

```bash
dotnet tool install --global dotnet-ef
```

## Instala las herramientas de desarrollo, abriendo un terminal en VS code (View\Terminal):
```bash
dotnet tool install --global NSwag.ConsoleCore

```
## Instala ReportGenerator como herramienta .NET:

```bash
dotnet tool install --global dotnet-reportgenerator-globaltool
```


## Instala las herramientas para generación de modelos UML a partir de código en tu proyecto:

```bash
dotnet tool install --global PlantUmlClassDiagramGenerator
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

En el terminal integrado de VS Code, sitúate en la carpeta APPForSEII.API que contiene el .csproj donde están las clases de modelo:

```bash
cd ruta/de/tu/proyecto/APPForSEII.API 
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
- Eliminar todas las migraciones de la BD

```bash
dotnet ef database update 0
```

- Borrar la BD

```bash
dotnet ef database drop
```

## Generar diagramas desde código

Al ejecutar el siguiente comando desde la carpeta de la solución:

```bash
puml-gen ./src/AppForSEII.API/Models  ./src/AppForSEII.API/ClassDiagram -dir -excludePaths **/bin,**/obj,**/Migrations  -createAssociation  -allInOne
```

cuyas opciones son:

- dir procesa directorios de entrada/salida.
- excludePaths evita ruido de bin/ y obj/.
- createAssociation detecta asociaciones desde campos/props.
- allInOne crea un include.puml para agrupar todo. [github.com], [deepwiki.com]

Se generan .puml (y un include.puml si usas -allInOne) que puedes abrir y previsualizar en VS Code con la extensión PlantUML. La extensión recomienda el render por servidor (evita instalar Java/Graphviz), y soporta exportación a PNG/SVG. [marketplac...studio.com]

Para ver el diagrama, abrir include.puml y pulsar Alt+d

## Generación de API Client

Para generar el Cliente de la API en el proyecto web, realiza los siguientes pasos.
1. Abre un terminal y ejecuta la api
2. Copia la ruta al fichero swagger.json
3. Abre otro terminal y cambia al directorio donde este el proyecto web. Ejecuta el comando nswag reemplazando la ruta http que aparece a continuación por la ruta de tu fichero swagger:

```bash
cd src
cd AppForSEII.Web

nswag openapi2csclient /input:http://localhost:5180/swagger/v1/swagger.json /classname:AppForSEIIAPIClient /namespace:AppForSEII.Web.API /output:AppForSEIIAPIClient.cs

```


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