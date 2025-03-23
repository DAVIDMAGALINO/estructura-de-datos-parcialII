using System;

class Nodo
{
    public int Dato;
    public Nodo Izquierdo, Derecho;

    public Nodo(int dato)
    {
        Dato = dato;
        Izquierdo = Derecho = null;
    }
}

class ArbolBinario
{
    private Nodo Raiz;

    public void Insertar(int dato)
    {
        Raiz = InsertarRecursivo(Raiz, dato);
    }

    private Nodo InsertarRecursivo(Nodo nodo, int dato)
    {
        if (nodo == null)
        {
            return new Nodo(dato);
        }

        if (dato < nodo.Dato)
        {
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, dato);
        }
        else if (dato > nodo.Dato)
        {
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, dato);
        }

        return nodo;
    }

    public void InOrden()
    {
        Console.WriteLine("Recorrido InOrden:");
        InOrdenRecursivo(Raiz);
        Console.WriteLine();
    }

    private void InOrdenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            InOrdenRecursivo(nodo.Izquierdo);
            Console.Write(nodo.Dato + " ");
            InOrdenRecursivo(nodo.Derecho);
        }
    }

    public void PreOrden()
    {
        Console.WriteLine("Recorrido PreOrden:");
        PreOrdenRecursivo(Raiz);
        Console.WriteLine();
    }

    private void PreOrdenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Dato + " ");
            PreOrdenRecursivo(nodo.Izquierdo);
            PreOrdenRecursivo(nodo.Derecho);
        }
    }

    public void PostOrden()
    {
        Console.WriteLine("Recorrido PostOrden:");
        PostOrdenRecursivo(Raiz);
        Console.WriteLine();
    }

    private void PostOrdenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            PostOrdenRecursivo(nodo.Izquierdo);
            PostOrdenRecursivo(nodo.Derecho);
            Console.Write(nodo.Dato + " ");
        }
    }

    public bool Buscar(int dato)
    {
        return BuscarRecursivo(Raiz, dato);
    }

    private bool BuscarRecursivo(Nodo nodo, int dato)
    {
        if (nodo == null)
        {
            return false;
        }

        if (dato == nodo.Dato)
        {
            return true;
        }

        return dato < nodo.Dato ? BuscarRecursivo(nodo.Izquierdo, dato) : BuscarRecursivo(nodo.Derecho, dato);
    }

    public void Eliminar(int dato)
    {
        Raiz = EliminarRecursivo(Raiz, dato);
    }

    private Nodo EliminarRecursivo(Nodo nodo, int dato)
    {
        if (nodo == null)
        {
            return nodo;
        }

        if (dato < nodo.Dato)
        {
            nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, dato);
        }
        else if (dato > nodo.Dato)
        {
            nodo.Derecho = EliminarRecursivo(nodo.Derecho, dato);
        }
        else
        {
            if (nodo.Izquierdo == null)
            {
                return nodo.Derecho;
            }
            if (nodo.Derecho == null)
            {
                return nodo.Izquierdo;
            }

            nodo.Dato = MinimoValor(nodo.Derecho);
            nodo.Derecho = EliminarRecursivo(nodo.Derecho, nodo.Dato);
        }

        return nodo;
    }

    private int MinimoValor(Nodo nodo)
    {
        int minValor = nodo.Dato;
        while (nodo.Izquierdo != null)
        {
            minValor = nodo.Izquierdo.Dato;
            nodo = nodo.Izquierdo;
        }
        return minValor;
    }
}

class Programa
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion;

        do
        {
            Console.WriteLine("\nMenú de Operaciones del Árbol Binario:");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Eliminar");
            Console.WriteLine("3. Recorrido InOrden");
            Console.WriteLine("4. Recorrido PreOrden");
            Console.WriteLine("5. Recorrido PostOrden");
            Console.WriteLine("6. Buscar");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el valor a insertar: ");
                    int datoInsertar = int.Parse(Console.ReadLine());
                    arbol.Insertar(datoInsertar);
                    break;

                case 2:
                    Console.Write("Ingrese el valor a eliminar: ");
                    int datoEliminar = int.Parse(Console.ReadLine());
                    arbol.Eliminar(datoEliminar);
                    break;

                case 3:
                    arbol.InOrden();
                    break;

                case 4:
                    arbol.PreOrden();
                    break;

                case 5:
                    arbol.PostOrden();
                    break;

                case 6:
                    Console.Write("Ingrese el valor a buscar: ");
                    int datoBuscar = int.Parse(Console.ReadLine());
                    bool encontrado = arbol.Buscar(datoBuscar);
                    Console.WriteLine(encontrado ? "El valor fue encontrado." : "El valor no existe en el árbol.");
                    break;

                case 7:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 7);
    }
}
