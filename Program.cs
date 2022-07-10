using System;
using System.Collections;

namespace ArvoreSimples
{
    class Program
    {
        public static void Main(string[] args)
        {
            ArvoreSimples simples = new ArvoreSimples(1);
            simples.addChild(simples.root(), 2);
            simples.addChild(simples.root(), 3);
            simples.addChild(simples.root(), 4);
            simples.addChild(simples.root(), 5);

            IEnumerator Filhos = simples.children(simples.root());

            while (Filhos.MoveNext())
            {
                ArvoreSimples.No x = (ArvoreSimples.No)(Filhos.Current);
                int z = (int)x.element;
                Console.WriteLine(">" + z);
            }

            Console.WriteLine("");
            Console.WriteLine(simples.root().element);

        }
    }
}
