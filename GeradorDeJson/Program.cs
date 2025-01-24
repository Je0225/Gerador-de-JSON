// See https://aka.ms/new-console-template for more information

using GeradorDeJson;

Json Json = new Json();

ObjectModel periodoApuracao = Json.AddObject("PeriodoApuracao");
periodoApuracao.AdicionaAtributo("MesApuracao", 11);
periodoApuracao.AdicionaAtributo("AnoApuracao", 2024);

ObjectModel dadosIniciais = Json.AddObject("DadosIniciais");
dadosIniciais.AdicionaAtributo("SemMovimento", false);
dadosIniciais.AdicionaAtributo("QualificacaoPj", 1);
dadosIniciais.AdicionaAtributo("TributacaoLucro", 3);

ObjectModel responsavelApuracao = dadosIniciais.AdicionaObjeto("ResponsavelApuracao");
responsavelApuracao.AdicionaAtributo("CpfResponsavel", "111.111.111-28");

ObjectModel telResponsavel = responsavelApuracao.AdicionaObjeto("TelResponsavel");
telResponsavel.AdicionaAtributo("Ddd", 45);
telResponsavel.AdicionaAtributo("NumTelefone", "99999-1111");

responsavelApuracao.AdicionaAtributo("EmailResponsavel", "email@empresa.com.br");
responsavelApuracao.AdicionaObjeto("RegistroCrc").AdicionaAtributo("UfRegistro", "PR");

ObjectModel debitos = Json.AddObject("Debitos");
debitos.AdicionaAtributo("BalancoLucroReal", false);

ListModel lista = Json.AddLista("Umalista");
lista.Add(5);
lista.Add(9);

ListModel outraLista = Json.AddLista("Outralista");
outraLista.Add(dadosIniciais);
outraLista.Add(periodoApuracao);

ObjectModel giovano = Json.AddObject("pessoa");
giovano.AdicionaAtributo("nome", "giovano");
giovano.AdicionaAtributo("foda", true);
giovano.AdicionaAtributo("teste", null);
ListModel numerosMegasena = giovano.AdicionaLista("megasena");
numerosMegasena.Add(10);
numerosMegasena.Add(26);
numerosMegasena.Add(29);
numerosMegasena.Add(33);
numerosMegasena.Add(52);
numerosMegasena.Add(58);
ListModel provas = Json.AddLista("provas");
ObjectModel provaPt = new ObjectModel();
provaPt.AdicionaAtributo("nome", "portugues");
provaPt.AdicionaAtributo("nota", 9.5);
ObjectModel provaMat = new ObjectModel();
provaMat.AdicionaAtributo("nome", "matematica");
provaMat.AdicionaAtributo("nota", 9);
provas.Add(provaPt);
provas.Add(provaMat);

Console.WriteLine(Json.AsString());
