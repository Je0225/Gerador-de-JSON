// See https://aka.ms/new-console-template for more information

using GeradorDeJson;

Json Json = new Json();

/*ObjectModel periodoApuracao = Json.AddObject("PeriodoApuracao");
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

ListModel lista = Json.AddLista("Umalista", Tipo.Atributo);
lista.Add(new PropertyModel(null, 5, Tipo.Atributo));
lista.Add(new PropertyModel(null, 9, Tipo.Atributo));

ListModel outraLista = Json.AddLista("Outralista", Tipo.Objeto);
outraLista.Add(dadosIniciais);
outraLista.Add(periodoApuracao);*/

ObjectModel Giovano = Json.AddObject("pessoa");
Giovano.AdicionaAtributo("nome", "giovano");
Giovano.AdicionaAtributo("foda", true);
Giovano.AdicionaAtributo("teste", null);
ListModel numerosMegasena = Giovano.AdicionaLista("megasena", Tipo.Atributo);
numerosMegasena.Add(new PropertyModel(null, 10, Tipo.Atributo));
numerosMegasena.Add(new PropertyModel(null, 26, Tipo.Atributo));
numerosMegasena.Add(new PropertyModel(null, 29, Tipo.Atributo));
numerosMegasena.Add(new PropertyModel(null, 33, Tipo.Atributo));
numerosMegasena.Add(new PropertyModel(null, 52, Tipo.Atributo));
numerosMegasena.Add(new PropertyModel(null, 58, Tipo.Atributo));
ListModel provas = Json.AddLista("provas", Tipo.Objeto);
ObjectModel provaPt = new ObjectModel(null, Tipo.Objeto);
provaPt.AdicionaAtributo("nome", "portugues");
provaPt.AdicionaAtributo("nota", 9.5);
ObjectModel provaMat = new ObjectModel(null, Tipo.Objeto);
provaMat.AdicionaAtributo("nome", "matematica");
provaMat.AdicionaAtributo("nota", 9);
provas.Add(provaPt);
provas.Add(provaMat);

Console.WriteLine(Json.AsString());
