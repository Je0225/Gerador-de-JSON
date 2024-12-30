
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

    public String AsString() {
      AbreJson();
      foreach (Model objeto in Objetos) {
        if (objeto.Tipo == Tipo.Atributo) {
          EscreveAtributo((PropertyModel)objeto);
        }
        if (objeto.Tipo == Tipo.Objeto) {
          EscreveObjeto((ObjectModel)objeto);
        }
        if (Objetos.Last() != objeto) {
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
        TextoJson += objeto.GeraTexto("");
      }
      FechaJson();
    }

    private void EscreveAtributo(PropertyModel model) {
      String? nome = model.Nome;
      if (nome == null || model.Tipo != Tipo.Atributo) {
        return;
      }
      Object? valor = model.Value;
      switch (valor?.GetType().Name) {
        case null:
          valor = "null";
          break;
        case "DateTime":
          DateTime dateTime = (DateTime)valor;
          valor = dateTime.ToString("yyyyMMdd");
          break;
        case "DateOnly":
          DateOnly date = (DateOnly)valor;
          valor = date.ToString("yyyyMMdd");
          break;
        case "String":
          valor = $"\"{valor}\"";
          break;
        case "Double":
          valor = valor.ToString()?.Replace(",", ".");
          break;
        case "Boolean":
          valor = valor.ToString()?.ToLower();
          break;
      }
      TextoJson += $"\"{nome}\":{valor}";
    }

  }

}
