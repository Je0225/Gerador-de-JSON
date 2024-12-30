using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Object = System.Object;
using String = System.String;

namespace GeradorDeJson {

  public class ObjectModel(String? nome, Tipo tipo): Model(nome, tipo) {

    private List<PropertyModel> Atributos { get; } = new();

    private List<ObjectModel> Objetos { get; } = new();

    private List<ObjectModel> Listas { get; } = new();

    public List<PropertyModel> RetornaAtributos() {
      return Atributos;
    }

    public List<ObjectModel> RetornaObjetos() {
      return Objetos;
    }

    public List<ObjectModel> RetornaListas() {
      return Listas;
    }

    public void AdicionaAtributo(String nome, Object? value) {
      Atributos.Add(new PropertyModel(nome, value, Tipo.Atributo));
    }

    public ObjectModel AdicionaObjeto(String? nome) {
      ObjectModel obj = new ObjectModel(nome, Tipo.Objeto);
      Objetos.Add(obj);
      return obj;
    }

    public ObjectModel AdicionaLista(String? nome, Object? value) {
      ObjectModel obj = new ObjectModel(nome, Tipo.Lista);
      Listas.Add(obj);
      return obj;
    }

    /*public String GeraTexto(String retorno){ 
      foreach (PropertyModel atributo in Atributos) {
        retorno += atributo.EscreveAtributo();
      }
      foreach (ObjectModel obj in Objetos) {
        retorno += EscreveObjeto();
        retorno += obj.GeraTexto(retorno);
      }
      return retorno;
    }*/

    public String EscreveObjeto() {
      if (Tipo != Tipo.Objeto) {
        return "";
      }
      String textoJson = $"\"{Nome}\": {{";
      List<PropertyModel> atributos = RetornaAtributos();
      List<ObjectModel> objetos = RetornaObjetos();

      foreach (PropertyModel atributo in atributos) {
        textoJson += atributo.EscreveAtributo();
        if (atributos.Last() != atributo) {
         textoJson += InsereVirgula(true, false);
        }
      }
      if (objetos.Count > 0) {
        textoJson += InsereVirgula(true, false);
      }
      foreach (ObjectModel objeto in objetos) {
        textoJson += objeto.EscreveObjeto();
        if (objetos.Last() != objeto) {
          textoJson += InsereVirgula(true, false);
        }
      }
      textoJson += "}";
      return textoJson;
    }

  }

}
