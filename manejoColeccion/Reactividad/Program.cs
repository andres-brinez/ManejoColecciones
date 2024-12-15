using Reactividad;
using System.ComponentModel;
using System.Reactive.Linq;


// Actividad
// Hacer algo con todos los metodos que tienen los observables
// Mirar que hace cada metodo y hacer algo con ese metodo
// Entender que hace cada método y hacer algo con ese metodo
// Manipulación de los observables 
// Un ejemplo de cada metodo que tienen los observables

// Crea un Observable de números
IObservable<int> numeros = Observable.Range(1, 10);

numeros.
    Subscribe(number => Console.WriteLine(number));
Console.WriteLine("");


// Cuantificadores

numeros
    .Any(number => number == 5) //  Verifica si al menos un valor emitido por un Observable satisface una condición  definida, (true o false)
    .Subscribe(Console.WriteLine);

Console.WriteLine("");

numeros
    .All(numero => numero % 2 == 0)  // Verificar si todos los valores emitidos por un Observable satisfacen una condición específica, (true o false)
    .Subscribe(numero => Console.WriteLine($"¿Números par?: {numero}"));

Console.WriteLine("");

numeros.
    Contains(9) // Verifica si contiene el valor
    .Subscribe (Console.WriteLine);
Console.WriteLine("");

numeros
    .Append(100)
    .Subscribe(Console.WriteLine);
Console.WriteLine("");

// Delay se utiliza para introducir un retraso de tiempo entre la emisión de valores de un observable. Básicamente, retrasa la emisión de cada valor por un periodo de tiempo específico.
var numerosRetrasados= numeros.Delay(TimeSpan.FromSeconds(1));
numerosRetrasados.Subscribe(valor => Console.WriteLine($"Valor retrasado: {valor}"));


// Partición
numeros
    .Skip(2) // Omite un número específico de elementos desde el inicio del observable.
    .Subscribe(number => Console.WriteLine(number));
Console.WriteLine("");


numeros.Skip(TimeSpan.FromSeconds(3)) // Omite los valores emitidos durante el TimeSpan especificado desde el inicio de la secuencia observable.
    .Subscribe(valor => Console.WriteLine(valor));
Console.WriteLine("");

// Limita el número de elementos emitidos por el observable a una cantidad específica.
numeros.Take(5) // Toma solo los primeros 5 elementos
    .Subscribe(numeroLimitado => Console.WriteLine(numeroLimitado));
Console.WriteLine("");

// Emite elementos del observable hasta que la condición especificada deje de ser verdadera.
numeros.TakeWhile(numero => numero <= 5) // (Tomar mientras):
    .Subscribe(numero => Console.WriteLine(numero));

// Omite elementos del observable hasta que la condición especificada deje de ser verdadera.
numeros
    .SkipWhile(numbers => numbers < 5) // (Saltar mientras)
    .Subscribe(Console.WriteLine);
Console.WriteLine("");



// Conversión

var clientes = new List<Cliente> { new Cliente(1, "Andres"), new Cliente(2, "Pedro") }.ToObservable();


// Convierte un observable completo en una estructura de datos de tipo array
numeros.ToArray().Subscribe(array =>
{
    Console.WriteLine("Elementos del array:");

    foreach (var item in array)
    {
        Console.WriteLine(item);

    }
});
Console.WriteLine("");

numeros.ToList()
    .Subscribe(listaNumeros =>
    {
        Console.WriteLine("Elementos de la lista:");
        foreach (var numero in listaNumeros)
        {
            Console.WriteLine(numero);
        }
    });
Console.WriteLine("");

// Convierte un observable en un objeto Dictionary<TKey, TValue>, donde cada elemento del observable se agrega como un par clave-valor al diccionario.
clientes.ToDictionary(cliente => cliente.Id, cliente => cliente.name)
    .Subscribe(diccionarioClientes =>
    {
        foreach (var parClaveValor in diccionarioClientes)
        {
            Console.WriteLine($"Clave: {parClaveValor.Key}, Valor: {parClaveValor.Value}");
        }
    });
Console.WriteLine("");

// Convierte un observable en un objeto Lookup<TKey, TElement>, que agrupa elementos emitidos por el observable según una clave común.

var products = new List<Product> { new Product("Electronica", "Celular 1",100), new Product("Electronica", "Celular 2",200), new Product("Electronica", "Computador",300), new Product("Electrodomésticos", "Refrigerador ",400)}.ToObservable();

products
    .ToLookup(producto => producto.Category)
    .Subscribe(lookupProductos =>
    {
        Console.WriteLine("Productos de Electrónica:");
        foreach (var producto in lookupProductos["Electronica"])
        {
            Console.WriteLine(producto.Name);
        }
    });
Console.WriteLine("");


// Agregación

numeros.
    Sum()
    .Subscribe(total => Console.WriteLine($"Suma total de los números del 1 al 10 es : {total}"));
Console.WriteLine("");

numeros.
    Count()
    .Subscribe(count => Console.WriteLine($"La cantidad de números del 1 al 10 es : {count}"));
Console.WriteLine("");

var precioPromedio = products.
    Select(product => product.Price)
    .Average();

precioPromedio.Subscribe(promedio => Console.WriteLine($"Precio promedio de productos: {promedio}"));
Console.WriteLine("");



//// Filtrado de flujos de datos:

var numbers = new List<int> { 1, 2, 3, 4, 1 }.ToObservable();

