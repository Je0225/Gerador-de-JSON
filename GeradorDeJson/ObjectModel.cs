using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Boolean = System.Boolean;
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
