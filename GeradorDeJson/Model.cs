using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeJson {

  public class Model {

    public String? Nome { get; }

    public Tipo Tipo { get; }


    public Model(String? nome, Tipo tipo) {
      Nome = nome;
      Tipo = tipo;
    }

  }
}
