

using System.Collections.ObjectModel;
using System.Reactive.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Clase reactividad");


//new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 }.ForEach(Console.WriteLine);
// Proceso bloqueante
//Es un código que detiene la ejecución del hilo principal mientras se espera que se complete una operación.
//El hilo principal se queda inactivo hasta que la operación finalice, lo que puede afectar el rendimiento y la capacidad de respuesta de la aplicación.

// Proceso no bloqueante
//Permite que el hilo principal continúe su ejecución mientras se espera que se complete una operación.
//El hilo principal puede realizar otras tareas mientras la operación se ejecuta en segundo plano.
//Se utiliza comúnmente para operaciones asincrónicas, como la recuperación de datos de una red o la ejecución de tareas en segundo plano.


//los Observables son elementos fundamentales que representan flujos de datos que cambian con el tiempo.  Estos flujos de datos pueden ser cualquier tipo de información, como números, cadenas de texto, eventos del usuario o datos de sensores.

//Los Observables tienen dos responsabilidades principales:

//Emitir notificaciones de eventos: Los Observables emiten notificaciones a los observadores suscritos cada vez que se produce un cambio en el flujo de datos. Estas notificaciones pueden ser de diferentes tipos, como:

//OnNext: Indica que se ha emitido un nuevo valor en el flujo de datos.
//OnError: Indica que se ha producido un error en el flujo de datos.
//OnCompleted: Indica que el flujo de datos ha finalizado y no emitirá más valores.

//Administrar las suscripciones: Los Observables permiten a los observadores suscribirse al flujo de datos para recibir notificaciones de eventos. El Observable mantiene una lista de observadores suscritos y se asegura de enviarles las notificaciones correspondientes.

//Un Observable actúa como un vigilante de un flujo de datos. Está constantemente monitoreando el flujo y, cada vez que detecta un cambio (un nuevo valor, un error o la finalización del flujo), envía notificaciones a todos los observadores que se han suscrito a él.

//Imagina un Observable que representa la temperatura actual en una ciudad. Los observadores podrían ser aplicaciones que muestran la temperatura en una pantalla, alertas que se activan cuando la temperatura alcanza cierto umbral, o incluso un sistema de control que ajusta la calefacción o el aire acondicionado.

//Cada vez que la temperatura cambia, el Observable emite una notificación a todos los observadores suscritos. Esto permite que las aplicaciones y sistemas reaccionen de manera inmediata a los cambios en la temperatura, sin necesidad de sondear constantemente el flujo de datos.

// Se pueden tener diferentes procesos funcionando al mismo tiempo porque uno no bloquea al otro

Observable
    .Timer(DateTimeOffset.UtcNow, TimeSpan.FromSeconds(1))
    .Subscribe();

// Esta variable se utilizará para almacenar el Observable que se crea a continuación.
IObservable<long> tiempo = Observable.Timer(DateTimeOffset.UtcNow, TimeSpan.FromSeconds(1)); // Se crea un Observable utilizando el método Observable.Timer de Rx.NET

//tiempo.Subscribe(Console.WriteLine); // Finalmente, se llama al método Subscribe en el Observable. Esto hace que el Observable comience a emitir valores. 


//Los operadores LINQ son una herramienta poderosa para trabajar con flujos de datos en la programación reactiva, y se pueden combinar con Observables para realizar diversas transformaciones y análisis sobre los datos.

tiempo.Where(numero => numero % 2 == 0);
    //.Subscribe(numeroPar=>Console.WriteLine($"número par: {numeroPar}" ));


tiempo
    .Select(valor => "HH:mm:" + valor); // Transformar a formato de hora
    //.Subscribe((horaFormateada) => Console.WriteLine($"Hora actual formateada: {horaFormateada}"));



// Operadores

// con rx.net pasamos la lista a una secuencia de numeros

var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 }; // Crea un Observable que emitirá cada valor entero de la lista como una sola emisión.
//Por cada elemento en la lista emite una nueva emisión al observador.
// Tranforma la lista en un Observable
numbers.ToObservable() 
    .Subscribe(Console.WriteLine); // En este caso, el observador es una expresión lambda que recibe un argumento entero (numero).

numbers .ToObservable()
    .TakeWhile((number)=> number<5)
    .Subscribe(Console.WriteLine);



numbers.ToObservable()
    .Take(5)
    .Select((number)=> $"Los 5 primeros numeros de la lista son: {number}")
    .Subscribe((number) =>
    {
        Console.WriteLine(number);
    });





Console.ReadLine();


