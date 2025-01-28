
using Boolean = System.Boolean;
using Object = System.Object;
using String = System.String;

namespace GeradorDeJson {
  internal class Json : Model {

    private String TextoJson { get; set; } = "";

    private List<Model> Elementos { get; } = new();

    public ObjectModel AddObjeto(String nome) {
      ObjectModel obj = new ObjectModel(nome);
      Elementos.Add(obj);
      return obj;
    }

    public void AddAtributo(String nome, Object? value) {
      Elementos.Add(new PropertyModel(nome, value));
    }

    public ListModel AddLista(String nome) {
      ListModel list = new ListModel(nome);
      Elementos.Add(list);
      return list;
    }

    public override String AsString() {
      TextoJson = "{";
      foreach (Model elemento in Elementos) {
        TextoJson += elemento.AsString();
        if (Elementos.Last() != elemento) {
          TextoJson += ",";
        }
      }
      TextoJson += "}";
      return TextoJson;
    }

    public String Validate() {
      //validar listas

      String json = TextoJson;
      Int32 idxAberturaUltimaLista = json.LastIndexOf('[');
      json = json.Substring(idxAberturaUltimaLista);
      Int32 idxFechamentoUltimaLista = json.IndexOf(']');
      json = json.Substring(0, idxFechamentoUltimaLista + 1);
      Boolean ehLista = false;
      Boolean ehObjeto = false;
      Int32 idxErro = 0;
      String msg = "JSON is valid!";

      for (int i = 0; i < json.Length; i++) {
        Char caracter = json[i];
        if (caracter == '{') {
          ehLista = false;
          ehObjeto = true;
        } else if (caracter == '[') {
          ehLista = true;
          ehObjeto = false;
        } else if (caracter == '}' || caracter == ']') {
          ehLista = false;
          ehObjeto = false;
        }
        if (ehLista && caracter == ':') {
          msg = "Error: Parse error on line 1:\n";
          idxErro = TextoJson.IndexOf(json, StringComparison.Ordinal);
          idxErro += i;
          msg += $"...{TextoJson.Substring(idxErro - 20, 40)}\n";

          idxErro = i;
          for (int j = 0; j < idxErro; j++) {
            msg += '-';
          }
          msg += '^';
          break;
        }
      }
      return msg;
    }

  }

}
