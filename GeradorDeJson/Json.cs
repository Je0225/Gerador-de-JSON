
using Boolean = System.Boolean;
using Object = System.Object;
using String = System.String;

namespace GeradorDeJson {
  internal class Json : Model {

    private String TextoJson { get; set; } = "";

    private List<Model> Elementos { get; } = new();

    public ObjectModel AddObjeto(String nome) {
      ObjectModel obj = new ObjectModel(nome);
      Elementos.Add(obj);
      return obj;
    }

    public void AddAtributo(String nome, Object? value) {
      Elementos.Add(new PropertyModel(nome, value));
    }

    public ListModel AddLista(String nome) {
      ListModel list = new ListModel(nome);
      Elementos.Add(list);
      return list;
    }

    public override String AsString() {
      TextoJson = "{";
      foreach (Model elemento in Elementos) {
        TextoJson += elemento.AsString();
        if (Elementos.Last() != elemento) {
          TextoJson += ",";
        }
      }
      TextoJson += "}";
      return TextoJson;
    }

    public String Validate() {
      if (String.IsNullOrEmpty(TextoJson)) {
        return "Não há texto para validar.";
      }
      Boolean abriuAspas = false;
      Boolean ehObjeto = false;
      Boolean ehLista = false;
      Boolean ehkey = false;
      Boolean ehValue = false;
      Char letraAnterior = '\0';
      Int32 nivel = 0;
      Int32 idxErro = 0;
      String[] parents = new String[10];
      String atual = "";
      String msg = "JSON é válido!";

      void AtualizaVariaveis(Char letra) {
        if (letra == '"') {
          abriuAspas = !abriuAspas;
        }
        switch (letra) {
          case '{':
            ehObjeto = true;
            ehLista = false;
            ehkey = true;
            ehValue = false;
            if (nivel == 0) {
              atual = "objeto";
            }
            nivel++;
            parents[nivel - 1] = atual;
            atual = "objeto";
            break;
          case '[':
            ehObjeto = false;
            ehLista = true;
            ehkey = false;
            ehValue = true;
            if (nivel == 0) {
              atual = "lista";
            }
            nivel++;
            parents[nivel - 1] = atual;
            atual = "lista";
            break;
          case '}':
            ehObjeto = parents[nivel -1] == "objeto";
            nivel--;
            ehLista = !ehObjeto;
            atual = ehObjeto ? "objeto": "lista";
            ehkey = false;
            ehValue = true;
            break;
          case ']':
            ehObjeto = parents[nivel - 1] == "objeto";
            nivel--;
            ehLista = !ehObjeto;
            atual = ehObjeto ? "objeto" : "lista";
            ehkey = false;
            ehValue = true;
            break;
          default: {
            if (!ehLista && letra == ':') {
              ehObjeto = true;
              ehLista = false;
              ehkey = false;
              ehValue = true;
            } 
            else if (!ehLista && ehValue && letra == ',') {
              ehObjeto = true;
              ehLista = false;
              ehkey = true;
              ehValue = false;
            }
            break;
          }
        }
      }

      for (int i = 0; i < TextoJson.Length; i++) {
         Char letra = TextoJson[i];
         AtualizaVariaveis(letra);
         if (i == 0 && letra != '{' && letra != '[') {
           msg = "O JSON não foi aberto corretamente. Esperado: '{' ou '['.";
           idxErro = i;
           break;
         }
         if (ehObjeto) {
           if (letra == '{' && letraAnterior == '{') {
             msg = "Nome de objeto não encontrado.";
             idxErro = i;
             break;
           }
           if (letra == ',' && TextoJson[i + 1] == '{') {
             msg = "Nome de objeto não encontrado.";
             idxErro = i;
             break;
           }
           if (letra == ',' && TextoJson[i + 1] == '[') {
             msg = "Nome de objeto não encontrado.";
             idxErro = i;
             break;
           }
         }
         if (ehLista) {
           if (letra == ':' && letraAnterior == '"') {
             msg = "Listas só podem ter elementos não nonimados. Esperado: ,";
             idxErro = i;
             break;
           }
         }
         letraAnterior = letra;
      }
      if (msg == "JSON é válido!") {
        return msg;
      }
      if (idxErro < 20) {
        TextoJson = TextoJson.Substring(0, 40);
        msg += $"\n...{TextoJson}\n";
        for (int i = 0; i < idxErro + 3; i++) {
          msg += "-";
        }
        msg += "^";
        return msg;
      }
      TextoJson = TextoJson.Substring(idxErro - 20, 40);
      
      msg += $"\n...{TextoJson}\n";
      for(int i = 0; i < 23; i++){
        msg += "-";
      }
      msg += "^";
      return msg;
    }

  }

}
