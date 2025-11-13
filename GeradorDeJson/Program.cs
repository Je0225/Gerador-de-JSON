using GeradorDeJson;

Json json = new Json();

ObjectModel periodoApuracao = json.AddObjeto("PeriodoApuracao");
periodoApuracao.AddAtributo("MesApuracao", 11);
periodoApuracao.AddAtributo("AnoApuracao", 2024);

ObjectModel dadosIniciais = json.AddObjeto("DadosIniciais");
dadosIniciais.AddAtributo("SemMovimento", false);
dadosIniciais.AddAtributo("QualificacaoPj", 1);
dadosIniciais.AddAtributo("TributacaoLucro", 3);

ObjectModel responsavelApuracao = dadosIniciais.AddObjeto("ResponsavelApuracao");
responsavelApuracao.AddAtributo("CpfResponsavel", "111.111.111-28");

ObjectModel telResponsavel = responsavelApuracao.AddObjeto("TelResponsavel");
telResponsavel.AddAtributo("Ddd", 45);
telResponsavel.AddAtributo("NumTelefone", "99999-1111");

responsavelApuracao.AddAtributo("EmailResponsavel", "email@empresa.com.br");
responsavelApuracao.AddObjeto("RegistroCrc").AddAtributo("UfRegistro", "PR");

ObjectModel debitos = json.AddObjeto("Debitos");
debitos.AddAtributo("BalancoLucroReal", false);

ListModel umaLista = json.AddLista("OutrosValores");
umaLista.Add(5);
umaLista.Add(9);

// Exemplo de JSON inválido

/*ListModel provas = Json.AddLista("notas");
ObjectModel provaPt = provas.AddObjeto(null);
provaPt.AddAtributo("nome", "portugues");
provaPt.AddAtributo("nota", 9.5);
ObjectModel obj = provaPt.AddObjeto(null);
obj.AddAtributo("tema", "redação");
ObjectModel provaMat = provas.AddObjeto(null);
provaMat.AddAtributo("nome", "matematica");
provaMat.AddAtributo("nota", 9);*/

Console.WriteLine(json.AsString());
Console.WriteLine(json.Validate());
