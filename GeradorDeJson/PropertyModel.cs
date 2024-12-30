using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Object = System.Object;
using String = System.String;

namespace GeradorDeJson {
  public  class PropertyModel : Model {

    public new String? Nome { get; }

    public Object? Value { get;}

    public new Tipo Tipo { get; }

    public PropertyModel(String? nome, Object? value, Tipo tipo) : base(nome, tipo) {
      Nome = nome;
      Value = value;
      Tipo = tipo;
    }

    public String EscreveAtributo() {
      if (Nome == null || Tipo != Tipo.Atributo) {
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
      return  $"\"{Nome}\":{valor}";
    }
  }
}
