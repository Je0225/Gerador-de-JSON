using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeJson {

  public abstract class Model {

    protected String? Nome { get; init; }

    public abstract String AsString();

  }
}
