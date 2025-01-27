using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeJson {

  public class ListModel : CompositModel {

    protected override String StringAbertura => "[";

    protected override String StringFechamento => "]";

    public ListModel(String? nome) {
      Nome = nome;
      Elementos = new List<Model>();
    }

    public void Add(Object elemento) {
      PropertyModel property = new PropertyModel(elemento);
      Elementos.Add(property);
    }

  }

}
