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
  }
}
