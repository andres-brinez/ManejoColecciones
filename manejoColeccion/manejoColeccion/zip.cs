
using manejoColeccion;

class zip
{
    static void Main()
    {


        List<int> quantiy1 = new List<int> { 1, 2, 3, 4 };
        List<int> quantity2 = new List<int> { 5, 6, 7, 8 };

        // Combina los elementos de quantiy1 y quantity2 


        Console.WriteLine("");

        Console.WriteLine("Result Zip");

        Console.WriteLine("");

        // Esta línea utiliza Zip sin una función lambda, lo que crea una secuencia de tuplas combinando los elementos correspondientes de quantiy1 y quantity2. La operación ToArray() convierte esta secuencia de tuplas en un arreglo de tuplas.
        var result = quantiy1.Zip(quantity2).ToList();
        
        Console.WriteLine(string.Join(", ", result));
        Console.WriteLine(result[0]);

        Console.WriteLine("");


        //Puedes utilizar esta secuencia de tuplas para realizar operaciones adicionales, como acceder a cada par de elementos o realizar transformaciones más complejas utilizando funciones lambda en combinación con Zip.

        // En esta línea, se utiliza Zip con una función lambda (num1, num2) => num1 + num2, que suma los elementos correspondientes de quantiy1 y quantity2. El resultado se convierte en un arreglo de números que representan la suma por posición de los elementos de las listas.



        Console.WriteLine("Resultado expresión lambda");
        Console.WriteLine("");

        var suma = quantiy1.Zip(quantity2, (num1, num2) => num1 + num2).ToArray();

        Console.WriteLine(string.Join(", ", suma));
        Console.WriteLine("");

        var resultado = quantiy1.Zip(quantity2, (num1, num2) => num1 + num2).Select(sum=>sum*2);


        Console.WriteLine("Resultado encadenar otra operación ");
        Console.WriteLine("");

        Console.WriteLine(string.Join(", ", resultado));
        Console.WriteLine("");

        resultado = quantiy1.Select(sum => sum * 2);
        Console.WriteLine(string.Join(", ", resultado));
        Console.WriteLine("");



        List<int> numeros = new List<int> { 1, 2, 3, 7, 5 };

        bool hasEven = numeros.Any(num => num % 2 == 0);

        Console.WriteLine("¿Hay un número par en la lista?");
        Console.WriteLine(hasEven);
        Console.WriteLine("");

        List<Persona> personas = new List<Persona>
        {
            new Persona { Nombre = "Juan", Edad = 25 },
            new Persona { Nombre = "María", Edad = 30 },
            new Persona { Nombre = "Pedro", Edad = 16 }
        };

        bool tienePersonaMayorDeEdad = personas.Any(p => p.Edad > 18);


        List<int> numbers = new List<int> { 2, 2, 4, 8, 24 };
        bool allAreEven = numbers.All(num => num % 2 == 0);

        Console.WriteLine("¿Todos los números son  pares en la lista?");
        Console.WriteLine(allAreEven);
        Console.WriteLine("");




        Console.WriteLine("Select ");
        resultado = quantiy1.Select(sum => sum * 2);
        Console.WriteLine(string.Join(", ", resultado));
        Console.WriteLine("");


        Console.WriteLine("Agregate ");
        // se utiliza para aplicar una función específica a todos los elementos de una secuencia, de manera que acumula el resultado de forma iterativa. En cada iteración, el resultado acumulado se combina con el siguiente elemento de la secuencia utilizando la función especificada, hasta que se procesan todos los elementos. Este método es útil para realizar operaciones de reducción en una secuencia, como sumas, productos, concatenaciones, entre otros.
        Console.WriteLine("");

        var suma2 = numbers.Aggregate((acumulado, actual) => acumulado + actual);
        Console.WriteLine("Resultado suma con Aggregate: {0}", suma2);
        Console.WriteLine("");

        Console.WriteLine("Intersect ");
        // se utiliza para obtener la intersección de dos secuencias, es decir, devuelve los elementos que están presentes en ambas secuencias. Esto significa que el resultado será una nueva secuencia que contiene solo los elementos que se encuentran en ambas secuencias originales.
        Console.WriteLine("");

        int[] numeros1 = { 1, 2, 3, 4, 5 };
        int[] numeros2 = { 3, 4, 5, 6, 7 };

        var interseccion = numeros1.Intersect(numeros2);

        Console.WriteLine("Resultado Intersect");

        foreach (var numero in interseccion)
        {
            Console.WriteLine(numero); // Esto imprimirá 3, 4, 5
        }


        Console.WriteLine("ToDictionary ");
        // Se utiliza para convertir una secuencia en un diccionario, donde cada elemento de la secuencia se convierte en un par clave-valor dentro del diccionario resultante. Este método es útil cuando se necesita transformar una secuencia en un diccionario basado en ciertos criterios o propiedades de los elementos de la secuencia.
        Console.WriteLine("");

        Dictionary<string,int> diccionarioPersonas = personas.ToDictionary(p => p.Nombre, p => p.Edad);


        Console.WriteLine("Resultado Dictionary");

        foreach (var kvp in diccionarioPersonas)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }


