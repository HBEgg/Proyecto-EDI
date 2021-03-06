﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras
{
    
    public class ArbolAVL<T> 
    {
        
        public NodoAVL<T> Raiz { get; set; }
        public bool Vacio { get { return Raiz == null; } }
        int altura =0;
        public int nuevovalor = 0;
        public void Add(T item, NodoAVL<T> nodo, Comparison<T> comparison)
        {
            if (Raiz != null)
            {
                if (comparison.Invoke(item, nodo.Enfermo) < 0)
                {
                    if (nodo.Izquierdo != null)
                    {
                        Add(item, nodo.Izquierdo, comparison);
                    }
                    else
                    {
                        nodo.Izquierdo = new NodoAVL<T>(item);
                    }
                }
                else
                {
                    if (nodo.Derecho != null)
                    {
                        Add(item, nodo.Derecho, comparison);
                    }
                    else
                    {
                        nodo.Derecho = new NodoAVL<T>(item);
                    }
                }
                //else
                //{
                //    if (raiz.Derecho !=null)
                //    {
                //        this.Add(item, raiz.Derecho);
                //    }
                //    else
                //    {
                //        raiz.Derecho = new NodoAVL(item);
                //    }
                //}
            }
            else
            {
                Raiz = new NodoAVL<T>(item);
            }
        }

        public void CreaArbol(List<T> listaenfermos, Comparison<T> comparison)
        {
            foreach (var item in listaenfermos)
            {
                this.Add(item, Raiz, comparison); 
            }
        }

        public T Buscar(T persona, NodoAVL<T> nodo, Comparison<T> comparison)
        {
            if (Raiz != null)
            {
                if (comparison.Invoke(persona, nodo.Enfermo) < 0)
                {
                    if (nodo.Izquierdo != null)
                    {
                        return Buscar(persona, nodo.Izquierdo, comparison);
                    }
                    else
                    {
                        return default;
                    }
                }
                else if (comparison.Invoke(persona, nodo.Enfermo) > 0)
                {
                    if (nodo.Derecho != null)
                    {
                        return Buscar(persona, nodo.Derecho, comparison);
                    }
                    else
                    {
                        return default;
                    }
                }
                else
                {
                    return nodo.Enfermo;
                }
            }
            else
            {
                return default;
            }
        }

        //private int Buscar(string personas, NodoAVL nraiz)
        //{
        //    if (nraiz == null)
        //    {
        //        return -1;
        //    }
        //    else if (nraiz.enfermos.Nombre.Contains(personas))
        //    {
        //        return Raiz.indice;
        //    }
        //    else if (nraiz.SEHoja())
        //    {
        //        return -1; 
        //    }
        //    else
        //    {
        //        if (string.Compare(personas, nraiz.enfermos.Nombre)==1)
        //        {
        //            return Buscar(personas, nraiz.Derecho);
        //        }
        //        else
        //        {
        //            return Buscar(personas, nraiz.Izquierdo);
        //        }
        //    }

        //}
        //public int BuscarApellido(string Apersonas)
        //{
        //    if (Raiz != null)
        //    {
        //        if (Raiz.enfermos.Apellido.Contains(Apersonas))
        //        {
        //            return Raiz.indice;
        //        }
        //        else
        //        {
        //            int obtieneres = Buscar(Apersonas, new NodoAVL(Raiz.enfermos, Raiz.Izquierdo, Raiz.Derecho, null));
        //            return Buscar(Apersonas, Raiz);
        //        }
        //    }
        //    else
        //    {
        //        return -1;
        //    }
        //}
        //private int BuscarApellido(string personas, NodoAVL raiz)
        //{
        //    if (raiz == null)
        //    {
        //        return -1;
        //    }
        //    else if (raiz.enfermos.Apellido.Contains(personas))
        //    {
        //        return Raiz.indice;
        //    }
        //    else if (raiz.SEHoja())
        //    {
        //        return -1;
        //    }
        //    else
        //    {
        //        if (string.Compare(personas, raiz.enfermos.Apellido) == 1)
        //        {
        //            return BuscarApellido(personas, raiz.Derecho);
        //        }
        //        else
        //        {
        //            return BuscarApellido(personas, raiz.Izquierdo);
        //        }
        //    }
        //}

        //private int AlturaArbol(NodoAVL raiz)
        //{
        //    return raiz == null ? -1 : raiz.altura; 
        //}
        //private int ObtieneRamax(int ladoizq, int ladoder)
        //{
        //    return ladoizq > ladoder ? ladoizq : ladoder; //obtiene cual de los lados es el mayor de ellos 
        //}
        //private int RotaSimpleIzq(NodoAVL hijo1)
        //{
        //    NodoAVL hijo2 = hijo1.Derecho; //ver si las hojas tienen o no la misma altura 
        //    hijo1.Izquierdo = hijo2.Derecho;
        //    hijo2.Derecho = hijo1;
        //    hijo1.altura = ObtieneRamax(AlturaArbol(hijo1.Izquierdo), AlturaArbol(hijo2.Derecho)) + 1;
        //    hijo2.altura = ObtieneRamax(AlturaArbol(hijo2.Izquierdo), hijo1.altura) + 1;
        //    return hijo2.altura; //devuelve la que ahora sera la raiz de la rotacion haciendo los cambios respectivos
        //}
        //private int RotaSimpleDer(NodoAVL hijo2)
        //{
        //    NodoAVL hijo1 = hijo2.Izquierdo;
        //    hijo2.Derecho = hijo1.Izquierdo;
        //    hijo1.Izquierdo = hijo2;
        //    hijo2.altura = ObtieneRamax(AlturaArbol(hijo2.Derecho), AlturaArbol(hijo1.Derecho)) + 1;
        //    hijo1.altura = ObtieneRamax(AlturaArbol(hijo1.Derecho), hijo2.altura) + 1;
        //    return hijo1.altura;
        //}
        //public int Count => throw new NotImplementedException();

        //public bool IsReadOnly => throw new NotImplementedException();

        //public void Clear()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Contains(T item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void CopyTo(T[] array, int arrayIndex)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerator<T> GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Remove(T item)
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
