
using Boolean = System.Boolean;
using Object = System.Object;
using String = System.String;

namespace GeradorDeJson {
  internal class Json : Model {

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

    public String AsString() {
      AbreJson();
      foreach (Model objeto in Objetos) {
        if (objeto.Tipo == Tipo.Atributo) {
          PropertyModel p = (PropertyModel)objeto;
          TextoJson += p.EscreveAtributo();
        }
        if (objeto.Tipo == Tipo.Objeto) {
          ObjectModel o = (ObjectModel)objeto;
          TextoJson += o.EscreveObjeto();
        }
        if (Objetos.Last() != objeto) {
          TextoJson += InsereVirgula(false, true);
        }
      }
      FechaJson();
      return TextoJson;
    }

  }

}
