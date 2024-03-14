# Documentación de Pruebas - JokeAndMathsControllerTests

## Descripción

Esta clase contiene pruebas unitarias para el controlador `JokeAndMathsController`. Las pruebas verifican el comportamiento de los métodos `GetAJoke` del controlador bajo diferentes condiciones.

### Métodos de Prueba

- **GetAJoke_ReturnsOkWithJokeDto_WhenParamIsNull**: Prueba que el método `GetAJoke` del controlador devuelve un resultado exitoso (`OkObjectResult`) con un DTO de broma (`JokeDto`) cuando el parámetro es nulo.

- **GetAJoke_ReturnsOkWithJokeDtoFromChuck_WhenParamIsChuck**: Prueba que el método `GetAJoke` devuelve un resultado exitoso con un DTO de broma específico de Chuck Norris cuando se proporciona el parámetro "Chuck".

- **GetAJoke_ReturnsOkWithJokeDtoFromDad_WhenParamIsDad**: Prueba que el método `GetAJoke` devuelve un resultado exitoso con un DTO de broma específico de papá cuando se proporciona el parámetro "Dad".

- **GetAJoke_ReturnsKeyNotFoundException_WhenParamIsInvalid**: Prueba que el método `GetAJoke` arroja una excepción `KeyNotFoundException` cuando se proporciona un parámetro inválido y verifica el mensaje de excepción correspondiente.

### Tecnologías y Herramientas Utilizadas

- **xUnit**: Marco de pruebas unitarias para .NET utilizado para escribir y ejecutar pruebas.

- **Moq**: Biblioteca de .NET que se utiliza para crear objetos simulados (mocks) en pruebas unitarias.

- **MediatR**: Biblioteca que permite implementar el patrón Mediator para la comunicación entre objetos en aplicaciones .NET.

- **Microsoft.AspNetCore.Mvc**: Biblioteca utilizada para crear y manejar controladores en ASP.NET Core.

### Configuración de Prueba

- Se simulan instancias de `IMediator` utilizando Moq para simular la comunicación con los manejadores de solicitudes.

- Se utiliza `ServiceCollection` para configurar el contenedor de servicios y proporcionar instancias simuladas de los servicios necesarios.