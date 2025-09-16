# Tests para Million API

Este proyecto contiene una suite completa de tests para la aplicación Million API.

## Estructura de Tests

### 1. Tests de Dominio (`Domain/`)
- **PropertyTests.cs**: Tests para la entidad Property del dominio
- Valida la creación y propiedades de la entidad Property

### 2. Tests de Aplicación (`Application/`)
- **PropertyDtoTests.cs**: Tests para los DTOs de la capa de aplicación
- Valida la creación y propiedades del PropertyDto

### 3. Tests de Infraestructura (`Infrastructure/`)
- **MongoDbContextTests.cs**: Tests para el contexto de base de datos MongoDB
- Valida la configuración y conexión a MongoDB

### 4. Tests de Controladores (`Controllers/`)
- **PropertiesControllerTests.cs**: Tests unitarios para el controlador de propiedades
- Valida todos los endpoints y casos de uso del controlador

### 5. Tests de Integración (`Integration/`)
- **PropertiesIntegrationTests.cs**: Tests de integración para la API completa
- Valida el comportamiento end-to-end de la aplicación

## Dependencias de Testing

- **NUnit**: Framework de testing principal
- **FluentAssertions**: Librería para assertions más legibles
- **Moq**: Framework para mocking
- **Microsoft.AspNetCore.Mvc.Testing**: Para tests de integración
- **MongoDB.Driver**: Para tests de infraestructura

## Configuración

El archivo `appsettings.Test.json` contiene la configuración específica para los tests:
- Conexión a MongoDB local
- Base de datos de test separada

## Ejecutar Tests

### Desde la línea de comandos:
```bash
# Ejecutar todos los tests
dotnet test

# Ejecutar tests con cobertura
dotnet test --collect:"XPlat Code Coverage"

# Ejecutar tests específicos
dotnet test --filter "TestCategory=Unit"
dotnet test --filter "TestCategory=Integration"
```

### Desde Visual Studio:
1. Abrir el Test Explorer
2. Ejecutar todos los tests o tests específicos
3. Ver los resultados y cobertura

## Cobertura de Tests

Los tests cubren:
- ✅ Creación y validación de entidades
- ✅ Validación de DTOs
- ✅ Configuración de base de datos
- ✅ Endpoints del controlador
- ✅ Casos de error y edge cases
- ✅ Tests de integración end-to-end

## Datos de Test

El archivo `TestSetup.cs` contiene:
- Configuración de test
- Datos de ejemplo para propiedades
- Métodos auxiliares para setup de tests

## Notas Importantes

1. Los tests de integración requieren que MongoDB esté ejecutándose localmente
2. Se usa una base de datos separada para tests (`MillionTestDb`)
3. Los tests son independientes y pueden ejecutarse en paralelo
4. Se incluyen tests para casos de error y validaciones de entrada
