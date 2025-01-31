// See https://aka.ms/new-console-template for more information

using GeradorDeJson;

Json Json = new Json();

/*ObjectModel periodoApuracao = Json.AddObjeto("PeriodoApuracao");
periodoApuracao.AddAtributo("MesApuracao", 11);
periodoApuracao.AddAtributo("AnoApuracao", 2024);

ObjectModel dadosIniciais = Json.AddObjeto("DadosIniciais");
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

ObjectModel debitos = Json.AddObjeto("Debitos");
debitos.AddAtributo("BalancoLucroReal", false);

ListModel umaLista = Json.AddLista("Umalista");
umaLista.Add(5);
umaLista.Add(9);

ListModel outraLista = Json.AddLista("Outralista");
ListModel terceiralista = outraLista.AddLista(null);
terceiralista.Add(3223);
ObjectModel objeto = outraLista.AddObjeto(null);
objeto.AddAtributo("umAtributo", "ValorAtrbuto");*/

// Json Giovano;

ObjectModel giovano = Json.AddObjeto("pessoa");
giovano.AddAtributo("nome", "giovano");
giovano.AddAtributo("foda", true);
giovano.AddAtributo("teste", null);
ListModel numerosMegasena = giovano.AddLista("megasena");
numerosMegasena.Add(10);
numerosMegasena.Add(26);
numerosMegasena.Add(29);
numerosMegasena.Add(33);
numerosMegasena.Add(52);
numerosMegasena.Add(58);
ListModel provas = Json.AddLista("notas");
ObjectModel provaPt = provas.AddObjeto(null);
provaPt.AddAtributo("nome", "portugues");
provaPt.AddAtributo("nota", 9.5);
ObjectModel obj = provaPt.AddObjeto(null);
obj.AddAtributo("tantofaz", "qualquercoisa");
ObjectModel provaMat = provas.AddObjeto(null);
provaMat.AddAtributo("nome", "matematica");
provaMat.AddAtributo("nota", 9);

Console.WriteLine(Json.AsString());
Console.WriteLine(Json.Validate());
