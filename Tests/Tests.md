# Documentación de Pruebas - JokeAndMathsControllerTests

## Descripción

Esta clase contiene pruebas unitarias para el controlador `JokeAndMathsController`. Las pruebas verifican el comportamiento de los métodos `GetAJoke`, `CreateAJoke`, `UpdateAJoke`, y `DeleteAJoke` del controlador bajo diferentes condiciones.

### Métodos de Prueba

#### Métodos para `GetAJoke`

- **GetAJoke_ReturnsOkWithJokeDto_WhenParamIsNull**: Prueba que el método `GetAJoke` del controlador devuelve un resultado exitoso (`OkObjectResult`) con un DTO de broma (`JokeDto`) cuando el parámetro es nulo.
  
- **GetAJoke_ReturnsOkWithJokeDtoFromChuck_WhenParamIsChuck**: Prueba que el método `GetAJoke` devuelve un resultado exitoso con un DTO de broma específico de Chuck Norris cuando se proporciona el parámetro "Chuck".
  
- **GetAJoke_ReturnsOkWithJokeDtoFromDad_WhenParamIsDad**: Prueba que el método `GetAJoke` devuelve un resultado exitoso con un DTO de broma específico de papá cuando se proporciona el parámetro "Dad".
  
- **GetAJoke_ReturnsKeyNotFoundException_WhenParamIsInvalid**: Prueba que el método `GetAJoke` arroja una excepción `KeyNotFoundException` cuando se proporciona un parámetro inválido y verifica el mensaje de excepción correspondiente.

#### Métodos para `CreateAJoke`

- **CreateAJoke_ReturnsOkWithNewJokeId_WhenJokeIsValid**: Prueba que el método `CreateAJoke` devuelve un resultado exitoso (`OkObjectResult`) con el ID del nuevo chiste creado cuando el chiste proporcionado es válido.

#### Métodos para `UpdateAJoke`

- **UpdateAJoke_ReturnsOkWithUpdatedJokeId_WhenJokeIsValid**: Prueba que el método `UpdateAJoke` devuelve un resultado exitoso con el ID del chiste actualizado cuando el chiste proporcionado es válido.

#### Métodos para `DeleteAJoke`

- **DeleteAJoke_ReturnsOkWithDeletedJokeId_WhenJokeIsValid**: Prueba que el método `DeleteAJoke` devuelve un resultado exitoso con el ID del chiste eliminado cuando el chiste es válido para eliminación.

### Tecnologías y Herramientas Utilizadas

- **xUnit**: Marco de pruebas unitarias para .NET utilizado para escribir y ejecutar pruebas.

- **Moq**: Biblioteca de .NET que se utiliza para crear objetos simulados (mocks) en pruebas unitarias.

- **MediatR**: Biblioteca que permite implementar el patrón Mediator para la comunicación entre objetos en aplicaciones .NET.

- **Microsoft.AspNetCore.Mvc**: Biblioteca utilizada para crear y manejar controladores en ASP.NET Core.

### Configuración de Prueba

- Se simulan instancias de `IMediator` utilizando Moq para simular la comunicación con los manejadores de solicitudes.

- Se utiliza `ServiceCollection` para configurar el contenedor de servicios y proporcionar instancias simuladas de los servicios necesarios.

La documentación ahora incluye detalles sobre las pruebas de los métodos `CreateAJoke`, `UpdateAJoke`, y `DeleteAJoke`, completando la cobertura de las pruebas unitarias para el controlador `JokeAndMathsController`.

# Documentación de Pruebas - MathsControllerTests

## Descripción

Esta sección documenta las pruebas unitarias para el `MathsController`, enfocándose en la verificación del correcto funcionamiento de los métodos `GetLCM` e `IncrementNumber`. Las pruebas aseguran que los métodos manejen adecuadamente los casos de uso esperados, incluyendo entradas válidas e inválidas.

### Métodos de Prueba

#### Métodos para `GetLCM`

- **GetLCM_ReturnsBadRequest_WhenNoNumbersProvided**: Prueba que el método `GetLCM` devuelve un resultado de `BadRequest` cuando no se proporcionan números. Se espera que el mensaje de error sea "No numbers provided.".

- **GetLCM_ReturnsBadRequest_WhenInvalidNumberProvided**: Prueba que el método `GetLCM` devuelve un resultado de `BadRequest` cuando se proporciona un número inválido en la cadena de entrada. El mensaje de error esperado es "Invalid number: abc", indicando el valor inválido específico.

- **GetLCM_Returns_CorrectLCM**: Verifica que el método `GetLCM` calcule correctamente el mínimo común múltiplo (LCM) para una entrada válida de números. Se espera que el valor devuelto sea el LCM correcto, en este caso, `30` para la entrada "2,3,5".

#### Método para `IncrementNumber`

- **IncrementNumber_ReturnsIncrementedNumber**: Prueba que el método `IncrementNumber` incrementa correctamente el número proporcionado. Para una entrada de `5`, se espera que el resultado devuelto sea `6`.

### Tecnologías y Herramientas Utilizadas

- **xUnit**: Utilizado para escribir y ejecutar las pruebas unitarias.
- **Moq**: Facilita la creación de objetos simulados para las dependencias del controlador.
- **Microsoft.AspNetCore.Mvc**: Proporciona las clases y atributos necesarios para definir los controladores y sus respuestas.

### Configuración de Prueba

- Se utiliza `Mock<MathCalcs>` para simular el servicio de cálculos matemáticos, permitiendo probar el controlador en aislamiento de las implementaciones de servicio.
- La instancia de `MathsController` se crea pasando la instancia simulada del servicio de cálculos matemáticos.

Esta documentación detalla las pruebas realizadas sobre el `MathsController`, asegurando la calidad y correcto funcionamiento de sus métodos en diversos escenarios.