//Distinct: Elimina los valores duplicados del observable, emitiendo solo valores únicos.
numbers
    .Distinct()
    .Subscribe(numeronoRepetidos => Console.WriteLine(numeronoRepetidos));
Console.WriteLine("");

//ElementAt: Emite un valor específico en el índice especificado del observable.
numbers
    .ElementAt(4) // Emite el quinto elemento (índice 4)
    .Subscribe(numeroEspecifico => Console.WriteLine(numeroEspecifico));
Console.WriteLine("");

// FirstOrDefault: Emite el primer valor que cumple la condición especificada, o el valor predeterminado si no se encuentra ninguno.
Console.WriteLine(numbers.FirstOrDefault(numero => numero % 2 == 0));
Console.WriteLine("");

numeros
    .Where(number => number % 2 == 0) // Operador de filtrado  que selecciona y pasa solo aquellos valores de un Observable que cumplen con una condición específica.
    .Subscribe(Console.WriteLine);
Console.WriteLine("");



// Proyeccion

// Select	Transforma cada elemento del observable a un nuevo tipo de dato.
var numerosAlCuadrado = numeros.Select(numero => numero * numero);
numerosAlCuadrado.Subscribe(number => Console.WriteLine($"Cuadrado: {number}"));
Console.WriteLine("");

//SelectMany:  Aplana o concatena los resultados emitidos por una función selectora aplicada a cada elemento de un observable. 
products
    .SelectMany(product => product.Month)
    .Subscribe(month => Console.WriteLine($"Mes: {month}"));
Console.WriteLine("");

numeros
    .Zip(numerosAlCuadrado)
    .Subscribe( resultado =>Console.WriteLine(resultado));
Console.WriteLine("");


// Agrupacion

// Agrupa los elementos de un observable en base a una clave obtenida de cada elemento utilizando una función selectora. Emite un observable para cada product, donde cada product contiene los elementos que comparten la misma clave.

var productByCategory = products.GroupBy(product => product.Category);

productByCategory.Subscribe(product =>
{
    Console.WriteLine($"Category: {product.Key}"); 

    product.Subscribe(producto => Console.WriteLine($"  Producto: {producto.Name}")); 
});
Console.WriteLine("");


IList<Student> students = new List<Student>() {
    new (1,"John",1),new (2,"John",1), new(3,"John",2),new (4,"John",2), new (5,"John",1),
};

var studentObservable = students.ToObservable();


IList<Standard> standards = (IList<Standard>)new List<Standard>() {
    new (1,"Standard 1"),new (2,"Standard 2"), new (3,"Standard 3")
}.ToObservable();

// Join: Combina elementos emitidos por dos observables basados en una condición temporal definida por el usuario.
var innerJoin = students.Join(
                      standards,
                      student => student.StandardID,
                      standard => standard.StandardID,
                      (student, standard) =>
                        new { Student = student.StudentName, Standard = standard.StandardName }
                      )
                      .ToList();

innerJoin.ForEach(resultado =>  // Recorre cada resultado
{
    Console.WriteLine($"Estudiante: {resultado.Student}");
    Console.WriteLine($"Nivel: {resultado.Standard}");
    Console.WriteLine("--------------------");
});


// group join, toma dos observables como entrada y combina elementos de uno con grupos del otro basándose en una clave común.
var groupJoin = students.GroupJoin(
    standards,
    student => student.StandardID,
    standard => standard.StandardID,
    (student, standards) =>
        new
        {
            Student = student.StudentName,
            Standard = standards.FirstOrDefault().StandardName ?? "No Standard Found"
        }
);




//  Combina dos o más observables en un solo observable, emitiendo elementos de cada observable en secuencia. 
IObservable<int> datosCombinados= numeros.Concat(numbers);
datosCombinados
    .Subscribe(Console.WriteLine);
Console.WriteLine("");


// Obtiene el primer valor emitido por el observable
int firstValue = datosCombinados.First();

// Obtiene el último valor emitido por el observable combinado
int lastValue = datosCombinados.Last();

Console.WriteLine($"Primer valor: {firstValue}");
Console.WriteLine($"Último valor: {lastValue}");
Console.WriteLine("");


// Emite el elemento en la posición especificada del observable o el valor predeterminado si no existe. Es útil para acceder a un elemento específico dentro de un flujo de datos.
numeros.
    ElementAtOrDefault(5)
    .Subscribe(number => Console.WriteLine($"El número en la 5° posición es {number}"));
Console.WriteLine("");


numeros.
    ElementAtOrDefault(100)
    .Subscribe(number => Console.WriteLine($"El elemento en la 100° posición es {number}"));
Console.WriteLine("");


// Combinación de flujos de datos:

var observableA = Observable.Range(1, 5);
var observableB = Observable.Range(6, 5);

observableA.Subscribe(Console.WriteLine);
observableB.Subscribe(Console.WriteLine);
Console.WriteLine("");

// CombineLatest: Combina múltiples observables, emitiendo el último valor de cada observable siempre que todos tengan nuevos valores.
observableA.CombineLatest(observableB, (valorA, valorB) => $"A: {valorA}, B: {valorB}")
   .Subscribe(combinacion => Console.WriteLine(combinacion));
Console.WriteLine("");

//Merge: Combina múltiples observables en un solo flujo, emitiendo valores de cualquier observable tan pronto como estén disponibles.
observableA.Merge(observableB)
    .Subscribe(valorCombinado => Console.WriteLine(valorCombinado));
Console.WriteLine("");


// 37



