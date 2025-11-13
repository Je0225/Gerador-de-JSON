using Object = System.Object;
using String = System.String;

namespace GeradorDeJson {

  public class ObjectModel : CompositModel {

    protected override String StringAbertura => "{";

    protected override String StringFechamento => "}";

    public ObjectModel(String? nome) {
      Nome = nome;
      Elementos = new List<Model>();
    }

    public void AddAtributo(String nome, Object? value) {
      Elementos.Add(new PropertyModel(nome, value));
    }


  }

}