        Console.WriteLine("Except ");
        // se utiliza para obtener los elementos que están presentes en la primera secuencia pero no en la segunda. En otras palabras, devuelve una secuencia que contiene los elementos de la primera secuencia que no están presentes en la segunda secuencia.
        Console.WriteLine("");

       
        var diferencia = numeros1.Except(numeros2);


        Console.WriteLine("Resultado Except");

        foreach (var numero in diferencia)
        {
            Console.WriteLine(numero); 
        }

        Console.WriteLine("Skip ");
        // toma un parámetro entero que representa la cantidad de elementos que se deben omitir al principio de la secuencia.
        Console.WriteLine("");

        var numerosDespuesDeSkip = numeros.Skip(2);

        Console.WriteLine("Elementos después de Skip:");
        foreach (var numero in numerosDespuesDeSkip)
        {
            Console.WriteLine(numero); 
        }


        Console.WriteLine("SkipWhile ");
        //toma un predicado como argumento y omite elementos al principio de la secuencia mientras el predicado sea verdadero. Una vez que el predicado devuelve falso por primera vez, los elementos restantes se incluyen en la secuencia resultante.

        Console.WriteLine("");


        List<int> numero21 = new List<int> { 1, 2, 3, 2, 5 };

        var numerosDespuesDeSkipWhile = numero21.SkipWhile(n => n < 3);

        Console.WriteLine("\nElementos después de SkipWhile:");
        foreach (var numero in numerosDespuesDeSkipWhile)
        {
            Console.WriteLine(numero);
        }

        Console.WriteLine("TakeWhile ");
        // se utiliza para tomar elementos de una secuencia mientras se cumpla una condición específica. Toma como argumento un predicado que define la condición a cumplir. La operación termina tan pronto como el predicado devuelve falso por primera vez, y los elementos que cumplen la condición hasta ese punto son incluidos en la secuencia resultante.

        Console.WriteLine("");


        List<int> numero20 = [ 1, 5, 3, 4, 5, 6, 7, 8 ];

        var numerosTomados = numeros.TakeWhile(n => n < 5);

        foreach (var numero in numerosTomados)
        {
            Console.WriteLine(numero); // Esto imprimirá 1, 2, 3, 4
        }




        // where,Filtra los elementos de una secuencia basándose en un predicado especificado.
        // select,Transforma cada elemento de una colección en un nuevo formato o tipo de dato,
        // orderBy,Ordena los elementos de una secuencia en orden ascendente según una clave especificada.

        // La interfaz IEnumerable en C# proporciona una forma de iterar a través de una colección de elementos. Permite recorrer los elementos de la colección utilizando un bucle foreach u otras operaciones que requieran iteración, como LINQ

    }


}
