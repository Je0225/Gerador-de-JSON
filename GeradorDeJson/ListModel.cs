using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeJson {

  public class ListModel(String? nome, Tipo tipoElementos, Tipo tipo): Model(nome, tipo){

    private List<Model> Lista { get; set; } = new();

    private String Nome { get; set; } = nome;

    public  Tipo Tipo { get; set; }

    private Tipo TipoElementos { get; set; } = tipoElementos;

    public void Add(Model elemento) {
      //Model e = (Model)elemento;
      if (TipoElementos != elemento.Tipo) {
        Console.WriteLine("O elemento não será adicionado: o tipo do elemento informado não corresponde ao tipo da lista");
      }
      Lista.Add(elemento);
    }

    public String EscreveLista() {
      String textoJson = $"\"{Nome}\": [";

      foreach (Model elemento in Lista) {
        if (elemento.Tipo == Tipo.Atributo) {
          PropertyModel property = (PropertyModel)elemento;
          textoJson += property.EscreveAtributo(false);
        }
        if (elemento.Tipo == Tipo.Objeto) {
          ObjectModel objeto = (ObjectModel)elemento;
          textoJson += objeto.EscreveObjeto(false);
        }
        if (Lista.Last() != elemento) {
          textoJson += InsereVirgula(true, false);
        }
      }
      textoJson += "]";
      return textoJson;
    }

  }

}
