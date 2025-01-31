
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
      return TextoJson + "\n";
    }

    public String Validate() {
      return new ValidateJson().Validate(TextoJson);
    }

  }

}
