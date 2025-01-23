using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeJson {

  public class Model {

    public String? Nome { get; }

    public Tipo Tipo { get; }

    protected Model(String? nome, Tipo tipo) {
      Nome = nome;
      Tipo = tipo;
    }

    protected Model() {

    }

    protected String InsereVirgula(Boolean inserirEspaco, Boolean quebrarLinha) {
      if (inserirEspaco) {
        return ", ";
      }
      if (!inserirEspaco) {
        return ",";
      }
      if (quebrarLinha) {
        return "\n";
      }
      return "";
    }
}
}
