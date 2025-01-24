
using Boolean = System.Boolean;
using Object = System.Object;
using String = System.String;

namespace GeradorDeJson {
  internal class Json : Model {

    private String TextoJson { get; set; } = "";

    private List<Model> Objetos { get; } = new();

    public ObjectModel AddObject(String nome) {
      ObjectModel obj = new ObjectModel(nome);
      Objetos.Add(obj);
      return obj;
    }

    public void AddAtributo(String nome, Object? value) {
      Objetos.Add(new PropertyModel(nome, value));
    }

    public ListModel AddLista(String nome) {
      ListModel list = new ListModel(nome);
      Objetos.Add(list);
      return list;
    }

    public override String AsString(Boolean escreverNome = true) {
      TextoJson = "{\n";
      foreach (Model objeto in Objetos) {
        TextoJson += objeto.AsString();
        if (Objetos.Last() != objeto) {
          TextoJson += "\n";
        }
      }
      TextoJson += "\n}";
      return TextoJson;
    }

  }

}
