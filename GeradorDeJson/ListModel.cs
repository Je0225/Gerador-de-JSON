using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeJson {

  public class ListModel : Model {

    private List<Model> Lista { get; set; } = new();

    public ListModel(String? nome) {
      Nome = nome;
    }

    public void Add(Object elemento) {
      PropertyModel property = new PropertyModel(elemento);
      Lista.Add(property);
    }

    public void Add(Model elemento) {
      Lista.Add(elemento);
    }

    public override String AsString(Boolean escreverNome = true) {
      String textoJson = escreverNome ? $"\"{Nome}\": [" : $"[";
      foreach (Model elemento in Lista) {
        textoJson += elemento.AsString(false);
        if (Lista.Last() != elemento) {
          textoJson += ", ";
        }
      }
      textoJson += "]";
      return textoJson;
    }

    // unir o ObjectModel e o ListModel
  }

}
