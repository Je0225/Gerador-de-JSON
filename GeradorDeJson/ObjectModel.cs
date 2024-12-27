using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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

    public ObjectModel AdicionaObjeto(String? nome, Object? value) {
      ObjectModel obj = new ObjectModel(nome, Tipo.Objeto);
      Objetos.Add(obj);
      return obj;
    }

    public ObjectModel AdicionaLista(String? nome, Object? value) {
      ObjectModel obj = new ObjectModel(nome, Tipo.Lista);
      Listas.Add(obj);
      return obj;
    }

    public String GeraTexto(){
      Json json = new Json();
      foreach (PropertyModel atributo in Atributos) {
        json.AddAtributo(atributo.Nome, atributo.Value);
      }
      foreach (ObjectModel obj in Objetos) {
        json.AddObject(obj.Nome);
        obj.GeraTexto();
      }
      return json.ToString();
    }

    
  }
}
