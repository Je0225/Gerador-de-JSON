namespace GeradorDeJson {
  internal class ValidateJson {

    private Boolean ehObjeto = false;
    private Boolean ehLista = false;
    private Boolean ehkey = false;
    private Boolean ehValue = false;
    private Int32 nivel = 0;
    private Int32 idxErro = 0;
    private String[] parents;
    private String atual = "";
    private String lista = "lista";
    private String objeto = "objeto";

    private void SetaValores(Boolean ehObjetoValue, Boolean ehListaValue, Boolean ehKeyValue, Boolean ehValueVal) {
      ehObjeto = ehObjetoValue;
      ehLista = ehListaValue;
      ehkey = ehKeyValue;
      ehValue = ehValueVal;
    }

    private void AtualizaVariaveis(Char letra) {
      switch (letra) {
        case '{':
          SetaValores(true, false, true, false);
          if (nivel == 0) {
            atual = objeto;
          }
          nivel++;
          parents[nivel - 1] = atual;
          atual = objeto;
          break;
        case '[':
          SetaValores(false, true, false, true);
          if (nivel == 0) {
            atual = lista;
          }
          nivel++;
          parents[nivel - 1] = atual;
          atual = lista;
          break;
        default: {
          if (letra == '}' || letra == ']') {
            ehObjeto = parents[nivel - 1] == objeto;
            nivel--;
            ehLista = !ehObjeto;
            atual = ehObjeto ? objeto : lista;
            ehkey = false;
            ehValue = true;
          }
          if (!ehLista && letra == ':') {
            SetaValores(true, false, false, true);
          } else if (!ehLista && ehValue && letra == ',') {
            SetaValores(true, false, true, false);
          }
          break;
        }
      }
    }

    public String Validate(String textoJson) {
      String msg = "JSON é válido!";
      Char letraAnterior = '\0';
      Int32 startIndex = 0;
      Int32 count = 0;
      Int32 forCount = 0;
      Boolean isValid = true;
      parents = new String[textoJson.Split('{').Length + textoJson.Split('[').Length];

      if (String.IsNullOrEmpty(textoJson)) {
        return "Não há texto para validar.";
      }
      for (int i = 0; i < textoJson.Length; i++) {
        Char letra = textoJson[i];
        AtualizaVariaveis(letra);
        if (ehObjeto) {
          if ((letra == '{' && letraAnterior == '{') || (letra == ',' && (textoJson[i + 1] == '{'|| textoJson[i + 1] == '['))) {
            msg = "Nome de objeto não encontrado.";
            idxErro = i;
            isValid = false;
            break;
          }
        }
        if (ehLista) {
          if (letra == ':' && letraAnterior == '"') {
            msg = "Listas só podem ter elementos não nonimados. Esperado: ',' ao invés de ':'.";
            idxErro = i;
            isValid = false;
            break;
          }
        } 
        letraAnterior = letra;
      }
      if (isValid) {
        return msg;
      }
      startIndex = idxErro >= 20 ? idxErro - 20 : 0;
      count = (textoJson.Length - idxErro) >= 20 ? 20 : textoJson.Length - idxErro;
      count += idxErro >= 20 ? 20 : idxErro;
      forCount = idxErro >= 20 ? 20 : idxErro;

      msg += "\n";
      if (idxErro > 3) {
        msg += "...";
        forCount += 3;
      }
      msg += $"{textoJson.Substring(startIndex, count)}\n";
      for (int i = 0; i < forCount; i++) {
        msg += "-";
      }
      msg += "^";
      return msg;
    }

  }
}
