using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeJson {
  public  class CompositModel: Model {

    protected virtual String StringAbertura { get; set; }

    protected virtual String StringFechamento { get; set; }

    protected List<Model> Elementos { get; set; }

    public ListModel AddLista(String? nome) {
      ListModel list = new ListModel(nome);
      Elementos.Add(list);
      return list;
    }

    public ObjectModel AddObjeto(String? nome) {
      ObjectModel obj = new ObjectModel(nome);
      Elementos.Add(obj);
      return obj;
    }

    public override String AsString() {
      String textoJson = String.IsNullOrEmpty(Nome)? $"{StringAbertura}" : $"\"{Nome}\": {StringAbertura}";
      foreach (Model elemento in Elementos) {
        textoJson += elemento.AsString();
        if (Elementos.Last() != elemento) {
          textoJson += ", ";
        }
      }
      textoJson += $"{StringFechamento}";
      return textoJson;
    }
  }

}
