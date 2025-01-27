using Boolean = System.Boolean;
using Object = System.Object;
using String = System.String;

namespace GeradorDeJson {
  public class PropertyModel : Model {

    private Object? Valor { get; }

    public PropertyModel(String nome, Object? valor) {
      Nome = nome;
      Valor = valor;
    }

    public PropertyModel(Object valor) {
      Nome = null;
      Valor = valor;
    }

    public override String AsString() {
      Object? valor = Valor;
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
      return String.IsNullOrEmpty(Nome) ? valor?.ToString()! : $"\"{Nome}\":{valor}";
    }
  }
}
