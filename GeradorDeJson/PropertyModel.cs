using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Boolean = System.Boolean;
using Object = System.Object;
using String = System.String;

namespace GeradorDeJson {
  public class PropertyModel : Model {

    private Object? Value { get; }

    public PropertyModel(String nome, Object? value) {
      Nome = nome;
      Value = value;
    }

    public PropertyModel(Object value) {
      Nome = null;
      Value = value;
    }

    public override String AsString(Boolean escreverNome = true) {
      Object? valor = Value;
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
      return escreverNome ? $"\"{Nome}\":{valor}" : valor?.ToString()!;
    }
  }
}
