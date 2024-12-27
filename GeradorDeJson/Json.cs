using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Boolean = System.Boolean;
using Object = System.Object;
using String = System.String;

namespace GeradorDeJson {
  internal class Json {

    private String TextoJson { get; set; } = "";

    private List<Model> Objetos { get; } = new();

    public ObjectModel AddObject(String? nome) {
      ObjectModel obj = new ObjectModel(nome, Tipo.Objeto);
      Objetos.Add(obj);
      return obj;
    }

    public void AddAtributo(String? nome, Object? value) {
      Objetos.Add(new PropertyModel(nome, value, Tipo.Atributo));
    }

    private void AbreJson() {
      TextoJson = "{\n";
    }

    private void FechaJson() {
      TextoJson += "\n}";
    }

    private void InsereVirgula(Boolean inserirEspaco, Boolean quebrarLinha) {
      TextoJson += inserirEspaco ? ", " : ",";
      TextoJson += quebrarLinha? "\n" : "";
    }

    public override String ToString() {
      AbreJson();
      foreach (Model obj in Objetos) {
        if (obj.Tipo == Tipo.Atributo) {
          EscreveAtributo((PropertyModel)obj);
        }
        if (obj.Tipo == Tipo.Objeto) {
          EscreveObjeto((ObjectModel)obj);
        }
        if (Objetos.Last() != obj) {
          InsereVirgula(false, true);
        }
      }
      FechaJson();
      return TextoJson;
    }

    private void EscreveObjeto(ObjectModel model) {
      if (model.Tipo != Tipo.Objeto) {
        return;
      }
      TextoJson += $"\"{model.Nome}\": {{";
      List<PropertyModel> atributos = model.RetornaAtributos();
      List<ObjectModel> objetos = model.RetornaObjetos();

      foreach (PropertyModel atributo in atributos) {
        EscreveAtributo(atributo);
        if (atributos.Last() != atributo) {
          InsereVirgula(true, false);
        }
      }
      if (objetos.Count > 0) {
        InsereVirgula(true, false);
      }
      foreach (ObjectModel objeto in objetos) {
        TextoJson += $"\"{objeto.Nome}\": ";
        TextoJson += objeto.GeraTexto();
      }
    }

    private void EscreveAtributo(PropertyModel model) {
      String? nome = model.Nome;
      if (nome == null || model.Tipo != Tipo.Atributo) {
        return;
      }
      Object? valor = model.Value;
      if (valor == null) {
        valor = "null";
      } else {
        valor = valor?.GetType().Name switch {
          "String" => $"\"{valor}\"",
          "Double" => valor.ToString()?.Replace(",", "."),
          "DateTime" => valor.ToString()?.Replace("/", "-").Remove(10).Insert(0, "\"").Insert(11, "\""),
          "Boolean" => valor.ToString()?.ToLower(),
          _ => valor
        };
      }
      TextoJson += $"\"{nome}\":{valor}";
    }

  }

}
