namespace GeradorDeJson {

  public abstract class Model {

    protected String? Nome { get; init; }

    public abstract String AsString();

  }
}
