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

  public class ObjectModel : Model {
    private List<Model> Propriedades { get; } = new();

    public ObjectModel(String nome) {
      Nome = nome;
    }

    public ObjectModel() {
      Nome = null;
    }

    public void AdicionaAtributo(String nome, Object? value) {
      Propriedades.Add(new PropertyModel(nome, value));
    }

    public ObjectModel AdicionaObjeto(String nome) {
      ObjectModel obj = new ObjectModel(nome);
      Propriedades.Add(obj);
      return obj;
    }

    public ListModel AdicionaLista(String nome) {
      ListModel list = new ListModel(nome);
      Propriedades.Add(list);
      return list;
    }

    public override String AsString(Boolean escreverNome = true) {
      String textoJson = escreverNome ? $"\"{Nome}\": {{" : $"{{";
      foreach (Model atributo in Propriedades) {
        textoJson += atributo.AsString();
        if (Propriedades.Last() != atributo) {
          textoJson += ", ";
        }
      }
      textoJson += "}";
      return textoJson;
    }

  }

}
