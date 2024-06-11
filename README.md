# SimuladorDeHonguitos

Este proyecto es un simulador de honguitos que permite configurar diferentes comportamientos para el nacimiento, lanzamiento de esporas y muerte de los honguitos. La configuración es flexible y permite extender fácilmente el simulador agregando nuevas clases que implementen las interfaces correspondientes.

## Estructura del Proyecto

- **SimuladorDeHonguitos.Comportamientos**: Contiene las interfaces y clases que definen los comportamientos de nacimiento, lanzamiento de esporas y muerte.
- **SimuladorDeHonguitos.Fabricas**: Contiene las fábricas que crean honguitos con los comportamientos configurados.
- **SimuladorDeHonguitos.Honguitos**: Contiene la clase `Honguito` que utiliza los comportamientos configurados.
- **SimuladorDeHonguitos.Simulador**: Contiene la lógica principal del simulador.

## Clases y Interfaces Principales

### Interfaces

- `INacerBehavior`: Define el comportamiento para el nacimiento de un honguito.
- `ILanzarEsporasBehavior`: Define el comportamiento para el lanzamiento de esporas de un honguito.
- `IMorirBehavior`: Define el comportamiento para la muerte de un honguito.

### Clases de Comportamiento

- `Nacer`: Implementa el comportamiento clásico de nacimiento.
- `NacerEstocastico`: Implementa el comportamiento estocástico de nacimiento.
- `LanzarEsporasClasico`: Implementa el comportamiento clásico de lanzamiento de esporas.
- `LanzarEsporasEstocastico`: Implementa el comportamiento estocástico de lanzamiento de esporas.
- `MorirClasico`: Implementa el comportamiento clásico de muerte.
- `MorirEstocastico`: Implementa el comportamiento estocástico de muerte.

### Fábrica de Honguitos

- `FabricaDeHonguitos`: Crea honguitos con los comportamientos configurados.

### Honguito

- `Honguito`: Clase que representa un honguito y utiliza los comportamientos configurados.

## Uso

1. Clona el repositorio:
```
git clone https://github.com/VicentePareja/Honguitos.git
```
2. Navega al directorio del proyecto:
```
cd Honguitos
```

3. Configura el comportamiento deseado en el `Program.cs`:
```csharp
using System.Drawing;
using SimuladorDeHonguitos.Comportamientos;
using SimuladorDeHonguitos.Fabricas;
using SimuladorDeHonguitos.Honguitos;

class Program
{
    static void Main()
    {
        // Ejemplo de configuración de la simulación
        var nacerBehavior = new Nacer();
        var lanzarEsporasBehavior = new LanzarEsporasEstocastico();
        var morirBehavior = new MorirEstocastico();

        var fabrica = new FabricaDeHonguitos(nacerBehavior, lanzarEsporasBehavior, morirBehavior);
     
        Point posicion = new Point(5, 5);
        Honguito honguito = fabrica.Crear(posicion);

        // Resto del código de la simulación
    }
}
```
4. Compila y ejecuta el proyecto.
Extensión
Para agregar nuevos comportamientos, simplemente crea una nueva clase que implemente una de las interfaces (INacerBehavior, ILanzarEsporasBehavior, IMorirBehavior) y configúralo en Program.cs.

Contribuciones
Las contribuciones son bienvenidas. Por favor, abre un issue o envía un pull request con mejoras y nuevas características.

