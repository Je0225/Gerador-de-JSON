using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Boolean = System.Boolean;
using Object = System.Object;
using String = System.String;

namespace GeradorDeJson {

  public class ObjectModel(String? nome, Tipo tipo): Model(nome, tipo) {

    private List<PropertyModel> Atributos { get; } = new();

    private List<ObjectModel> Objetos { get; } = new();

    private List<ListModel> Listas { get; } = new();
   
    public void AdicionaAtributo(String nome, Object? value) {
      Atributos.Add(new PropertyModel(nome, value, Tipo.Atributo));
    }

    public ObjectModel AdicionaObjeto(String? nome) {
      ObjectModel obj = new ObjectModel(nome, Tipo.Objeto);
      Objetos.Add(obj);
      return obj;
    }

    public ListModel AdicionaLista(String? nome, Tipo TipoElementos) {
      ListModel list = new ListModel(nome, TipoElementos, Tipo.Lista);
      Listas.Add(list);
      return list;
    }

    public String EscreveObjeto(Boolean escreverNome = true) {
      String textoJson = escreverNome ? $"\"{Nome}\": {{" : $"{{";
     
      foreach (PropertyModel atributo in Atributos) {
        textoJson += atributo.EscreveAtributo();
        if (Atributos.Last() != atributo) {
         textoJson += InsereVirgula(true, false);
        }
      }
      if (Objetos.Count > 0) {
        textoJson += InsereVirgula(true, false);
      }
      foreach (ObjectModel objeto in Objetos) {
        textoJson += objeto.EscreveObjeto();
        if (Objetos.Last() != objeto) {
          textoJson += InsereVirgula(true, false);
        }
      }
      if (Listas.Count > 0) {
        textoJson += InsereVirgula(true, false);
      }
      foreach (ListModel lista in Listas) {
        textoJson += lista.EscreveLista();
        if (Listas.Last() != lista) {
          textoJson += InsereVirgula(true, false);
        }
      }
      
      textoJson += "}";
      return textoJson;
    }

  }

}
