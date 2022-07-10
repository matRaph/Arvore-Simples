using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreSimples
{
    public class ArvoreSimples
    {
        public class No 
        {
            public object element { get; set; }
            public No pai { get; set; }
            public ArrayList? filhos { get; set; }

            public No(No pai, object element)
            {
                this.pai = pai;
                this.element = element;
                this.filhos = new();
            }
            public void addChild(No o)
            {
                this.filhos.Add(o);
            }

            public void removeChild(No o)
            {
                this.filhos.Remove(o);
            }

            public int childrenNumber()
            {
                return this.filhos.Count;
            }

            public IEnumerator children()
            {
                return this.filhos.GetEnumerator();
            }
        }

        // Atributos da árvore
        public No raiz { get; }
        public int tamanho { get; set; }

        // Construtor
        public ArvoreSimples(Object o)
        {
            this.raiz = new No(null, o);
            this.tamanho = 1;
        }

        //Métodos genéricos

        //Retorna o número de nós da árvore
        public int size()
        {
            return this.tamanho;
        }
        //Retorna a altura da árvore
        public int height()
        {
            return noHeight(this.raiz);
        }
        private int noHeight(No v)
        {
            if (isExternal(v))
            {
                return 0;
            }
            else
            {
                int h = 0;

                IEnumerator noChild = v.children();

                while (noChild.MoveNext())
                {
                    h = Math.Max(h, noHeight((No)noChild.Current));
                }
                return h+1;
            }
        }
        //Retorna se a árvore está vazia
        public bool isEmpty()
        {
            return false;
        }
        //Retorna um iterator com os elementos armazenados na árvore
        public IEnumerator elements()
        {
            IEnumerator nos = Nos();
            ArrayList list = new ArrayList();

            while (nos.MoveNext())
            {
                ArvoreSimples.No no = new ArvoreSimples.No(null, null);
                no = (ArvoreSimples.No)nos.Current;
                list.Add(no.element);
            }
            return list.GetEnumerator();
        }
        //Retorna um iterator com as posições (Nos) da árvore
        public IEnumerator Nos()
        {
            ArrayList nos = new();
            return preOrder(this.raiz, nos);
        }
        private IEnumerator preOrder(No v, ArrayList lista)
        {
            lista.Add(v);
            IEnumerator filhos = v.children();
            while (filhos.MoveNext())
            {
                preOrder((No)filhos.Current, lista);
            }
            return lista.GetEnumerator();
        }

        //Métodos de acesso

        //Retorna a raíz da árvore
        public No root()
        {
            return this.raiz;
        }
        //Retorna o nó pai de um nó
        public No parent(No v)
        {
            return v.pai;
        }
        //Retorna os filhos de um nó
        public IEnumerator children(No v)
        {
            return v.children();
        }

        //Métodos de consulta
        
        //Testa se um nó é interno
        public bool isInternal(No v)
        {
            return (v.childrenNumber() > 0);
        }
        //Testa se um nó é externo
        public bool isExternal(No v)
        {
            return (v.childrenNumber() == 0);
        }
        //Testa se um nó é a raíz
        public bool isRoot(No v)
        {
            return (v == this.raiz);
        }
        //Retorna a profundidade de um nó
        public int depth(No v)
        {
            int profundidade = this.profundidade(v);
            return profundidade;
        }
        private int profundidade(No v)
        {
            if (v == this.raiz)
            {
                return 0;
            }
            else
            {
                return (1 + this.profundidade(v.pai));
            }

        }

        //Métodos de atualização
        
        //Altera o objeto armazenado em um nó
        public object replace(No v, Object o)
        {
            v.element = o;
            return o;
        }
        //Adiciona um filho ao nó
        public void addChild(No v, Object o)
        {
            No novo = new No(v, o);
            v.addChild(novo);
            this.tamanho++;
        }
        /*Remove um nó
         Só pode remover nós externos e que tenham um pai (não seja raiz)*/
        public Object remove(No v)
        {
            No pai = v.pai;
            if (((pai != null) || this.isExternal(v)))
            {
                pai.removeChild(v);
            }
            else
            {
                throw new SystemException();
            }

            Object o = v.element;
            this.tamanho--;
            return o;
        }
        //Troca dois elementos de posição
        public void swapElements(No v, No w)
        {
            object backup = v.element;
            v.element = w;
            v.element = backup;
        }
    }
}
