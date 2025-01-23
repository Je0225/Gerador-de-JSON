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
  public class PropertyModel(String? nome, Object? value, Tipo tipo): Model(nome, tipo) {

    private String? Nome { get; } = nome;

    private Object? Value { get;} = value;

    private new Tipo Tipo { get; set; }

    public String EscreveAtributo(Boolean escreverNome = true) {
      if (Tipo != Tipo.Atributo) {
        return "";
      }
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
      if (escreverNome) {
        return $"\"{Nome}\":{valor}";
      }
      return valor.ToString();
    }
  }
}
